using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Patients.Commands
{
    public partial class CreatePatientCommand : IRequest<Result<int>>
    {
        public int? InsuranceId { get; set; }

        public byte? InsuranceType { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Document { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneOne { get; set; } = null!;
        public string? PhoneTwo { get; set; }
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<int>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.FirstName == request.FirstName && d.LastName == request.LastName)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PATIENT_EXISTS, request.FirstName, request.LastName));
            }

            var register = _mapper.Map<Patient>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
