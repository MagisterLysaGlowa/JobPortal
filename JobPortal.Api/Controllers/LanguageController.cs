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
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LanguageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguage()
        {
          if (_context.Language == null)
          {
              return NotFound();
          }
            return await _context.Language.ToListAsync();
        }

        // GET: api/Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
          if (_context.Language == null)
          {
              return NotFound();
          }
            var language = await _context.Language.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // PUT: api/Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, Language language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Language>> PostLanguage(int userId,Language language)
        {
          if (_context.Language == null)
          {
              return Problem("Entity set 'AppDbContext.Language'  is null.");
          }
            _context.Language.Add(language);
            var user = _context.Users.Find(userId);
            user?.UserLanguages.Add(new UserLanguage { Language = language });

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguage", new { id = language.Id }, language);
        }

        [HttpGet("GetLanguagesForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguagesForUser(int id)
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            var languages = await _context.UserLanguage.Where(entity => entity.UserId == id).Select(entity => entity.Language).ToListAsync();

            if (languages == null)
            {
                return NotFound();
            }

            return languages!;
        }

        // DELETE: api/Language/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(int id)
        {
            return (_context.Language?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
