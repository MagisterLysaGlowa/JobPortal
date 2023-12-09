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
    public class LinkController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LinkController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Link
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLink()
        {
          if (_context.Link == null)
          {
              return NotFound();
          }
            return await _context.Link.ToListAsync();
        }

        // GET: api/Link/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(int id)
        {
          if (_context.Link == null)
          {
              return NotFound();
          }
            var link = await _context.Link.FindAsync(id);

            if (link == null)
            {
                return NotFound();
            }

            return link;
        }

        // PUT: api/Link/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLink(int id, Link link)
        {
            if (id != link.Id)
            {
                return BadRequest();
            }

            _context.Entry(link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
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

        // POST: api/Link
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Link>> PostLink(int userId,Link link)
        {
          if (_context.Link == null)
          {
              return Problem("Entity set 'AppDbContext.Link'  is null.");
          }
            _context.Link.Add(link);
            var user = _context.Users.Find(userId);
            user?.UserLinks.Add(new UserLink { Link = link });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLink", new { id = link.Id }, link);
        }

        [HttpGet("GetLinksForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinksForUser(int id)
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            var links = await _context.UserLink.Where(entity => entity.UserId == id).Select(entity => entity.Link).ToListAsync();

            if (links == null)
            {
                return NotFound();
            }

            return links!;
        }

        // DELETE: api/Link/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            if (_context.Link == null)
            {
                return NotFound();
            }
            var link = await _context.Link.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            _context.Link.Remove(link);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkExists(int id)
        {
            return (_context.Link?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
