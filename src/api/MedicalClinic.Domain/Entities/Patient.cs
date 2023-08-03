using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about patients and their medical records.
    /// </summary>
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Procedures = new HashSet<Procedure>();
        }

        /// <summary>
        /// Patients table unique identifier
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the insurance plan associated with the procedure
        /// </summary>
        public int? InsuranceId { get; set; }
        /// <summary>
        /// Type of Insurance
        /// </summary>
        public byte? InsuranceType { get; set; }
        /// <summary>
        /// The  name of the patient
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The last name  of the patient
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Document of Patient
        /// </summary>
        public string? Document { get; set; }
        /// <summary>
        /// The date of birth of the patient
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// The gender of the patient
        /// 0: Male, 
        /// 1: Female,
        /// 2: NonBinary
        /// </summary>
        public byte Gender { get; set; }
        /// <summary>
        /// The phone one  number of the patient.
        /// </summary>
        public string PhoneOne { get; set; } = null!;
        /// <summary>
        /// The phone two  number of the patient.
        /// </summary>
        public string? PhoneTwo { get; set; }
        /// <summary>
        /// The email address of the patient.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// The address line one of the patient.
        /// </summary>
        public string? AddressLineOne { get; set; }
        /// <summary>
        /// The address line two of the patient.
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

        public virtual Insurance? Insurance { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
