using AutoMapper;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class SpecialtyProfile : Profile
    {
        public SpecialtyProfile()
        {
            //CreateMap<CreateSpecialtyCommand, SpecialtyResponse>();

            CreateMap<Specialty, SpecialtyResponse>();
            CreateMap<PaginatedResult<Specialty>, PaginatedResult<SpecialtyResponse>>();
        }
    }
}
