using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Api.Data;
using JobPortal.Api.Models;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DutyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Duty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duty>>> GetDuty()
        {
          if (_context.Duty == null)
          {
              return NotFound();
          }
            return await _context.Duty.ToListAsync();
        }

        // GET: api/Duty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duty>> GetDuty(int id)
        {
          if (_context.Duty == null)
          {
              return NotFound();
          }
            var duty = await _context.Duty.FindAsync(id);

            if (duty == null)
            {
                return NotFound();
            }

            return duty;
        }

        // PUT: api/Duty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuty(int id, Duty duty)
        {
            if (id != duty.Id)
            {
                return BadRequest();
            }

            _context.Entry(duty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DutyExists(id))
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

        // POST: api/Duty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{jobOfertId}")]
        public async Task<ActionResult<Duty>> PostDuty(int jobOfertId,Duty duty)
        {
          if (_context.Duty == null)
          {
              return Problem("Entity set 'AppDbContext.Duty'  is null.");
          }
            _context.Duty.Add(duty);
            var jobOfert = _context.JobOferts.Find(jobOfertId);
            jobOfert?.JobOfertDuties.Add(new JobOfertDuty { Duty = duty });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuty", new { id = duty.Id }, duty);
        }

        // DELETE: api/Duty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuty(int id)
        {
            if (_context.Duty == null)
            {
                return NotFound();
            }
            var duty = await _context.Duty.FindAsync(id);
            if (duty == null)
            {
                return NotFound();
            }

            _context.Duty.Remove(duty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DutyExists(int id)
        {
            return (_context.Duty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
