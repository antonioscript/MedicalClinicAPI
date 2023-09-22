using AutoMapper;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            //CreateMap<CreateInsuranceCommand, InsuranceResponse>();

            CreateMap<Insurance, InsuranceResponse>();
            CreateMap<PaginatedResult<Insurance>, PaginatedResult<InsuranceResponse>>();
        }
    }
}
