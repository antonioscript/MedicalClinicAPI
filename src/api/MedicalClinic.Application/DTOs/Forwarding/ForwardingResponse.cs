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
    public class ForwardingResponse
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        //public PrescriptionResponse Prescription { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public SpecialtyResponse Specialty { get; set; } = null!;

        public string? Observation { get; set; }
    }
}
