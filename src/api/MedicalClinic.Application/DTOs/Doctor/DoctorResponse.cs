using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Doctor
{
    public class DoctorResponse
    {
        public DoctorResponse()
        {
            //Appointments = new HashSet<AppointmentResponse>();
            Availabilities = new HashSet<AvailabilityResponse>();
        }


        public int Id { get; set; }
        public int SpecialtyId { get; set; }
        public virtual SpecialtyResponse Specialty { get; set; } = null!;

        public string Crm { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }

        //public virtual ICollection<AppointmentResponse> Appointments { get; set; }
        public virtual ICollection<AvailabilityResponse> Availabilities { get; set; }
    }
}
