using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Scheduling;
using MedicalClinic.Application.Enums;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Schedulings.Queries
{
    public class GetAllSchedulingByFilterQuery : IRequest<Result<List<SchedulingResponse>>>
    {
        public SchedulingRequestFilter AppRequest { get; set; }

        public GetAllSchedulingByFilterQuery(SchedulingRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllSchedulingByFilterQueryHandler : IRequestHandler<GetAllSchedulingByFilterQuery, Result<List<SchedulingResponse>>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;

        public GetAllSchedulingByFilterQueryHandler(IAppointmentRepository appointmentRepository, IProcedureRepository procedureRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<SchedulingResponse>>> Handle(GetAllSchedulingByFilterQuery request, CancellationToken cancellationToken)
        {
            // Pegar todas as consultas do paciente
            var allAppointmentPatient = await _appointmentRepository.Entities
                .Include(p => p.Patient)
                .Where(a =>
                    //a.PatientId == request.AppRequest.PatientId ||
                    (string.IsNullOrEmpty(request.AppRequest.ColumnsFilter) ||
                        a.Patient.FirstName.Contains(request.AppRequest.ColumnsFilter) ||
                        a.Patient.LastName.Contains(request.AppRequest.ColumnsFilter))
                )
                .AsNoTracking()
                .ToListAsync();



            var schedulingList = new List<SchedulingResponse>();

            foreach(var appointment in allAppointmentPatient) 
            { 
                var scheduling = new SchedulingResponse();

                scheduling.Id = appointment.Id;
                scheduling.PatientId = appointment.PatientId;
                scheduling.PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}";
                scheduling.SchedulingType = SchedulingCodeDto.Appointment;
                scheduling.SchedulingDate = appointment.AppointmentDate;
                scheduling.Status = (StatusCodeDto)appointment.Status;
                scheduling.Observation = appointment.Observation;

                schedulingList.Add(scheduling);
            }


            // Pegar todos os procedimentos do paciente
            var allProcedurePatient = await _procedureRepository.Entities
                .Include(p => p.Patient)
                .Where(a =>
                    //a.PatientId == request.AppRequest.PatientId ||
                    a.Patient.FirstName.Contains(request.AppRequest.ColumnsFilter) ||
                    a.Patient.LastName.Contains(request.AppRequest.ColumnsFilter)
                )
                .AsNoTracking()
                .ToListAsync();


            foreach (var procedure in allProcedurePatient)
            {
                var scheduling = new SchedulingResponse();

                scheduling.Id = procedure.Id;
                scheduling.PatientId = procedure.PatientId;
                scheduling.PatientName = $"{procedure.Patient.FirstName} {procedure.Patient.LastName}";
                scheduling.SchedulingType = SchedulingCodeDto.Procedure;
                scheduling.SchedulingDate = procedure.ProcedureDate;
                scheduling.Status = (StatusCodeDto)procedure.Status;
                scheduling.Observation = procedure.Observation;

                schedulingList.Add(scheduling);
            }

            //Aplicação do Filtro
            var test = schedulingList
                .Where(c =>
                          (request.AppRequest.SchedulingDate == null || c.SchedulingDate == request.AppRequest.SchedulingDate)
                          && (request.AppRequest.Status == null || c.Status == request.AppRequest.Status)
                          && (request.AppRequest.SchedulingType == null || c.SchedulingType == request.AppRequest.SchedulingType)
                       )
                .ToList();

            //var listResult = _mapper.Map<List<SchedulingResponse>>(list);
            return Result<List<SchedulingResponse>>.Success(test); ;
        }

    }
}