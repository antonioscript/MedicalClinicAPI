using AutoMapper;
using MedicalClinic.Application.DTOs.Forwarding;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using System.Net.Mail;

namespace MedicalClinic.Application.Mappings
{
    internal class ForwardingProfile : Profile
    {
        public ForwardingProfile()
        {
            CreateMap<Forwarding, ForwardingResponse>();
            CreateMap<ForwardingRequest, Forwarding>();
            CreateMap<ForwardingRequestUpdate, Forwarding>();
            CreateMap<PaginatedResult<Forwarding>, PaginatedResult<ForwardingResponse>>();
        }
    }
}
