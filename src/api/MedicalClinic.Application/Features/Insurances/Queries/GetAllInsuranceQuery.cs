using AutoMapper;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Insurances.Queries
{
    public class GetAllInsuranceQuery : IRequest<List<InsuranceResponse>>
    {
        public GetAllInsuranceQuery()
        {

        }
    }

    public class GetAllInsuranceQueryHandler : IRequestHandler<GetAllInsuranceQuery, List<InsuranceResponse>>
    {
        private readonly IInsuranceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllInsuranceQueryHandler(IInsuranceRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<InsuranceResponse>> Handle(GetAllInsuranceQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<InsuranceResponse>>(list);

            return listResult;
        }
    }

}
