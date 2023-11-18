using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.Queries
{
    public class GetAllPagedPrescriptionQuery : IRequest<PaginatedResult<PrescriptionResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedPrescriptionQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedPrescriptionQueryHandler : IRequestHandler<GetAllPagedPrescriptionQuery, PaginatedResult<PrescriptionResponse>>
    {
        private readonly IPrescriptionRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedPrescriptionQueryHandler(IPrescriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<PrescriptionResponse>> Handle(GetAllPagedPrescriptionQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<PrescriptionResponse>>(paginatedList);
            return listResult;
        }

    }
}