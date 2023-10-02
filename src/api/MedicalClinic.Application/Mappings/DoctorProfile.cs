using AutoMapper;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Features.Doctors.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<CreateDoctorCommand, Doctor>();

            CreateMap<Doctor, DoctorResponse>();
            CreateMap<PaginatedResult<Doctor>, PaginatedResult<DoctorResponse>>();
        }
    }
}
