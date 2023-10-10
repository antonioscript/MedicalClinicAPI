using AutoMapper;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.Features.Specialties.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class SpecialtyProfile : Profile
    {
        public SpecialtyProfile()
        {
            CreateMap<CreateSpecialtyCommand, Specialty>();

            CreateMap<Specialty, SpecialtyResponse>();
            CreateMap<PaginatedResult<Specialty>, PaginatedResult<SpecialtyResponse>>();
        }
    }
}
