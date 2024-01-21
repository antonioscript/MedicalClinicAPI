using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Resource.Resources;
using MedicalClinic.Domain.Enums;

namespace MedicalClinic.Application.Features.Procedures.Commands
{
    public class UpdateProcedureCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TechnicianId { get; set; }
        public int ExamId { get; set; }
        public string? Observation { get; set; }

        public DateTime ProcedureDate { get; set; }
        public byte Status { get; set; }

        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateProcedureCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProcedureRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IProcedureRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateProcedureCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PROCEDURE_NOT_FOUND, command.Id));
                }
                else
                {

                    var registerExists = await _repository.Entities
                        .Where(e => e.Id != command.Id && (e.ProcedureDate == command.ProcedureDate))
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PROCEDURE_EXISTS, command.ProcedureDate));
                    }

                    register.PatientId = command.PatientId;
                    register.TechnicianId = command.TechnicianId;
                    register.ExamId = command.ExamId;
                    register.Observation = command.Observation ?? register.Observation;
                    register.ProcedureDate = command.ProcedureDate;
                    register.Status = (StatusCode)command.Status;
                    register.IsEnabled = command.IsEnabled;

                    await _repository.UpdateAsync(register);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(register.Id);
                }

                
            }
        }
    }
}