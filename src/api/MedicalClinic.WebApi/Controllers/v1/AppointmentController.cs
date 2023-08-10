using MediatR;
using MedicalClinic.Application.Features.Appointments.Queries;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public AppointmentController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Appointment>> GetAppointmentAsync()
        {
            var appointment = await _mediator.Send(new GetAllAppointmentQuery());

            return appointment;
        }
    }
}






