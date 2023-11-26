using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Features.Appointments.Queries
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
                var result = await _repository.Entities
                    .Where(c => c.Id == query.Id)
                    .Include(a => a.RequestingDoctor)
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<AppointmentResponse>(result);
                return Result<AppointmentResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}