using AutoMapper;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<Insurance, InsuranceResponse>();
        }
    }
}
