using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Procedures.Queries
{
    public class GetAllProcedureByFilterQuery : IRequest<Result<List<ProcedureResponse>>>
    {
        public ProcedureRequestFilter AppRequest { get; set; }

        public GetAllProcedureByFilterQuery(ProcedureRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllProcedureByFilterQuery, Result<List<ProcedureResponse>>>
    {
        private readonly IProcedureRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IProcedureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProcedureResponse>>> Handle(GetAllProcedureByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.PatientId == null || p.PatientId == request.AppRequest.PatientId)
                       && (request.AppRequest.TechnicianId == null || p.TechnicianId == request.AppRequest.TechnicianId)
                       && (request.AppRequest.ExamId == null || p.ExamId == request.AppRequest.ExamId)
                       && (String.IsNullOrEmpty(request.AppRequest.Observation) || p.Observation.Contains(request.AppRequest.Observation)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled))
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<ProcedureResponse>>(list);
            return Result<List<ProcedureResponse>>.Success(listResult); ;
        }

    }
}