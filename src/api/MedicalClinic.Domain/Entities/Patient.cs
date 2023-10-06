using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Procedures = new HashSet<Procedure>();
        }


        public int Id { get; set; }
        public int? InsuranceId { get; set; }
        public virtual Insurance? Insurance { get; set; }

        //TODO: Define the type of Insurance
        public byte? InsuranceType { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Document { get; set; }

        public DateTime DateOfBirth { get; set; }
       
        public PatientGenderCode Gender { get; set; }
        public string PhoneOne { get; set; } = null!;
        public string? PhoneTwo { get; set; }
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
