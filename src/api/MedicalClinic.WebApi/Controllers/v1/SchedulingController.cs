using MediatR;
using MedicalClinic.Application.DTOs.Scheduling;
using MedicalClinic.Application.Features.Schedulings.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulingController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromQuery] SchedulingRequestFilter filter)
        {
            var results = await _mediator.Send(new GetAllSchedulingByFilterQuery(filter));
            return Ok(results);
        }


    }
}






