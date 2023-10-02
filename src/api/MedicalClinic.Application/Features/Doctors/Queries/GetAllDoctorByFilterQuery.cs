using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Doctors.Queries
{
    public class GetAllDoctorByFilterQuery : IRequest<Result<List<DoctorResponse>>>
    {
        public DoctorRequestFilter AppRequest { get; set; }

        public GetAllDoctorByFilterQuery(DoctorRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllDoctorByFilterQuery, Result<List<DoctorResponse>>>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<DoctorResponse>>> Handle(GetAllDoctorByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.SpecialtyId == null || p.SpecialtyId == request.AppRequest.SpecialtyId)
                       && (String.IsNullOrEmpty(request.AppRequest.Crm) || p.Crm.Contains(request.AppRequest.Crm))
                       && (String.IsNullOrEmpty(request.AppRequest.FirstName) || p.FirstName.Contains(request.AppRequest.FirstName))
                       && (String.IsNullOrEmpty(request.AppRequest.LastName) || p.LastName.Contains(request.AppRequest.LastName))

                       && (String.IsNullOrEmpty(request.AppRequest.Phone) || p.Phone.Contains(request.AppRequest.Phone))
                       && (String.IsNullOrEmpty(request.AppRequest.Email) || p.Email.Contains(request.AppRequest.Email))
                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineOne) || p.AddressLineOne.Contains(request.AppRequest.AddressLineOne))
                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineTwo) || p.AddressLineTwo.Contains(request.AppRequest.AddressLineTwo))

                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<DoctorResponse>>(list);
            return Result<List<DoctorResponse>>.Success(listResult); ;
        }

    }
}