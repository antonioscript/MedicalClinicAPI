using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Forwarding;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.Commands
{
    public partial class CreatePrescriptionCommand : IRequest<Result<int>>
    {
        public CreatePrescriptionCommand()
        {
            Medications = new HashSet<MedicationRequest>();
            Forwardings = new HashSet<ForwardingRequest>();
        }

        public int AppointmentId { get; set; }
        public string Observation { get; set; } = null!;

        public virtual ICollection<MedicationRequest> Medications { get; set; }
        public virtual ICollection<ForwardingRequest> Forwardings { get; set; }
    }


    public class CreatePrescriptionCommandHandler : IRequestHandler<CreatePrescriptionCommand, Result<int>>
    {
        private readonly IPrescriptionRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePrescriptionCommandHandler(IPrescriptionRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.AppointmentId == request.AppointmentId)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PRESCRIPTION_EXISTS, request.AppointmentId));
            }

            var register = _mapper.Map<Prescription>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
