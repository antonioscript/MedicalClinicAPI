using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.CanceledAppointments.Queries
{
    public class GetAllCanceledAppointmentByFilterQuery : IRequest<Result<List<CanceledAppointmentResponse>>>
    {
        public CanceledAppointmentRequestFilter AppRequest { get; set; }

        public GetAllCanceledAppointmentByFilterQuery(CanceledAppointmentRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllCanceledAppointmentByFilterQuery, Result<List<CanceledAppointmentResponse>>>
    {
        private readonly ICanceledAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(ICanceledAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<CanceledAppointmentResponse>>> Handle(GetAllCanceledAppointmentByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                        (request.AppRequest.Id == null || p.Id == request.AppRequest.Id)
                       && (request.AppRequest.AppointmentId == null || p.AppointmentId == request.AppRequest.AppointmentId)
                       && (String.IsNullOrEmpty(request.AppRequest.ReasonCancellation) || p.ReasonCancellation.Contains(request.AppRequest.ReasonCancellation))
                       && (request.AppRequest.CancellationDate == null || p.CancellationDate == request.AppRequest.CancellationDate)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<CanceledAppointmentResponse>>(list);
            return Result<List<CanceledAppointmentResponse>>.Success(listResult); ;
        }

    }
}