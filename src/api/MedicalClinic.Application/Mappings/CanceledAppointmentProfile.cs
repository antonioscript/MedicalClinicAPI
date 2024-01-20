using AutoMapper;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Features.CanceledAppointments.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class CanceledAppointmentProfile : Profile
    {
        public CanceledAppointmentProfile()
        {
            CreateMap<CreateCanceledAppointmentCommand, CanceledAppointment>();

            CreateMap<CanceledAppointment, CanceledAppointmentResponse>();
            CreateMap<PaginatedResult<CanceledAppointment>, PaginatedResult<CanceledAppointmentResponse>>();
        }
    }
}
