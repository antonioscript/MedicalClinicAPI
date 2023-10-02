﻿using MediatR;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Features.Doctors.Commands;
using MedicalClinic.Application.Features.Doctors.Queries;
using MedicalClinic.Features.Doctors.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllDoctorQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateDoctorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet("Paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
        {
            var results = await _mediator.Send(new GetAllPagedDoctorQuery(pageNumber, pageSize));
            return Ok(results);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromQuery] DoctorRequestFilter filter)
        {
            var results = await _mediator.Send(new GetAllDoctorByFilterQuery(filter));
            return Ok(results);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDoctorByIdQuery() { Id = id });
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, UpdateDoctorCommand command)
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
            return Ok(await _mediator.Send(new DeleteDoctorCommand { Id = id }));
        }
    }
}






