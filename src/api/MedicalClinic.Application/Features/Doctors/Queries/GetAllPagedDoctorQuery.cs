using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Features.Doctors.Queries
{
    public class GetAllPagedDoctorQuery : IRequest<PaginatedResult<DoctorResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedDoctorQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedDoctorQueryHandler : IRequestHandler<GetAllPagedDoctorQuery, PaginatedResult<DoctorResponse>>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedDoctorQueryHandler(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<DoctorResponse>> Handle(GetAllPagedDoctorQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<DoctorResponse>>(paginatedList);
            return listResult;
        }

    }
}