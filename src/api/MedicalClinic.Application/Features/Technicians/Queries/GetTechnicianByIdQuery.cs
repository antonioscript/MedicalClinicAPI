using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Technicians.Queries
{
    public class GetTechnicianByIdQuery : IRequest<Result<TechnicianResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetTechnicianByIdQuery, Result<TechnicianResponse>>
        {
            private readonly ITechnicianRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(ITechnicianRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<TechnicianResponse>> Handle(GetTechnicianByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<TechnicianResponse>(result);
                return Result<TechnicianResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}