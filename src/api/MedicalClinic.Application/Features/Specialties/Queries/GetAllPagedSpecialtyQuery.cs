using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Specialties.Queries
{
    public class GetAllPagedSpecialtyQuery : IRequest<PaginatedResult<SpecialtyResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedSpecialtyQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedSpecialtyQueryHandler : IRequestHandler<GetAllPagedSpecialtyQuery, PaginatedResult<SpecialtyResponse>>
    {
        private readonly ISpecialtyRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedSpecialtyQueryHandler(ISpecialtyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<SpecialtyResponse>> Handle(GetAllPagedSpecialtyQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<SpecialtyResponse>>(paginatedList);
            return listResult;
        }

    }
}