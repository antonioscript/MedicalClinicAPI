using AutoMapper;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class ProcedureProfile : Profile
    {
        public ProcedureProfile()
        {
            //CreateMap<CreateProcedureCommand, ProcedureResponse>();

            CreateMap<Procedure, ProcedureResponse>();
            CreateMap<PaginatedResult<Procedure>, PaginatedResult<ProcedureResponse>>();
        }
    }
}
