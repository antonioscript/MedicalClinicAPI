using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.CanceledAppointments.Queries
{
    public class GetAllPagedCanceledAppointmentQuery : IRequest<PaginatedResult<CanceledAppointmentResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedCanceledAppointmentQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedCanceledAppointmentQueryHandler : IRequestHandler<GetAllPagedCanceledAppointmentQuery, PaginatedResult<CanceledAppointmentResponse>>
    {
        private readonly ICanceledAppointmentRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedCanceledAppointmentQueryHandler(ICanceledAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CanceledAppointmentResponse>> Handle(GetAllPagedCanceledAppointmentQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<CanceledAppointmentResponse>>(paginatedList);
            return listResult;
        }

    }
}