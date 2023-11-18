using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Forwarding
{
    public class ForwardingRequestFilter
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }

        public int? SpecialtyId { get; set; }

        public string? Observation { get; set; }
    }
}
