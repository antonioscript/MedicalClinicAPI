using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    //TODO: O nome da classe 'Specialty' está incorreto, ajeitar
    /// <summary>
    /// Stores information about medical specialties
    /// </summary>
    public partial class Specialty
    {
        public Specialty()
        {
            Doctors = new HashSet<Doctor>();
        }

        /// <summary>
        /// Unique identifier for each medical specialty
        /// </summary>
        public int SpecialtyId { get; set; }
        /// <summary>
        /// The name of the medical specialty
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// escription of the medical specialty
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Value of Consultation 
        /// </summary>
        public decimal ConsultationValue { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
