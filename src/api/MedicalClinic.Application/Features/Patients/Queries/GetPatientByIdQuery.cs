using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Patients.Queries
{
    public class GetPatientByIdQuery : IRequest<Result<PatientResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<PatientResponse>>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<PatientResponse>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<PatientResponse>(result);
                return Result<PatientResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}