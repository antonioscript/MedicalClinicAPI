using AutoMapper;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.CanceledAppointments.Queries
{
    public class GetAllCanceledAppointmentQuery : IRequest<List<CanceledAppointmentResponse>>
    {
        public GetAllCanceledAppointmentQuery()
        {

        }
    }

    public class GetAllCanceledAppointmentQueryHandler : IRequestHandler<GetAllCanceledAppointmentQuery, List<CanceledAppointmentResponse>>
    {
        private readonly ICanceledAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCanceledAppointmentQueryHandler(ICanceledAppointmentRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<CanceledAppointmentResponse>> Handle(GetAllCanceledAppointmentQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<CanceledAppointmentResponse>>(list);

            return listResult;
        }
    }

}
