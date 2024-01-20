using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.CanceledAppointments.Queries
{
    public class GetCanceledAppointmentByIdQuery : IRequest<Result<CanceledAppointmentResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetCanceledAppointmentByIdQuery, Result<CanceledAppointmentResponse>>
        {
            private readonly ICanceledAppointmentRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(ICanceledAppointmentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<CanceledAppointmentResponse>> Handle(GetCanceledAppointmentByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<CanceledAppointmentResponse>(result);
                return Result<CanceledAppointmentResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}