using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Insurances.Queries
{
    public class GetAllInsuranceByFilterQuery : IRequest<Result<List<InsuranceResponse>>>
    {
        public InsuranceRequestFilter AppRequest { get; set; }

        public GetAllInsuranceByFilterQuery(InsuranceRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllInsuranceByFilterQuery, Result<List<InsuranceResponse>>>
    {
        private readonly IInsuranceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IInsuranceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<InsuranceResponse>>> Handle(GetAllInsuranceByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (String.IsNullOrEmpty(request.AppRequest.Name) || p.Name.Contains(request.AppRequest.Name))
                       && (String.IsNullOrEmpty(request.AppRequest.Description) || p.Description.Contains(request.AppRequest.Description))

                       && (request.AppRequest.PercentageTypeOne == null || p.PercentageTypeOne == request.AppRequest.PercentageTypeOne)
                       && (request.AppRequest.PercentageTypeTwo == null || p.PercentageTypeTwo == request.AppRequest.PercentageTypeTwo)
                       && (request.AppRequest.PercentageTypeThree == null || p.PercentageTypeThree == request.AppRequest.PercentageTypeThree)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<InsuranceResponse>>(list);
            return Result<List<InsuranceResponse>>.Success(listResult); ;
        }

    }
}