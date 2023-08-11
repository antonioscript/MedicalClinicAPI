using AutoMapper;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class TechnicianrProfile : Profile
    {
        public TechnicianrProfile()
        {
            CreateMap<Technician, TechnicianResponse>();
        }
    }
}
