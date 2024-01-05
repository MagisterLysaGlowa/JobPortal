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
    public class RequirementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequirementController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Requirement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requirement>>> GetRequirement()
        {
          if (_context.Requirement == null)
          {
              return NotFound();
          }
            return await _context.Requirement.ToListAsync();
        }

        // GET: api/Requirement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requirement>> GetRequirement(int id)
        {
          if (_context.Requirement == null)
          {
              return NotFound();
          }
            var requirement = await _context.Requirement.FindAsync(id);

            if (requirement == null)
            {
                return NotFound();
            }

            return requirement;
        }

        [HttpGet("GetRequirementsForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Requirement>>> GetRequirementsForUser(int id)
        {
            if (_context.Requirement == null)
            {
                return NotFound();
            }
            var requirements = await _context.JobOfertRequirement.Where(entity => entity.JobOfertId == id).Select(entity => entity.Requirement).ToListAsync();

            if (requirements == null)
            {
                return NotFound();
            }

            return requirements!;
        }

        // PUT: api/Requirement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequirement(int id, Requirement requirement)
        {
            if (id != requirement.Id)
            {
                return BadRequest();
            }

            _context.Entry(requirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequirementExists(id))
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

        // POST: api/Requirement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{jobOfertId}")]
        public async Task<ActionResult<Requirement>> PostRequirement(int jobOfertId,Requirement requirement)
        {
          if (_context.Requirement == null)
          {
              return Problem("Entity set 'AppDbContext.Requirement'  is null.");
          }
            _context.Requirement.Add(requirement);
            await _context.SaveChangesAsync();

            var jobOfert = _context.JobOferts.Find(jobOfertId);
            jobOfert?.JobOfertRequirements.Add(new JobOfertRequirement { Requirement = requirement });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequirement", new { id = requirement.Id }, requirement);
        }

        [HttpPost("AddAllRequirements/{jobOfertId}")]
        public async Task<ActionResult> AddAllRequirements(int jobOfertId, List<Requirement> requirements)
        {
            await Console.Out.WriteLineAsync($"tutaj jestem {requirements.Count}");
            if (_context.Requirement == null)
            {
                return Problem("Entity set 'AppDbContext.Requirement'  is null.");
            }

            var jobOfert = _context.JobOferts.Find(jobOfertId);

            foreach (var item in requirements)
            {
                _context.Requirement.Add(item);
                jobOfert?.JobOfertRequirements.Add(new JobOfertRequirement { Requirement = item });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Requirement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequirement(int id)
        {
            if (_context.Requirement == null)
            {
                return NotFound();
            }
            var requirement = await _context.Requirement.FindAsync(id);
            if (requirement == null)
            {
                return NotFound();
            }

            _context.Requirement.Remove(requirement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteRequirementByJobOfert/{jobOfertId}")]
        public async Task<IActionResult> DeleteRequirementByJobOfert(int jobOfertId)
        {
            if (_context.Requirement == null)
            {
                return NotFound();
            }
            var requirements = await _context.JobOfertRequirement.Where(entity => entity.JobOfertId == jobOfertId).Select(entity => entity.Requirement).ToListAsync();
            if (requirements == null)
            {
                return NotFound();
            }

            foreach (var item in requirements)
            {
                _context.JobOfertRequirement.Remove(await _context.JobOfertRequirement.Where(x => x.RequirementId == item.Id && x.JobOfertId == jobOfertId).FirstOrDefaultAsync());
                _context.Requirement.Remove(item);     
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequirementExists(int id)
        {
            return (_context.Requirement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
