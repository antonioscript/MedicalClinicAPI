using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Prescription
    {
        public Prescription()
        {
            Medications = new HashSet<Medication>();
            Forwardings = new HashSet<Forwarding>();
        }
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public string Observation { get; set; } = null!;

        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Forwarding> Forwardings { get; set; }
    }
}
