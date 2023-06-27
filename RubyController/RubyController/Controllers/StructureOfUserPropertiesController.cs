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
    public class StructureOfUserPropertiesController : ControllerBase
    {
        private readonly RubyHome_DatabaseContext _context;

        public StructureOfUserPropertiesController(RubyHome_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StructureOfUserProperties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StructureOfUserProperty>>> GetStructureOfUserProperties()
        {
            return await _context.StructureOfUserProperties.ToListAsync();
        }

        // GET: api/StructureOfUserProperties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StructureOfUserProperty>> GetStructureOfUserProperty(int id)
        {
            var structureOfUserProperty = await _context.StructureOfUserProperties.FindAsync(id);

            if (structureOfUserProperty == null)
            {
                return NotFound();
            }

            return structureOfUserProperty;
        }

        // PUT: api/StructureOfUserProperties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructureOfUserProperty(int id, StructureOfUserProperty structureOfUserProperty)
        {
            if (id != structureOfUserProperty.IdStructureOfUserProperty)
            {
                return BadRequest();
            }

            _context.Entry(structureOfUserProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureOfUserPropertyExists(id))
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

        // POST: api/StructureOfUserProperties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StructureOfUserProperty>> PostStructureOfUserProperty(StructureOfUserProperty structureOfUserProperty)
        {
            _context.StructureOfUserProperties.Add(structureOfUserProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStructureOfUserProperty", new { id = structureOfUserProperty.IdStructureOfUserProperty }, structureOfUserProperty);
        }

        // DELETE: api/StructureOfUserProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStructureOfUserProperty(int id)
        {
            var structureOfUserProperty = await _context.StructureOfUserProperties.FindAsync(id);
            if (structureOfUserProperty == null)
            {
                return NotFound();
            }

            _context.StructureOfUserProperties.Remove(structureOfUserProperty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StructureOfUserPropertyExists(int id)
        {
            return _context.StructureOfUserProperties.Any(e => e.IdStructureOfUserProperty == id);
        }
    }
}
