using AutoMapper;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Technicians.Queries
{
    public class GetAllTechnicianQuery : IRequest<List<TechnicianResponse>>
    {
        public GetAllTechnicianQuery()
        {

        }
    }

    public class GetAllTechnicianQueryHandler : IRequestHandler<GetAllTechnicianQuery, List<TechnicianResponse>>
    {
        private readonly ITechnicianRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTechnicianQueryHandler(ITechnicianRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<TechnicianResponse>> Handle(GetAllTechnicianQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<TechnicianResponse>>(list);

            return listResult;
        }
    }

}
