using AutoMapper;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Specialties.Queries
{
    public class GetAllSpecialtyQuery : IRequest<List<SpecialtyResponse>>
    {
        public GetAllSpecialtyQuery()
        {

        }
    }

    public class GetAllSpecialtyQueryHandler : IRequestHandler<GetAllSpecialtyQuery, List<SpecialtyResponse>>
    {
        private readonly ISpecialtyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSpecialtyQueryHandler(ISpecialtyRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<SpecialtyResponse>> Handle(GetAllSpecialtyQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<SpecialtyResponse>>(list);

            return listResult;
        }
    }

}
