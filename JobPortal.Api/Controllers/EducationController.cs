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
    public class EducationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EducationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Education
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducation()
        {
          if (_context.Education == null)
          {
              return NotFound();
          }
            return await _context.Education.ToListAsync();
        }

        // GET: api/Education/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
          if (_context.Education == null)
          {
              return NotFound();
          }
            var education = await _context.Education.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return education;
        }

        // PUT: api/Education/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, Education education)
        {
            if (id != education.Id)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Education
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Education>> PostEducation(int userId,Education education)
        {
          if (_context.Education == null)
          {
              return Problem("Entity set 'AppDbContext.Education'  is null.");
          }
            _context.Education.Add(education);

            var user = _context.Users.Find(userId);
            user?.UserEducations.Add(new UserEducation { Education = education });

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEducation", new { id = education.Id }, education);
        }

        [HttpGet("GetEducationsForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducationsForUser(int id)
        {
            if (_context.Education == null)
            {
                return NotFound();
            }
            var educations = await _context.UserEducation.Where(entity => entity.UserId == id).Select(entity => entity.Education).ToListAsync();

            if (educations == null)
            {
                return NotFound();
            }

            return educations!;
        }

        // DELETE: api/Education/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            if (_context.Education == null)
            {
                return NotFound();
            }
            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationExists(int id)
        {
            return (_context.Education?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
