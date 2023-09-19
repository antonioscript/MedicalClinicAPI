using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Marko.Api.Mercury.Application.Features.Appointments.Queries
{
    public class GetAllPagedAppointmentQuery : IRequest<PaginatedResult<AppointmentResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedAppointmentQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedAppointmentQueryHandler : IRequestHandler<GetAllPagedAppointmentQuery, PaginatedResult<AppointmentResponse>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedAppointmentQueryHandler(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<AppointmentResponse>> Handle(GetAllPagedAppointmentQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<AppointmentResponse>>(paginatedList);
            return listResult;
        }

    }
}