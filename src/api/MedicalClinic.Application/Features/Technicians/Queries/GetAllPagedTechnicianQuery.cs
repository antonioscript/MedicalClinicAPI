using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Technicians.Queries
{
    public class GetAllPagedTechnicianQuery : IRequest<PaginatedResult<TechnicianResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedTechnicianQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedTechnicianQueryHandler : IRequestHandler<GetAllPagedTechnicianQuery, PaginatedResult<TechnicianResponse>>
    {
        private readonly ITechnicianRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedTechnicianQueryHandler(ITechnicianRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<TechnicianResponse>> Handle(GetAllPagedTechnicianQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<TechnicianResponse>>(paginatedList);
            return listResult;
        }

    }
}