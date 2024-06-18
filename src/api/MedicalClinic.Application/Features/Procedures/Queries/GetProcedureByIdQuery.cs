using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Procedures.Queries
{
    public class GetProcedureByIdQuery : IRequest<Result<ProcedureResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetProcedureByIdQuery, Result<ProcedureResponse>>
        {
            private readonly IProcedureRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IProcedureRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ProcedureResponse>> Handle(GetProcedureByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .Include(a => a.Exam)
                    .Include(b => b.Technician)
                    .Include(b => b.Patient)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<ProcedureResponse>(result);
                return Result<ProcedureResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}