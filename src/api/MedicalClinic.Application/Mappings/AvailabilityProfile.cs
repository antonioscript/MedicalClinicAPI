using AutoMapper;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Features.Appointments.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            //CreateMap<CreateAvailabilityCommand, AvailabilityResponse>();

            CreateMap<Availability, AvailabilityResponse>();
            CreateMap<PaginatedResult<Availability>, PaginatedResult<AvailabilityResponse>>();
        }
    }
}
