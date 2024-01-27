using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Enums;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Patients.Queries
{
    public class GetAllPatientByFilterQuery : IRequest<Result<List<PatientResponse>>>
    {
        public PatientRequestFilter AppRequest { get; set; }

        public GetAllPatientByFilterQuery(PatientRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllPatientByFilterQueryHandler : IRequestHandler<GetAllPatientByFilterQuery, Result<List<PatientResponse>>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPatientByFilterQueryHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<PatientResponse>>> Handle(GetAllPatientByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.InsuranceId == null || p.InsuranceId == request.AppRequest.InsuranceId)
                       && (request.AppRequest.InsuranceType == null || p.InsuranceType == request.AppRequest.InsuranceType)
                       && (String.IsNullOrEmpty(request.AppRequest.FirstName) || p.FirstName.Contains(request.AppRequest.FirstName))
                       && (String.IsNullOrEmpty(request.AppRequest.LastName) || p.LastName.Contains(request.AppRequest.LastName))
                       && (String.IsNullOrEmpty(request.AppRequest.Document) || p.Document.Contains(request.AppRequest.Document))

                       && (request.AppRequest.DateOfBirth == null || p.DateOfBirth == request.AppRequest.DateOfBirth)
                       && (request.AppRequest.Gender == null || p.Gender == (PatientGenderCode)request.AppRequest.Gender)

                       && (String.IsNullOrEmpty(request.AppRequest.PhoneOne) || p.PhoneOne.Contains(request.AppRequest.PhoneOne))
                       && (String.IsNullOrEmpty(request.AppRequest.PhoneTwo) || p.PhoneTwo.Contains(request.AppRequest.PhoneTwo))
                       && (String.IsNullOrEmpty(request.AppRequest.Email) || p.Email.Contains(request.AppRequest.Email))
                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineOne) || p.AddressLineOne.Contains(request.AppRequest.AddressLineOne))
                       && (String.IsNullOrEmpty(request.AppRequest.AddressLineTwo) || p.AddressLineTwo.Contains(request.AppRequest.AddressLineTwo))
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<PatientResponse>>(list);
            return Result<List<PatientResponse>>.Success(listResult); ;
        }

    }
}