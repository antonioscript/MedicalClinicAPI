using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Technicians.Queries
{
    public class GetAllTechnicianByFilterQuery : IRequest<Result<List<TechnicianResponse>>>
    {
        public TechnicianRequestFilter AppRequest { get; set; }

        public GetAllTechnicianByFilterQuery(TechnicianRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllTechnicianByFilterQuery, Result<List<TechnicianResponse>>>
    {
        private readonly ITechnicianRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(ITechnicianRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<TechnicianResponse>>> Handle(GetAllTechnicianByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (String.IsNullOrEmpty(request.AppRequest.FirstName) || p.FirstName.Contains(request.AppRequest.FirstName))
                       && (String.IsNullOrEmpty(request.AppRequest.LastName) || p.LastName.Contains(request.AppRequest.LastName))
                       && (String.IsNullOrEmpty(request.AppRequest.Email) || p.Email.Contains(request.AppRequest.Email))
                       && (String.IsNullOrEmpty(request.AppRequest.Phone) || p.Phone.Contains(request.AppRequest.Phone))

                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineOne) || p.AddressLineOne.Contains(request.AppRequest.AddressLineOne))
                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineTwo) || p.AddressLineTwo.Contains(request.AppRequest.AddressLineTwo))
                       && (request.AppRequest.InsuranceType == null || p.InsuranceType == request.AppRequest.InsuranceType)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<TechnicianResponse>>(list);
            return Result<List<TechnicianResponse>>.Success(listResult); ;
        }

    }
}