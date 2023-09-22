using AutoMapper;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Features.Appointments.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentCommand, Appointment>();
            
            CreateMap<Appointment, AppointmentResponse>();
            CreateMap<PaginatedResult<Appointment>, PaginatedResult<AppointmentResponse>>();
        }
    }
}
