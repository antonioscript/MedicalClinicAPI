using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marko.Api.Mercury.Application.Features.Availabilities.SpecificQueries
{
    public class GetAvailabilityByIDoctordQuery : IRequest<Result<List<AvailabilityResponse>>>
    {
        public int DoctorId { get; set; }

        public class GetAvailabilityByIDoctordQueryHandler : IRequestHandler<GetAvailabilityByIDoctordQuery, Result<List<AvailabilityResponse>>>
        {
            private readonly IAvailabilityRepository _repository;
            private readonly IMapper _mapper;

            public GetAvailabilityByIDoctordQueryHandler(IAvailabilityRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<List<AvailabilityResponse>>> Handle(GetAvailabilityByIDoctordQuery query, CancellationToken cancellationToken)
            {
                var list = await _repository.Entities
                    //.Include(a => a.Doctor)
                    .Where(c => c.DoctorId == query.DoctorId)
                    .AsNoTracking()
                    .ToListAsync();

                var mappedAvailability = _mapper.Map<List<AvailabilityResponse>>(list);
                return Result<List<AvailabilityResponse>>.Success(mappedAvailability);
            }
        }
    }
}