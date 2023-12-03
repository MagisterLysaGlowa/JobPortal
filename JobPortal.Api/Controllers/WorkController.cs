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
    public class WorkController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Work
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWork()
        {
          if (_context.Work == null)
          {
              return NotFound();
          }
            return await _context.Work.ToListAsync();
        }

        // GET: api/Work/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
          if (_context.Work == null)
          {
              return NotFound();
          }
            var work = await _context.Work.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Work/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Work work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Work
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Work>> PostWork(Work work)
        {
          if (_context.Work == null)
          {
              return Problem("Entity set 'AppDbContext.Work'  is null.");
          }
            _context.Work.Add(work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        // DELETE: api/Work/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            if (_context.Work == null)
            {
                return NotFound();
            }
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Work.Remove(work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetWorkByUserId/{userId}")]
        public async Task<ActionResult<Work>> GetWorkByUserId(int userId)
        {
            try
            {
                var user = await _context.Work.Where(u => u.UserId == userId).FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(); 
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool WorkExists(int id)
        {
            return (_context.Work?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
