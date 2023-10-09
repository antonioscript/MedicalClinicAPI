using AutoMapper;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Features.Procedures.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class ProcedureProfile : Profile
    {
        public ProcedureProfile()
        {
            CreateMap<CreateProcedureCommand, Procedure>();

            CreateMap<Procedure, ProcedureResponse>();
            CreateMap<PaginatedResult<Procedure>, PaginatedResult<ProcedureResponse>>();
        }
    }
}
