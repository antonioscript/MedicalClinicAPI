using AutoMapper;
using MedicalClinic.Application.DTOs.Forwarding;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class ForwardingProfile : Profile
    {
        public ForwardingProfile()
        {
            CreateMap<Forwarding, ForwardingResponse>();
            CreateMap<PaginatedResult<Forwarding>, PaginatedResult<ForwardingResponse>>();
        }
    }
}
