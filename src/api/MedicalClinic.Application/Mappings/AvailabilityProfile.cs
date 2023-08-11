using AutoMapper;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<Availability, AvailabilityResponse>();
        }
    }
}
