using AutoMapper;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Procedures.Queries
{
    public class GetAllProcedureQuery : IRequest<List<ProcedureResponse>>
    {
        public GetAllProcedureQuery()
        {

        }
    }

    public class GetAllProcedureQueryHandler : IRequestHandler<GetAllProcedureQuery, List<ProcedureResponse>>
    {
        private readonly IProcedureRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProcedureQueryHandler(IProcedureRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<ProcedureResponse>> Handle(GetAllProcedureQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<ProcedureResponse>>(list);

            return listResult;
        }
    }

}
