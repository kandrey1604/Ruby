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
    public class TypePropertiesController : ControllerBase
    {
        private readonly RubyHome_DatabaseContext _context;

        public TypePropertiesController(RubyHome_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TypeProperties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProperty>>> GetTypeProperties()
        {
            return await _context.TypeProperties.ToListAsync();
        }

        // GET: api/TypeProperties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeProperty>> GetTypeProperty(int id)
        {
            var typeProperty = await _context.TypeProperties.FindAsync(id);

            if (typeProperty == null)
            {
                return NotFound();
            }

            return typeProperty;
        }

        // PUT: api/TypeProperties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeProperty(int id, TypeProperty typeProperty)
        {
            if (id != typeProperty.IdTypeProperty)
            {
                return BadRequest();
            }

            _context.Entry(typeProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePropertyExists(id))
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

        // POST: api/TypeProperties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeProperty>> PostTypeProperty(TypeProperty typeProperty)
        {
            _context.TypeProperties.Add(typeProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeProperty", new { id = typeProperty.IdTypeProperty }, typeProperty);
        }

        // DELETE: api/TypeProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeProperty(int id)
        {
            var typeProperty = await _context.TypeProperties.FindAsync(id);
            if (typeProperty == null)
            {
                return NotFound();
            }

            _context.TypeProperties.Remove(typeProperty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypePropertyExists(int id)
        {
            return _context.TypeProperties.Any(e => e.IdTypeProperty == id);
        }
    }
}
