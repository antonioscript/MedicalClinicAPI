using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.CanceledAppointments.Commands
{
    public partial class CreateCanceledAppointmentCommand : IRequest<Result<int>>
    {
        public int AppointmentId { get; set; }
        public string? ReasonCancellation { get; set; }
    }


    public class CreateCanceledAppointmentCommandHandler : IRequestHandler<CreateCanceledAppointmentCommand, Result<int>>
    {
        private readonly ICanceledAppointmentRepository _repository;
        private readonly IAppointmentRules _appointmentRules;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCanceledAppointmentCommandHandler(ICanceledAppointmentRepository repository, IAppointmentRules appointmentRules, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _appointmentRules = appointmentRules;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCanceledAppointmentCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.AppointmentId == request.AppointmentId)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_CANCELED_APPOINTMENT_EXISTS, request.AppointmentId));
            }

            await _appointmentRules.CheckRulesForCancelingAnAppointment(request.AppointmentId);
            await _appointmentRules.MarkAnAppointmentAsCanceled(request.AppointmentId);

            var register = _mapper.Map<CanceledAppointment>(request);

            register.CancellationDate = DateTime.Now;

            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
