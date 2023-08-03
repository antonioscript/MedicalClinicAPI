using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about the availability schedule for doctors.
    /// </summary>
    public partial class Availability
    {
        /// <summary>
        /// Unique identifier for each availability entry.
        /// </summary>
        public int AvailabilityId { get; set; }
        /// <summary>
        /// Foreign key referencing the doctor associated with this availability
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// The day of the week when the doctor is available:
        /// 0: Monday
        /// 1: Tuesday
        /// 2: Wednesday
        /// 3: Thursday
        /// 4: Friday
        /// 5: Saturday
        /// 6: Sunday
        /// </summary>
        public byte DayOfWeek { get; set; }
        /// <summary>
        /// The start time of the doctors availability for the specified day.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The end time of the doctors availability for the specified day
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
    }
}
