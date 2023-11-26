using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Features.Appointments.Commands
{
    public partial class CreateAppointmentCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int? RequestingDoctorId { get; set; }
        public int DoctorId { get; set; }
        public byte Status { get; set; }
        public DateTime AppointmentDate { get; set; }

        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }
    }


    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Result<int>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateAppointmentCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var register = _mapper.Map<Appointment>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
