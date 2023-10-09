using MedicalClinic.Application.Enums;

namespace MedicalClinic.Application.DTOs.Patient
{
    public class PatientRequestFilter
    {
        public int? InsuranceId { get; set; }

        public byte? InsuranceType { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Document { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public PatientGenderCodeDto? Gender { get; set; }
        public string? PhoneOne { get; set; } 
        public string? PhoneTwo { get; set; }
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool? IsEnabled { get; set; }
    }
}
