using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Insurances.Queries
{
    public class GetInsuranceByIdQuery : IRequest<Result<InsuranceResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetInsuranceByIdQuery, Result<InsuranceResponse>>
        {
            private readonly IInsuranceRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IInsuranceRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<InsuranceResponse>> Handle(GetInsuranceByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<InsuranceResponse>(result);
                return Result<InsuranceResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}