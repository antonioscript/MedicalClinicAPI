﻿using MediatR;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Specialties.Commands
{
    public class DeleteSpecialtyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteCompetitorCompanyCommandHandler : IRequestHandler<DeleteSpecialtyCommand, Result<int>>
        {
            private readonly ISpecialtyRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompetitorCompanyCommandHandler(ISpecialtyRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteSpecialtyCommand command, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(command.Id);

                if (result == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_SPECIALTY_NOT_FOUND, command.Id));
                }
                else
                {
                    await _repository.DeleteAsync(result);
                    await _unitOfWork.Commit(cancellationToken);
                }

                return Result<int>.Success(result.Id);
            }
        }
    }
}