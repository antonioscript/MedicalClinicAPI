﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Doctors.Commands
{
    public class UpdateDoctorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int SpecialtyId { get; set; }
       
        public string Crm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateDoctorCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDoctorRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_DOCTOR_NOT_FOUND, command.Id));
                }
                else
                {
                    var registerExists = await _repository.Entities
                        .Where(d => d.Id != command.Id && d.Crm == command.Crm)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_DOCTOR_EXISTS, command.Crm));
                    }
                    else
                    {
                        register.SpecialtyId = command.SpecialtyId;
                        register.Crm = command.Crm;

                        register.FirstName = command.FirstName ?? register.FirstName;
                        register.LastName = command.LastName ?? register.LastName;
                        register.Phone = command.Phone ?? register.Phone;
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