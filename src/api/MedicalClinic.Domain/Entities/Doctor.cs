using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about medical doctors, their specialties, and contact details.
    /// </summary>
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Availabilities = new HashSet<Availability>();
        }

        /// <summary>
        /// Unique identifier for each doctor in the system
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// Unique identifier for each medical specialty
        /// </summary>
        public int SpecialtyId { get; set; }
        /// <summary>
        /// The CRM (Conselho Regional de Medicina) number of the doctor
        /// </summary>
        public string Crm { get; set; } = null!;
        /// <summary>
        /// The first name of the doctor.
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        ///  The last name or surname of the doctor
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// The phone number of the doctor.
        /// </summary>
        public string Phone { get; set; } = null!;
        /// <summary>
        /// The email address of the doctor.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// The address of the doctor
        /// </summary>
        public string? AddressLineOne { get; set; }
        /// <summary>
        /// The address of the doctor
        /// </summary>
        public string? AddressLineTwo { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual Specialty Specialty { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
