using Marko.Api.Mercury.Application.Exceptions;
using MedicalClinic.Application.Exceptions;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;

namespace MedicalClinic.Application.Rules
{
    public class SpecialtyRules : ISpecialtyRules
    {
        private readonly ISpecialtyRepository _SpecialtyRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SpecialtyRules
            (ISpecialtyRepository SpecialtyRepository,
            IAvailabilityRepository availabilityRepository,
            ISpecialtyRepository specialtyRepository,
            IDoctorRepository doctorRepository,
            IUnitOfWork unitOfWork

            )
        {
            _SpecialtyRepository = SpecialtyRepository;
            _availabilityRepository = availabilityRepository;
            _specialtyRepository = specialtyRepository;
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Check if the appointment duration is valid
        /// </summary>
        /// <param name="appointmentDuration"></param>
        /// <returns></returns>
        /// <exception cref="MdException"></exception>
        public async Task CheckAppointmentDurationIsValid(int appointmentDuration)
        {
            if (appointmentDuration == 0)
                throw new MdException(SharedResource.MESSAGE_SPECIALTY_APPOINTMENT_DURATION_NOT_VALID);
        }

    }
}