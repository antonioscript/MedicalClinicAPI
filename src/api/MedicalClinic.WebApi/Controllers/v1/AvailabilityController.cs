using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Availability
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvailability()
        {
            if (_context.Availabilities == null)
            {
                return NotFound();
            }
            return Ok(await _context.Availabilities.ToListAsync());
        }

        // GET: api/Availability/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Availability>> GetAvailability(int id)
        {
            if (_context.Availabilities == null)
            {
                return NotFound();
            }
            var Availability = await _context.Availabilities.FindAsync(id);

            if (Availability == null)
            {
                return NotFound();
            }

            return Ok(Availability);
        }

        // PUT: api/Availability/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailability(int id, Availability Availability)
        {
            if (id != Availability.AvailabilityId)
            {
                return BadRequest();
            }

            _context.Entry(Availability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Availability
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Availability>> PostAvailability(Availability Availability)
        {
            if (_context == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Availability'  is null.");
            }
            _context.Availabilities.Add(Availability);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvailability), new { id = Availability.AvailabilityId }, Availability);
        }

        // DELETE: api/Availability/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(int id)
        {
            if (_context.Availabilities == null)
            {
                return NotFound();
            }
            var Availability = await _context.Availabilities.FindAsync(id);
            if (Availability == null)
            {
                return NotFound();
            }

            _context.Availabilities.Remove(Availability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvailabilityExists(int id)
        {
            return (_context.Availabilities?.Any(e => e.AvailabilityId == id)).GetValueOrDefault();
        }
    }
}
