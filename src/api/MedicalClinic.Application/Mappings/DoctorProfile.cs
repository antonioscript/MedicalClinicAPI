using AutoMapper;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorResponse>();

            //CreateMap<CreateDoctorCommand, DoctorResponse>();

            CreateMap<Doctor, DoctorResponse>();
            CreateMap<PaginatedResult<Doctor>, PaginatedResult<DoctorResponse>>();
        }
    }
}
