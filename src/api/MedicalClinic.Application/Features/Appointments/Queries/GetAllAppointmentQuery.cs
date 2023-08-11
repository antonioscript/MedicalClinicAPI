using AutoMapper;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MedicalClinic.Application.Features.Appointments.Queries
{
    public class GetAllAppointmentQuery : IRequest<List<AppointmentResponse>>
    {
        public GetAllAppointmentQuery()
        {

        }
    }

    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, List<AppointmentResponse>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAppointmentQueryHandler(IAppointmentRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<AppointmentResponse>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<AppointmentResponse>>(list);

            return listResult;
        }
    }

}
