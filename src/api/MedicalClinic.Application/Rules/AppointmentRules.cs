using Marko.Api.Mercury.Application.Exceptions;
using MedicalClinic.Application.Exceptions;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Rules
{
    public class AppointmentRules : IAppointmentRules
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentRules
            (IAppointmentRepository appointmentRepository, 
            IAvailabilityRepository availabilityRepository, 
            ISpecialtyRepository specialtyRepository,
            IDoctorRepository doctorRepository,
            IUnitOfWork unitOfWork
            
            )
        {
            _appointmentRepository = appointmentRepository;
            _availabilityRepository = availabilityRepository;
            _specialtyRepository = specialtyRepository;
            _doctorRepository = doctorRepository;
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

        /// <summary>
        /// Check appointment availability rules
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="appointmentDate"></param>
        /// <returns></returns>
        /// <exception cref="MdException"></exception>
        public async Task CheckDoctorHasAvailability(int doctorId, DateTime appointmentDate)
        {
            //Doctor 
            var doctor = await _doctorRepository.Entities
                .Where(d => d.Id == doctorId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            //Default Query Duration
            var appointmenDuration = await _specialtyRepository.Entities
                .Where(s => s.Id == doctor.SpecialtyId)
                .Select(s => s.AppointmentDuration)
                .FirstOrDefaultAsync();

            //All times available for medical care provided as a parameter
            var allAvailabilitiesDoctorId = await _availabilityRepository.Entities
                .Where(a => a.DoctorId == doctor.Id)
                .AsNoTracking()
                .ToListAsync();

            //Check if there is availability for the day and time chosen to make the appointment
            var isAvailabilityFound = allAvailabilitiesDoctorId
                .Any(availability =>
                    availability.DayOfWeek == appointmentDate.DayOfWeek &&
                    availability.StartTime <= appointmentDate.TimeOfDay &&
                    availability.EndTime >= appointmentDate.AddMinutes(appointmenDuration).TimeOfDay);

            if (!isAvailabilityFound)
                throw new MdException(SharedResource.MESSAGE_DOCTOR_IS_NOT_AVAILABLE, doctorId);

            if (allAvailabilitiesDoctorId == null)
                throw new MdException(SharedResource.MESSAGE_DOCTOR_HAS_NO_AVAILABILITY, doctorId);

            //Check if there is already an appointment scheduled at that time considering the duration of the appointment
            var appointmentOverlap = await _appointmentRepository.Entities
                .Where(a => a.DoctorId == doctorId && (a.AppointmentDate <= appointmentDate && appointmentDate < a.AppointmentDate.AddMinutes(appointmenDuration)))
                .AsNoTracking()
                .ToListAsync();

            if (appointmentOverlap != null && appointmentOverlap.Any())
                throw new MdException(SharedResource.MESSAGE_DOCTOR_ALREADY_APPOINTMENT_SPECIFIED_TIME, doctorId);


           
        }
    }
}
