using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Procedures.Queries
{
    public class GetAllPagedProcedureQuery : IRequest<PaginatedResult<ProcedureResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedProcedureQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedProcedureQueryHandler : IRequestHandler<GetAllPagedProcedureQuery, PaginatedResult<ProcedureResponse>>
    {
        private readonly IProcedureRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedProcedureQueryHandler(IProcedureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ProcedureResponse>> Handle(GetAllPagedProcedureQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<ProcedureResponse>>(paginatedList);
            return listResult;
        }

    }
}