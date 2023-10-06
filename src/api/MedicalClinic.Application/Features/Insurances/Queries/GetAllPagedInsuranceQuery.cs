using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Insurances.Queries
{
    public class GetAllPagedInsuranceQuery : IRequest<PaginatedResult<InsuranceResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedInsuranceQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedInsuranceQueryHandler : IRequestHandler<GetAllPagedInsuranceQuery, PaginatedResult<InsuranceResponse>>
    {
        private readonly IInsuranceRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedInsuranceQueryHandler(IInsuranceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<InsuranceResponse>> Handle(GetAllPagedInsuranceQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<InsuranceResponse>>(paginatedList);
            return listResult;
        }

    }
}