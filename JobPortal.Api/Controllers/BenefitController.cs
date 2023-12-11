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
    public class BenefitController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BenefitController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Benefit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Benefit>>> GetBenefit()
        {
          if (_context.Benefit == null)
          {
              return NotFound();
          }
            return await _context.Benefit.ToListAsync();
        }

        // GET: api/Benefit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Benefit>> GetBenefit(int id)
        {
          if (_context.Benefit == null)
          {
              return NotFound();
          }
            var benefit = await _context.Benefit.FindAsync(id);

            if (benefit == null)
            {
                return NotFound();
            }

            return benefit;
        }

        // PUT: api/Benefit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenefit(int id, Benefit benefit)
        {
            if (id != benefit.Id)
            {
                return BadRequest();
            }

            _context.Entry(benefit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitExists(id))
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

        // POST: api/Benefit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{jobOfertId}")]
        public async Task<ActionResult<Benefit>> PostBenefit(int jobOfertId, Benefit benefit)
        {
          if (_context.Benefit == null)
          {
              return Problem("Entity set 'AppDbContext.Benefit'  is null.");
          }
            _context.Benefit.Add(benefit);
            var jobOfert = _context.JobOferts.Find(jobOfertId);
            jobOfert?.JobOfertBenefits.Add(new JobOfertBenefit { Benefit = benefit });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenefit", new { id = benefit.Id }, benefit);
        }

        // DELETE: api/Benefit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            if (_context.Benefit == null)
            {
                return NotFound();
            }
            var benefit = await _context.Benefit.FindAsync(id);
            if (benefit == null)
            {
                return NotFound();
            }

            _context.Benefit.Remove(benefit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BenefitExists(int id)
        {
            return (_context.Benefit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
