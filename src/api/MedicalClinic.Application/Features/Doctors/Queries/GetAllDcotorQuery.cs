using AutoMapper;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Doctors.Queries
{
    public class GetAllDoctorQuery : IRequest<List<DoctorResponse>>
    {
        public GetAllDoctorQuery()
        {

        }
    }

    public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, List<DoctorResponse>>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDoctorQueryHandler(IDoctorRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<DoctorResponse>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<DoctorResponse>>(list);

            return listResult;
        }
    }

}
