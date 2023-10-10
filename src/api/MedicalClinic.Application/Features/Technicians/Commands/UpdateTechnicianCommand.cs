using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Technicians.Commands
{
    public class UpdateTechnicianCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public byte? InsuranceType { get; set; }

        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateTechnicianCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ITechnicianRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(ITechnicianRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateTechnicianCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_TECHNICIAN_NOT_FOUND, command.Id));
                }
                else
                {
                    var registerExists = await _repository.Entities
                        .Where(d => d.Id != command.Id && d.FirstName == command.LastName && d.LastName == command.LastName)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_TECHNICIAN_EXISTS, command.FirstName, command.LastName));
                    }
                    else
                    {
                        register.InsuranceType = command.InsuranceType;
                        register.FirstName = command.FirstName ?? register.FirstName;
                        register.LastName = command.LastName ?? register.LastName;
                        register.Email = command.Email ?? register.Email;
                        register.Phone = command.Phone ?? register.Phone;
                        
                        register.AddressLineOne = command.AddressLineOne ?? register.AddressLineOne;
                        register.AddressLineTwo = command.AddressLineTwo ?? register.AddressLineTwo;
                        register.InsuranceType = command.InsuranceType;
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