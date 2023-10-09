using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Patients.Queries
{
    public class GetAllPagedPatientQuery : IRequest<PaginatedResult<PatientResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedPatientQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedPatientQueryHandler : IRequestHandler<GetAllPagedPatientQuery, PaginatedResult<PatientResponse>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedPatientQueryHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<PatientResponse>> Handle(GetAllPagedPatientQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<PatientResponse>>(paginatedList);
            return listResult;
        }

    }
}