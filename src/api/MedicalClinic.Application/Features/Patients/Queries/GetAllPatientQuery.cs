using AutoMapper;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Patients.Queries
{
    public class GetAllPatientQuery : IRequest<List<PatientResponse>>
    {
        public GetAllPatientQuery()
        {

        }
    }

    public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, List<PatientResponse>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPatientQueryHandler(IPatientRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<PatientResponse>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<PatientResponse>>(list);

            return listResult;
        }
    }

}
