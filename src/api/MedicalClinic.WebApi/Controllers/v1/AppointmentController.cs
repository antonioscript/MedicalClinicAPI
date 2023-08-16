using MediatR;
using MedicalClinic.Application.Features.Appointments.Commands;
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
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllAppointmentQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateAppointmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }




        //[HttpGet("Paged")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
        //{
        //    var results = await _mediator.Send(new GetAllPagedCompetitorCompanyQuery(pageNumber, pageSize));
        //    return Ok(results);
        //}

        //[HttpGet("Filter")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetAllFilter([FromQuery] CompetitorCompanyRequestFilter filter)
        //{
        //    var results = await _mediator.Send(new GetAllCompetitorCompaniesByFilterQuery(filter));
        //    return Ok(results);
        //}

        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _mediator.Send(new GetCompetitorCompanyByIdQuery() { Id = id });
        //    return Ok(result);
        //}

        //// POST api/<controller>
        //[HttpPost]
        //[Authorize(Policy = Permissions.GeneralCommercialParam.Create)]
        ////[AllowAnonymous]
        //public async Task<IActionResult> Post(CreateCompetitorCompanyCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //[Authorize(Policy = Permissions.GeneralCommercialParam.Update)]
        ////[AllowAnonymous]
        //public async Task<IActionResult> Put(int id, UpdateCompetitorCompanyCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await _mediator.Send(command));
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //[Authorize(Policy = Permissions.GeneralCommercialParam.Delete)]
        ////[AllowAnonymous]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteCompetitorCompanyCommand { Id = id }));
        //}
    }
}






