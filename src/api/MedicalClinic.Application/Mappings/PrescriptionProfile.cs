using AutoMapper;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Features.Prescriptions.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class PrescriptionProfile : Profile
    {
        public PrescriptionProfile()
        {
            CreateMap<CreatePrescriptionCommand, Prescription>();

            CreateMap<Prescription, PrescriptionResponse>();
            CreateMap<PaginatedResult<Prescription>, PaginatedResult<PrescriptionResponse>>();
        }
    }
}
