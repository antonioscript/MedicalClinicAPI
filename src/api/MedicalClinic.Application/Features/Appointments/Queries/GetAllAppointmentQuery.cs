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
    public class GetAllAppointmentQuery : IRequest<List<Appointment>>
    {
        public GetAllAppointmentQuery()
        {

        }
    }

    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, List<Appointment>>
    {
        private readonly IAppointmentRepository _repository;
        //private readonly IMapper _mapper;

        public GetAllAppointmentQueryHandler(IAppointmentRepository repository ) //, //IMapper mapper)
        {
            _repository = repository;
            //_mapper = mapper;
        }

        public async Task<List<Appointment>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAppointmentListAsync();
        }
    }

}
