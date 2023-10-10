using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Specialties.Queries
{
    public class GetSpecialtyByIdQuery : IRequest<Result<SpecialtyResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetSpecialtyByIdQuery, Result<SpecialtyResponse>>
        {
            private readonly ISpecialtyRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(ISpecialtyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<SpecialtyResponse>> Handle(GetSpecialtyByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<SpecialtyResponse>(result);
                return Result<SpecialtyResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}