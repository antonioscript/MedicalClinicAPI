using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Availabilities.Queries
{
    public class GetAllAvailabilityByFilterQuery : IRequest<Result<List<AvailabilityResponse>>>
    {
        public AvailabilityRequestFilter AppRequest { get; set; }

        public GetAllAvailabilityByFilterQuery(AvailabilityRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllAvailabilityByIdByFilterQueryHandler : IRequestHandler<GetAllAvailabilityByFilterQuery, Result<List<AvailabilityResponse>>>
    {
        private readonly IAvailabilityRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAvailabilityByIdByFilterQueryHandler(IAvailabilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<AvailabilityResponse>>> Handle(GetAllAvailabilityByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.DoctorId == null || p.DoctorId == request.AppRequest.DoctorId)
                       && (request.AppRequest.DayOfWeek == null || p.DayOfWeek == (DayOfWeek)request.AppRequest.DayOfWeek)
                       && (request.AppRequest.StartTime == null || p.StartTime == request.AppRequest.StartTime)
                       && (request.AppRequest.EndTime == null || p.EndTime == request.AppRequest.EndTime)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<AvailabilityResponse>>(list);
            return Result<List<AvailabilityResponse>>.Success(listResult); ;
        }

    }
}