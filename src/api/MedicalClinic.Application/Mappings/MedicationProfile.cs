using AutoMapper;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using System.Net.Mail;

namespace MedicalClinic.Application.Mappings
{
    internal class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<Medication, MedicationResponse>();
            CreateMap<MedicationRequest, Medication>();
            CreateMap<MedicationRequestUpdate, Medication>();
            CreateMap<PaginatedResult<Medication>, PaginatedResult<MedicationResponse>>();
        }
    }
}
