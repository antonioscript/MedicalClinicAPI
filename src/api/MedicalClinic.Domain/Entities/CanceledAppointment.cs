using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class CanceledAppointment
    {
        public int Id { get; set; }
      
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; } = null!;
        public string? ReasonCancellation { get; set; }
        public DateTime CancellationDate { get; set; }
    }
}
