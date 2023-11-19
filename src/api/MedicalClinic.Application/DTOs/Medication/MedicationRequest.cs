using MedicalClinic.Application.DTOs.Appointment;

namespace MedicalClinic.Application.DTOs.Medication
{
    public class MedicationRequest
    {
        public string? Name { get; set; } = null!;
        public string? SubstituteOne { get; set; }
        public string? SubstituteTwo { get; set; }
        public string Instruction { get; set; } = null!;
    }
}
