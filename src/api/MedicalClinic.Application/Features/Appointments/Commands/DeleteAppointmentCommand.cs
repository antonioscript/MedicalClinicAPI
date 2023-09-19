using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Appointments.Commands
{
    public class DeleteAppointmentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteCompetitorCompanyCommandHandler : IRequestHandler<DeleteAppointmentCommand, Result<int>>
        {
            private readonly IAppointmentRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompetitorCompanyCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteAppointmentCommand command, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(command.Id);

                if (result == null)
                {
                    //await _unitOfWork.Rollback();
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_APPOINTMENT_NOT_FOUND, command.Id));
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