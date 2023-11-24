using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marko.Api.Mercury.Application.Features.Availabilities.Queries
{
    public class GetAvailabilityByIdQuery : IRequest<Result<AvailabilityResponse>>
    {
        public int Id { get; set; }

        public class GetAvailabilityByIdQueryHandler : IRequestHandler<GetAvailabilityByIdQuery, Result<AvailabilityResponse>>
        {
            private readonly IAvailabilityRepository _repository;
            private readonly IMapper _mapper;

            public GetAvailabilityByIdQueryHandler(IAvailabilityRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<AvailabilityResponse>> Handle(GetAvailabilityByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(query.Id);
                var mappedAvailability = _mapper.Map<AvailabilityResponse>(result);
                return Result<AvailabilityResponse>.Success(mappedAvailability);
            }
        }
    }
}