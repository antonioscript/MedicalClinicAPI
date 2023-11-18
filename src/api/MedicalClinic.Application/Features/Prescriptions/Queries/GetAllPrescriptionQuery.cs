using AutoMapper;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Prescriptions.Queries
{
    public class GetAllPrescriptionQuery : IRequest<List<PrescriptionResponse>>
    {
        public GetAllPrescriptionQuery()
        {

        }
    }

    public class GetAllPrescriptionQueryHandler : IRequestHandler<GetAllPrescriptionQuery, List<PrescriptionResponse>>
    {
        private readonly IPrescriptionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPrescriptionQueryHandler(IPrescriptionRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<PrescriptionResponse>> Handle(GetAllPrescriptionQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .Include(e => e.Medications)
                .Include(e => e.Forwardings).ThenInclude(e => e.Specialty)
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<PrescriptionResponse>>(list);

            return listResult;
        }
    }

}
