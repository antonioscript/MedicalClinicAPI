using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Features.Availabilities.Commands
{
    public partial class CreateAvailabilityCommand : IRequest<Result<int>>
    {
        public int DoctorId { get; set; }

        public AvailabilityDayOfWeekCode DayOfWeek { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int AppointmentDuration { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreateAvailabilityCommandHandler : IRequestHandler<CreateAvailabilityCommand, Result<int>>
    {
        private readonly IAvailabilityRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateAvailabilityCommandHandler(IAvailabilityRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var register = _mapper.Map<Availability>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
