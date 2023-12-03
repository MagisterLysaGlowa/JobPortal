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
    public class CarrierController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarrierController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carrier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarrier()
        {
          if (_context.Carrier == null)
          {
              return NotFound();
          }
            return await _context.Carrier.ToListAsync();
        }

        // GET: api/Carrier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrier>> GetCarrier(int? id)
        {
          if (_context.Carrier == null)
          {
              return NotFound();
          }
            var carrier = await _context.Carrier.FindAsync(id);

            if (carrier == null)
            {
                return NotFound();
            }

            return carrier;
        }

        // PUT: api/Carrier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrier(int? id, Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierExists(id))
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

        // POST: api/Carrier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
          if (_context.Carrier == null)
          {
              return Problem("Entity set 'AppDbContext.Carrier'  is null.");
          }

            _context.Carrier.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.Id }, carrier);
        }

        // DELETE: api/Carrier/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int? id)
        {
            if (_context.Carrier == null)
            {
                return NotFound();
            }
            var carrier = await _context.Carrier.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }

            _context.Carrier.Remove(carrier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetCarrierByUserId/{userId}")]
        public async Task<ActionResult<Work>> GetCarrierByUserId(int userId)
        {
            try
            {
                var user = await _context.Carrier.Where(u => u.UserId == userId).FirstOrDefaultAsync();

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
        private bool CarrierExists(int? id)
        {
            return (_context.Carrier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
