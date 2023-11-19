namespace MedicalClinic.Application.DTOs.Forwarding
{
    public class ForwardingRequestUpdate
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }

        public int? SpecialtyId { get; set; }

        public string? Observation { get; set; }
    }
}
