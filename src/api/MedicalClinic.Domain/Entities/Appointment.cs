using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        /// <summary>
        /// Indicates the Status of the Query, being:
        /// 0:Scheduled
        /// 1:Confirmed
        /// 2: Cancelled
        /// </summary>
        public byte Status { get; set; }
    
        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
