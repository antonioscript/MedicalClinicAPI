using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Specialty
    {
        public Specialty()
        {
            Doctors = new HashSet<Doctor>();
            Forwardings = new HashSet<Forwarding>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double ConsultationValue { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }


        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Forwarding> Forwardings { get; set; }
    }
}
