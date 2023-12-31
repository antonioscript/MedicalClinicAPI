﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Insurances.Commands
{
    public class UpdateInsuranceCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public double PercentageTypeOne { get; set; }
        public double PercentageTypeTwo { get; set; }
        public double PercentageTypeThree { get; set; }

        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateInsuranceCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IInsuranceRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IInsuranceRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateInsuranceCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_INSURANCE_NOT_FOUND, command.Id));
                }
                else
                {
                    var registerExists = await _repository.Entities
                        .Where(d => d.Id != command.Id && d.Name == command.Name)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_INSURANCE_EXISTS, command.Name));
                    }
                    else
                    {
                        register.Name = command.Name ?? register.Name;
                        register.Description = command.Description ?? register.Description;
                        register.PercentageTypeOne = command.PercentageTypeOne;
                        register.PercentageTypeTwo = command.PercentageTypeTwo;
                        register.PercentageTypeThree = command.PercentageTypeThree;
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