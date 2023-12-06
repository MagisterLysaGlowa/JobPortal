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
    public class ExperienceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Experience
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperience()
        {
          if (_context.Experience == null)
          {
              return NotFound();
          }
            return await _context.Experience.ToListAsync();
        }

        // GET: api/Experience/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
          if (_context.Experience == null)
          {
              return NotFound();
          }
            var experience = await _context.Experience.FindAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            return experience;
        }

        [HttpGet("GetExperiencesForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperiencesForUser(int id)
        {
            if (_context.Experience == null)
            {
                return NotFound();
            }
            var experience = await _context.UserExperience.Where(ur => ur.UserId == id).Select(ur => ur.Experience).ToListAsync();

            if (experience == null)
            {
                return NotFound();
            }

            return experience!;
        }

        // PUT: api/Experience/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(int id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experience
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Experience>> PostExperience(int userId,Experience experience)
        {
          if (_context.Experience == null)
          {
              return Problem("Entity set 'AppDbContext.Experience'  is null.");
          }
            _context.Experience.Add(experience);

            var user = _context.Users.Find(userId);
            user?.UserExperiences.Add( new UserExperience { Experience = experience });

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = experience.Id }, experience);
        }

        // DELETE: api/Experience/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            if (_context.Experience == null)
            {
                return NotFound();
            }
            var experience = await _context.Experience.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienceExists(int id)
        {
            return (_context.Experience?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
