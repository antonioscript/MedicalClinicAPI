using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Appointment
    {
        public Appointment()
        {
            Prescriptions = new HashSet<Prescription>();
        }
        public int Id { get; set; }

        public int? RequestingDoctorId { get; set; }
        public virtual Doctor? RequestingDoctor { get; set; } = null!;

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        public AppointmentStatusCode Status { get; set; }    
        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
