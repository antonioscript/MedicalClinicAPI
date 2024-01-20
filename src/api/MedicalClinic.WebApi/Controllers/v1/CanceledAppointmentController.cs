using MediatR;
using MedicalClinic.Application.DTOs.CanceledAppointment;
using MedicalClinic.Application.Features.CanceledAppointments.Commands;
using MedicalClinic.Application.Features.CanceledAppointments.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanceledAppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CanceledAppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllCanceledAppointmentQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateCanceledAppointmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet("Paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
        {
            var results = await _mediator.Send(new GetAllPagedCanceledAppointmentQuery(pageNumber, pageSize));
            return Ok(results);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromQuery] CanceledAppointmentRequestFilter filter)
        {
            var results = await _mediator.Send(new GetAllCanceledAppointmentByFilterQuery(filter));
            return Ok(results);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCanceledAppointmentByIdQuery() { Id = id });
            return Ok(result);
        }
    }
}






