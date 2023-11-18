using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.Queries
{
    public class GetAllPrescriptionByFilterQuery : IRequest<Result<List<PrescriptionResponse>>>
    {
        public PrescriptionRequestFilter AppRequest { get; set; }

        public GetAllPrescriptionByFilterQuery(PrescriptionRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllPrescriptionByFilterQuery, Result<List<PrescriptionResponse>>>
    {
        private readonly IPrescriptionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IPrescriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<PrescriptionResponse>>> Handle(GetAllPrescriptionByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.AppointmentId == null || p.AppointmentId == request.AppRequest.AppointmentId)
                       && (String.IsNullOrEmpty(request.AppRequest.Observation) || p.Observation.Contains(request.AppRequest.Observation))
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<PrescriptionResponse>>(list);
            return Result<List<PrescriptionResponse>>.Success(listResult); ;
        }

    }
}