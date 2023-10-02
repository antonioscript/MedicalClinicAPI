using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Features.Doctors.Queries
{
    public class GetDoctorByIdQuery : IRequest<Result<DoctorResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Result<DoctorResponse>>
        {
            private readonly IDoctorRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IDoctorRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<DoctorResponse>> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .Include(d => d.Specialty)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<DoctorResponse>(result);
                return Result<DoctorResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}