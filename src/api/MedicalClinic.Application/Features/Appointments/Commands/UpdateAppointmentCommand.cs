using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;

namespace MedicalClinic.Application.Features.Appointments.Commands
{
    public class UpdateAppointmentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public byte Status { get; set; }

        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateAppointmentCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IAppointmentRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail("Appointment not found");
                }

                register.PatientId = command.PatientId;
                register.DoctorId = command.DoctorId;
                register.Status = command.Status;
                register.Observation = command.Observation ?? register.Observation;
                register.IsEnabled = command.IsEnabled;

                await _repository.UpdateAsync(register);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(register.Id);
            }
        }
    }
}