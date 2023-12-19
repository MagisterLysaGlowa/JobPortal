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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetUserJobOfertApplications/{userId}")]
        public async Task<ActionResult<UserJobOfertApplication>> GetUserJobOfertApplications(int userId)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userJobOfertApplications = await _context.UserJobOfertApplication.Where(x => x.UserId == userId).ToListAsync();



            if (userJobOfertApplications == null)
            {
                return NotFound();
            }

            return Ok(userJobOfertApplications);
        }

        [HttpGet("GetUserJobOfertFavourites/{userId}")]
        public async Task<ActionResult<UserJobOfertApplication>> GetUserJobOfertFavourites(int userId)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userJobOfertApplications = await _context.UserJobOfertsFavourite.Where(x => x.UserId == userId).ToListAsync();



            if (userJobOfertApplications == null)
            {
                return NotFound();
            }

            return Ok(userJobOfertApplications);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.Users'  is null.");
            }
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password,13);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("PostUserJobOfertApplication/{userId}")]
        public async Task<ActionResult<User>> PostUserJobOfertApplication(int userId, JobOfert jobOfert)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.JobOferts'  is null.");
            }

            if(_context.UserJobOfertApplication.Any(x => x.UserId == userId && x.JobOfertId == jobOfert.Id))
            {
                return NoContent();
            }

            jobOfert.JobOfertCategories = new();
            var user = _context.Users.Find(userId);
            user?.UserJobOfertsApplications.Add(new UserJobOfertApplication { JobOfert = jobOfert , CreatedAt = DateTime.Now});
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("PostUserJobOfertFavourite/{userId}")]
        public async Task<ActionResult<User>> PostUserJobOfertFavourite(int userId, JobOfert jobOfert)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.JobOferts'  is null.");
            }

            if (_context.UserJobOfertsFavourite.Any(x => x.UserId == userId && x.JobOfertId == jobOfert.Id))
            {
                return NoContent();
            }

            jobOfert.JobOfertCategories = new();
            var user = _context.Users.Find(userId);
            user?.UserJobOfertsFavourites.Add(new UserJobOfertFavourite { JobOfert = jobOfert});
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("IsUserEmailFree/{email}")]
        public async Task<ActionResult<bool>> IsEmailFree(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return BadRequest(); 
            }
            var userExist = await _context.Users.AnyAsync(x => x.Email == email);
            return Ok(!userExist);
        }

        [HttpGet("IsUserPhoneFree/{phone}")]
        public async Task<ActionResult<bool>> IsPhoneFree(string phone)
        {
            if (String.IsNullOrWhiteSpace(phone))
            {
                return BadRequest();
            }
            var userExist = await _context.Users.AnyAsync(x => x.PhoneNumber == phone);
            return Ok(!userExist);
        }

        [HttpGet("Login/{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            if(email is not null && password is not null)
            {
                var user = await _context.Users
                    .Where(x => x.Email!
                    .ToLower()
                    .Equals(email
                    .ToLower()))
                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    return NotFound("Niepoprawny adres e-mail");
                }
                bool passwordHashCorrect = BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password);
                return passwordHashCorrect ? Ok(user) : NotFound("Niepoprawne hasło");

            }
            return BadRequest("Invalid Request");
        }

        [HttpDelete("deleteUserJobOfertApplication/{userId}/{jobOfertId}")]
        public IActionResult RemoveUserJobOfertApplication(int userId, int jobOfertId)
        {
            var userJobOfert = _context.UserJobOfertApplication
                .FirstOrDefault(sc => sc.UserId == userId && sc.JobOfertId == jobOfertId);

            if (userJobOfert != null)
            {
                _context.UserJobOfertApplication.Remove(userJobOfert);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete("deleteUserJobOfertFavourite/{userId}/{jobOfertId}")]
        public IActionResult deleteUserJobOfertFavourite(int userId, int jobOfertId)
        {
            var userJobOfert = _context.UserJobOfertsFavourite
                .FirstOrDefault(sc => sc.UserId == userId && sc.JobOfertId == jobOfertId);

            if (userJobOfert != null)
            {
                _context.UserJobOfertsFavourite.Remove(userJobOfert);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
