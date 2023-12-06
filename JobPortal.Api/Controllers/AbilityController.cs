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
    public class AbilityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AbilityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ability
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbility()
        {
          if (_context.Ability == null)
          {
              return NotFound();
          }
            return await _context.Ability.ToListAsync();
        }

        // GET: api/Ability/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ability>> GetAbility(int id)
        {
          if (_context.Ability == null)
          {
              return NotFound();
          }
            var ability = await _context.Ability.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }

        // PUT: api/Ability/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbility(int id, Ability ability)
        {
            if (id != ability.Id)
            {
                return BadRequest();
            }

            _context.Entry(ability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(id))
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

        // POST: api/Ability
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Ability>> PostAbility(int userId,Ability ability)
        {
          if (_context.Ability == null)
          {
              return Problem("Entity set 'AppDbContext.Ability'  is null.");
          }
            _context.Ability.Add(ability);

            var user = _context.Users.Find(userId);
            user?.UserAbilities.Add(new UserAbility { Ability = ability });

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbility", new { id = ability.Id }, ability);
        }

        [HttpGet("GetAbilitiesForUser/{id}")]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbilitiesForUser(int id)
        {
            if (_context.Ability == null)
            {
                return NotFound();
            }
            var abilities = await _context.UserAbility.Where(entity => entity.UserId == id).Select(entity => entity.Ability).ToListAsync();

            if (abilities == null)
            {
                return NotFound();
            }

            return abilities!;
        }

        // DELETE: api/Ability/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbility(int id)
        {
            if (_context.Ability == null)
            {
                return NotFound();
            }
            var ability = await _context.Ability.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }

            _context.Ability.Remove(ability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilityExists(int id)
        {
            return (_context.Ability?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
