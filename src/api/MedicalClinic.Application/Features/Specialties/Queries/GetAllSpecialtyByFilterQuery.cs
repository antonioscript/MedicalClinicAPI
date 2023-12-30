using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Specialties.Queries
{
    public class GetAllSpecialtyByFilterQuery : IRequest<Result<List<SpecialtyResponse>>>
    {
        public SpecialtyRequestFilter AppRequest { get; set; }

        public GetAllSpecialtyByFilterQuery(SpecialtyRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllSpecialtyByFilterQuery, Result<List<SpecialtyResponse>>>
    {
        private readonly ISpecialtyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(ISpecialtyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<SpecialtyResponse>>> Handle(GetAllSpecialtyByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (String.IsNullOrEmpty(request.AppRequest.Name) || p.Name.Contains(request.AppRequest.Name))
                       && (String.IsNullOrEmpty(request.AppRequest.Description) || p.Description.Contains(request.AppRequest.Description))

                       && (request.AppRequest.ConsultationValue == null || p.ConsultationValue == request.AppRequest.ConsultationValue)
                       && (request.AppRequest.AppointmentDuration == null || p.AppointmentDuration == request.AppRequest.AppointmentDuration)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<SpecialtyResponse>>(list);
            return Result<List<SpecialtyResponse>>.Success(listResult); ;
        }

    }
}