using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyController.Models;

namespace RubyController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCardsController : ControllerBase
    {
        private readonly RubyHome_DatabaseContext _context;

        public UserCardsController(RubyHome_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCard>>> GetUserCards()
        {
            return await _context.UserCards.ToListAsync();
        }

        // GET: api/UserCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCard>> GetUserCard(int id)
        {
            var userCard = await _context.UserCards.FindAsync(id);

            if (userCard == null)
            {
                return NotFound();
            }

            return userCard;
        }

        // PUT: api/UserCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCard(int id, UserCard userCard)
        {
            if (id != userCard.IdUserCard)
            {
                return BadRequest();
            }

            _context.Entry(userCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCardExists(id))
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

        // POST: api/UserCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCard>> PostUserCard(UserCard userCard)
        {
            _context.UserCards.Add(userCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCard", new { id = userCard.IdUserCard }, userCard);
        }

        // DELETE: api/UserCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCard(int id)
        {
            var userCard = await _context.UserCards.FindAsync(id);
            if (userCard == null)
            {
                return NotFound();
            }

            _context.UserCards.Remove(userCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCardExists(int id)
        {
            return _context.UserCards.Any(e => e.IdUserCard == id);
        }
    }
}
