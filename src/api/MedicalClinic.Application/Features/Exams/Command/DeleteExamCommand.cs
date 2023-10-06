using MediatR;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Exams.Commands
{
    public class DeleteExamCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteCompetitorCompanyCommandHandler : IRequestHandler<DeleteExamCommand, Result<int>>
        {
            private readonly IExamRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompetitorCompanyCommandHandler(IExamRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteExamCommand command, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(command.Id);

                if (result == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_EXAM_NOT_FOUND, command.Id));
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