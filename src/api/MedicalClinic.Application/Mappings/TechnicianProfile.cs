using AutoMapper;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {
            //CreateMap<CreateTechnicianCommand, Technician>();

            CreateMap<Technician, TechnicianResponse>();
            CreateMap<PaginatedResult<Technician>, PaginatedResult<TechnicianResponse>>();
        }
    }
}
