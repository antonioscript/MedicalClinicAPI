using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marko.Api.Mercury.Application.Features.Appointments.Queries
{
    public class GetAppointmentByIdQuery : IRequest<Result<AppointmentResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Result<AppointmentResponse>>
        {
            private readonly IAppointmentRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IAppointmentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<AppointmentResponse>> Handle(GetAppointmentByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(query.Id);
                var mappedCompetitorCompany = _mapper.Map<AppointmentResponse>(result);
                return Result<AppointmentResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}