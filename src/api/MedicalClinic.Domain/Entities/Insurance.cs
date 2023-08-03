using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about health insurance plans or medical health plans
    /// </summary>
    public partial class Insurance
    {
        public Insurance()
        {
            Patients = new HashSet<Patient>();
        }

        /// <summary>
        /// nique identifier for each health insurance plan
        /// </summary>
        public int InsuranceId { get; set; }
        /// <summary>
        /// The name of the health insurance plan
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Description of the health insurance plan
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// A percentage value related to the health insurance plan
        /// </summary>
        public decimal PercentageTypeOne { get; set; }
        /// <summary>
        /// Another percentage value related to the health insurance plan
        /// </summary>
        public decimal PercentageTypeTwo { get; set; }
        /// <summary>
        /// Another percentage value related to the health insurance plan
        /// </summary>
        public decimal PercentageTypeThree { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
