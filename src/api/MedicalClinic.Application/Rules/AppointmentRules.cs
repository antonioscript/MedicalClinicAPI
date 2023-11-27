using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Rules
{
    public class AppointmentRules : IAppointmentRules
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentRules(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Mark Appointment as done
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task MarkAppointmentAsDone(int appointmentId, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.Entities
                .Where(a => a.Id == appointmentId)
                .FirstOrDefaultAsync();

            appointment.Status = AppointmentStatusCode.Completed;

            await _appointmentRepository.UpdateAsync(appointment);
            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
