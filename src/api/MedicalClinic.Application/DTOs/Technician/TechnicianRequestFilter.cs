using MedicalClinic.Application.DTOs.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Technician
{
    public class TechnicianRequestFilter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public byte? InsuranceType { get; set; }

        public bool? IsEnabled { get; set; }

    }
}
