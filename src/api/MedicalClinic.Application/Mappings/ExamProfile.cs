using AutoMapper;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class ExamProfile : Profile
    {
        public ExamProfile()
        {
            //CreateMap<CreateExamCommand, ExamResponse>();

            CreateMap<Exam, ExamResponse>();
            CreateMap<PaginatedResult<Exam>, PaginatedResult<ExamResponse>>();
        }
    }
}
