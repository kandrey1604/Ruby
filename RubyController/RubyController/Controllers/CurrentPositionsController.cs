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
    public class CurrentPositionsController : ControllerBase
    {
        private readonly RubyHome_DatabaseContext _context;

        public CurrentPositionsController(RubyHome_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CurrentPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentPosition>>> GetCurrentPositions()
        {
            return await _context.CurrentPositions.ToListAsync();
        }

        // GET: api/CurrentPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentPosition>> GetCurrentPosition(int id)
        {
            var currentPosition = await _context.CurrentPositions.FindAsync(id);

            if (currentPosition == null)
            {
                return NotFound();
            }

            return currentPosition;
        }

        // PUT: api/CurrentPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentPosition(int id, CurrentPosition currentPosition)
        {
            if (id != currentPosition.IdCurrentPosition)
            {
                return BadRequest();
            }

            _context.Entry(currentPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentPositionExists(id))
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

        // POST: api/CurrentPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CurrentPosition>> PostCurrentPosition(CurrentPosition currentPosition)
        {
            _context.CurrentPositions.Add(currentPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrentPosition", new { id = currentPosition.IdCurrentPosition }, currentPosition);
        }

        // DELETE: api/CurrentPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrentPosition(int id)
        {
            var currentPosition = await _context.CurrentPositions.FindAsync(id);
            if (currentPosition == null)
            {
                return NotFound();
            }

            _context.CurrentPositions.Remove(currentPosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrentPositionExists(int id)
        {
            return _context.CurrentPositions.Any(e => e.IdCurrentPosition == id);
        }
    }
}
