using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            AppointmentsRequestingDoctor = new HashSet<Appointment>();
            Availabilities = new HashSet<Availability>();
        }


        public int Id { get; set; }
      
        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; } = null!;

        public string Crm { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Appointment> AppointmentsRequestingDoctor { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
