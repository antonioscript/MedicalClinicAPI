using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Availability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Doctor
{
    public class DoctorRequestFilter
    {
        public int SpecialtyId { get; set; }
        public string Crm { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }
    }
}
