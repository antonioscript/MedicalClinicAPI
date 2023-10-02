using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Marko.Api.Mercury.Application.Features.Availabilities.Queries
{
    public class GetAllPagedAvailabilityQuery : IRequest<PaginatedResult<AvailabilityResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedAvailabilityQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedAvailabilityQueryHandler : IRequestHandler<GetAllPagedAvailabilityQuery, PaginatedResult<AvailabilityResponse>>
    {
        private readonly IAvailabilityRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedAvailabilityQueryHandler(IAvailabilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<AvailabilityResponse>> Handle(GetAllPagedAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<AvailabilityResponse>>(paginatedList);
            return listResult;
        }

    }
}