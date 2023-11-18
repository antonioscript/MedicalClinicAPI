using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.Queries
{
    public class GetPrescriptionByIdQuery : IRequest<Result<PrescriptionResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQuery, Result<PrescriptionResponse>>
        {
            private readonly IPrescriptionRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IPrescriptionRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<PrescriptionResponse>> Handle(GetPrescriptionByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .Include(d => d.Medications)
                    .Include(e => e.Forwardings).ThenInclude(e => e.Specialty)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<PrescriptionResponse>(result);
                return Result<PrescriptionResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}