using AutoMapper;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamResponse>();
        }
    }
}
