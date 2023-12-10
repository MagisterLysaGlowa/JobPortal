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
    public class JobOfertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobOfertController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobOfert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOfert>>> GetJobOferts()
        {
          if (_context.JobOferts == null)
          {
              return NotFound();
          }
            return await _context.JobOferts.ToListAsync();
        }

        // GET: api/JobOfert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOfert>> GetJobOfert(int id)
        {
          if (_context.JobOferts == null)
          {
              return NotFound();
          }
            var jobOfert = await _context.JobOferts.FindAsync(id);

            if (jobOfert == null)
            {
                return NotFound();
            }

            return jobOfert;
        }

        // PUT: api/JobOfert/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOfert(int id, JobOfert jobOfert)
        {
            if (id != jobOfert.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOfert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfertExists(id))
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

        // POST: api/JobOfert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<JobOfert>> PostJobOfert(int userId,JobOfert jobOfert)
        {
          if (_context.JobOferts == null)
          {
              return Problem("Entity set 'AppDbContext.JobOferts'  is null.");
          }
            _context.JobOferts.Add(jobOfert);
            var user = _context.Users.Find(userId);
            user?.userJobOferts.Add(new UserJobOfert { JobOfert = jobOfert });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOfert", new { id = jobOfert.Id }, jobOfert);
        }

        // DELETE: api/JobOfert/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOfert(int id)
        {
            if (_context.JobOferts == null)
            {
                return NotFound();
            }
            var jobOfert = await _context.JobOferts.FindAsync(id);
            if (jobOfert == null)
            {
                return NotFound();
            }

            _context.JobOferts.Remove(jobOfert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOfertExists(int id)
        {
            return (_context.JobOferts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
