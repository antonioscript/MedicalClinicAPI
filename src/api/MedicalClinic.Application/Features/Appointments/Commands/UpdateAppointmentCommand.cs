using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Resource.Resources;
using MedicalClinic.Application.Interfaces.Rules;

namespace MedicalClinic.Application.Features.Appointments.Commands
{
    public class UpdateAppointmentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int? RequestingDoctorId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public StatusCode Status { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateAppointmentCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IAppointmentRepository _repository;
            private readonly IAppointmentRules _appointmentRules;

            public UpdateCompetitorCompaniesCommandHandler(IAppointmentRepository repository, IAppointmentRules appointmentRules, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _appointmentRules = appointmentRules;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_APPOINTMENT_NOT_FOUND, command.Id));
                }

                await _appointmentRules.CheckCanUpdateStatus(command.Id);

                register.PatientId = command.PatientId;
                register.RequestingDoctorId = command.RequestingDoctorId ?? register.RequestingDoctorId;
                register.DoctorId = command.DoctorId;
                register.Status = (StatusCode)command.Status;
                register.AppointmentDate = command.AppointmentDate;
                register.Observation = command.Observation ?? register.Observation;
                register.IsEnabled = command.IsEnabled;

                await _repository.UpdateAsync(register);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(register.Id);
            }
        }
    }
}