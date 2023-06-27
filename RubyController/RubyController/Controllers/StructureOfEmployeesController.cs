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
    public class StructureOfEmployeesController : ControllerBase
    {
        private readonly RubyHome_DatabaseContext _context;

        public StructureOfEmployeesController(RubyHome_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StructureOfEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StructureOfEmployee>>> GetStructureOfEmployees()
        {
            return await _context.StructureOfEmployees.ToListAsync();
        }

        // GET: api/StructureOfEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StructureOfEmployee>> GetStructureOfEmployee(int id)
        {
            var structureOfEmployee = await _context.StructureOfEmployees.FindAsync(id);

            if (structureOfEmployee == null)
            {
                return NotFound();
            }

            return structureOfEmployee;
        }

        // PUT: api/StructureOfEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructureOfEmployee(int id, StructureOfEmployee structureOfEmployee)
        {
            if (id != structureOfEmployee.IdStructureOfEmployee)
            {
                return BadRequest();
            }

            _context.Entry(structureOfEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureOfEmployeeExists(id))
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

        // POST: api/StructureOfEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StructureOfEmployee>> PostStructureOfEmployee(StructureOfEmployee structureOfEmployee)
        {
            _context.StructureOfEmployees.Add(structureOfEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStructureOfEmployee", new { id = structureOfEmployee.IdStructureOfEmployee }, structureOfEmployee);
        }

        // DELETE: api/StructureOfEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStructureOfEmployee(int id)
        {
            var structureOfEmployee = await _context.StructureOfEmployees.FindAsync(id);
            if (structureOfEmployee == null)
            {
                return NotFound();
            }

            _context.StructureOfEmployees.Remove(structureOfEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StructureOfEmployeeExists(int id)
        {
            return _context.StructureOfEmployees.Any(e => e.IdStructureOfEmployee == id);
        }
    }
}
