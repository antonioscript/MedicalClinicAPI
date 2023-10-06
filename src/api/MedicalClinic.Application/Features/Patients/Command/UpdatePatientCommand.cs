using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Patients.Commands
{
    public class UpdatePatientCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
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


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdatePatientCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPatientRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PATIENT_NOT_FOUND, command.Id));
                }
                else
                {
                    var registerExists = await _repository.Entities
                        .Where(d => d.Id != command.Id && d.FirstName == command.LastName && d.LastName == command.LastName)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PATIENT_EXISTS, command.FirstName, command.LastName));
                    }
                    else
                    {
                        register.InsuranceType = command.InsuranceType;
                        register.FirstName = command.FirstName ?? register.FirstName;
                        register.LastName = command.LastName ?? register.LastName;
                        register.Document = command.Document ?? register.Document;
                        register.DateOfBirth = command.DateOfBirth;

                        register.Document = command.Document ?? register.Document;
                        register.PhoneOne = command.PhoneOne ?? register.PhoneOne;
                        register.Email = command.Email ?? register.Email;
                        register.AddressLineOne = command.AddressLineOne ?? register.AddressLineOne;
                        register.AddressLineTwo = command.AddressLineTwo ?? register.AddressLineTwo;
                        register.IsEnabled = command.IsEnabled;

                        await _repository.UpdateAsync(register);
                        await _unitOfWork.Commit(cancellationToken);
                        return Result<int>.Success(register.Id);
                    }
                }

                
            }
        }
    }
}