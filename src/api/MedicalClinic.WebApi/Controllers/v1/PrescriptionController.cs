using MediatR;
using MedicalClinic.Application.DTOs.Prescription;
using MedicalClinic.Application.Features.Prescriptions.Commands;
using MedicalClinic.Application.Features.Prescriptions.Queries;
using MedicalClinic.Application.Features.Prescriptions.SpecificCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllPrescriptionQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreatePrescriptionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet("Paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
        {
            var results = await _mediator.Send(new GetAllPagedPrescriptionQuery(pageNumber, pageSize));
            return Ok(results);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromQuery] PrescriptionRequestFilter filter)
        {
            var results = await _mediator.Send(new GetAllPrescriptionByFilterQuery(filter));
            return Ok(results);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPrescriptionByIdQuery() { Id = id });
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, UpdatePrescriptionCommand command)
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
            return Ok(await _mediator.Send(new DeletePrescriptionCommand { Id = id }));
        }

        //[HttpPost("ExportPrescriptionAsPDF")]
        //[AllowAnonymous]
        //public async Task<IActionResult> PostPdf(CreatePdfPrescriptionCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}






