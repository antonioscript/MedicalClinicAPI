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

namespace MedicalClinic.Application.DTOs.Medication
{
    public class MedicationRequestFilter
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }

        public string? Name { get; set; } = null!;
        public string? SubstituteOne { get; set; }
        public string? SubstituteTwo { get; set; }
        public string Instruction { get; set; } = null!;
    }
}
