using Marko.Api.Mercury.Application.Features.Availabilities.Queries;
using Marko.Api.Mercury.Application.Features.Availabilities.SpecificQueries;
using MediatR;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Features.Availabilities.Commands;
using MedicalClinic.Application.Features.Availabilities.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvailabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllAvailabilityQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateAvailabilityCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet("Paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
        {
            var results = await _mediator.Send(new GetAllPagedAvailabilityQuery(pageNumber, pageSize));
            return Ok(results);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromQuery] AvailabilityRequestFilter filter)
        {
            var results = await _mediator.Send(new GetAllAvailabilityByFilterQuery(filter));
            return Ok(results);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAvailabilityByIdQuery() { Id = id });
            return Ok(result);
        }

        [HttpGet("Specific/{doctorId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByDoctorId(int doctorId)
        {
            var result = await _mediator.Send(new GetAvailabilityByIDoctordQuery() { DoctorId = doctorId });
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, UpdateAvailabilityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteAvailabilityCommand { Id = id }));
        }
    }
}






