using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Features.Appointments.Queries
{
    public class GetAllAppointmentByFilterQuery : IRequest<Result<List<AppointmentResponse>>>
    {
        public AppointmentRequestFilter AppRequest { get; set; }

        public GetAllAppointmentByFilterQuery(AppointmentRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllAppointmentByFilterQuery, Result<List<AppointmentResponse>>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<AppointmentResponse>>> Handle(GetAllAppointmentByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (request.AppRequest.PatientId == null || p.PatientId == request.AppRequest.PatientId)
                       && (request.AppRequest.DoctorId == null || p.DoctorId == request.AppRequest.DoctorId)
                       && (request.AppRequest.Status == null || p.Status == (AppointmentStatusCode)request.AppRequest.Status)
                       && (String.IsNullOrEmpty(request.AppRequest.Observation) || p.Observation.Contains(request.AppRequest.Observation))
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<AppointmentResponse>>(list);
            return Result<List<AppointmentResponse>>.Success(listResult); ;
        }

    }
}