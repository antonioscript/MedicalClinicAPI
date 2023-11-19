using MedicalClinic.Application.DTOs.Specialty;

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
