

namespace MedicalClinic.Application.DTOs.Medication
{
    public class MedicationRequestUpdate
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }

        public string? Name { get; set; } = null!;
        public string? SubstituteOne { get; set; }
        public string? SubstituteTwo { get; set; }
        public string Instruction { get; set; } = null!;
    }
}
