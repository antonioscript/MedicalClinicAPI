using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about technicians or technical staff
    /// </summary>
    public partial class Technician
    {
        public Technician()
        {
            Procedures = new HashSet<Procedure>();
        }

        public int TechnicianId { get; set; }
        /// <summary>
        /// The first name of the technician
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The last name or surname of the technician
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// The email address of the technician
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// The phone number of the technician
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// The address line one  of the patient.
        /// </summary>
        public string? AddressLineOne { get; set; }
        /// <summary>
        /// The address line two of the patient.
        /// </summary>
        public string? AddressLineTwo { get; set; }
        /// <summary>
        /// Type of Insurance
        /// </summary>
        public byte? InsuranceType { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
