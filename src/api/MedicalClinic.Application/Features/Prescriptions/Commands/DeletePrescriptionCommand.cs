using MediatR;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Resource.Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.Commands
{
    public class DeletePrescriptionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteCompetitorCompanyCommandHandler : IRequestHandler<DeletePrescriptionCommand, Result<int>>
        {
            private readonly IPrescriptionRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompetitorCompanyCommandHandler(IPrescriptionRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePrescriptionCommand command, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == command.Id)
                    .Include(d => d.Medications)
                    .Include(e => e.Forwardings)
                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PRESCRIPTION_NOT_FOUND, command.Id));
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