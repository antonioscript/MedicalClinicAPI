﻿using MedicalClinic.Application.DTOs.Appointment;

namespace MedicalClinic.Application.DTOs.Medication
{
    public class MedicationResponse
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        //public PrescriptionResponse Prescription { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? SubstituteOne { get; set; }
        public string? SubstituteTwo { get; set; }
        public string Instruction { get; set; } = null!;
    }
}
