using AutoMapper;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientResponse>();
        }
    }
}
