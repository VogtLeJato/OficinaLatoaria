using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Oficina.Models;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypesController : ControllerBase
    {
        private readonly OficinaContext _context;

        public WorkTypesController(OficinaContext context)
        {
            _context = context;
        }

        // GET: api/WorkTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkType>>> GetWorkTypes()
        {
          if (_context.WorkTypes == null)
          {
              return NotFound();
          }
            return await _context.WorkTypes.ToListAsync();
        }

        // GET: api/WorkTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkType>> GetWorkType(int id)
        {
          if (_context.WorkTypes == null)
          {
              return NotFound();
          }
            var workType = await _context.WorkTypes.FindAsync(id);

            if (workType == null)
            {
                return NotFound();
            }

            return workType;
        }

        // PUT: api/WorkTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkType(int id, WorkType workType)
        {
            if (id != workType.Id)
            {
                return BadRequest();
            }

            _context.Entry(workType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTypeExists(id))
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

        // POST: api/WorkTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkType>> PostWorkType(WorkType workType)
        {
          if (_context.WorkTypes == null)
          {
              return Problem("Entity set 'OficinaContext.WorkTypes'  is null.");
          }
            _context.WorkTypes.Add(workType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkType", new { id = workType.Id }, workType);
        }

        // DELETE: api/WorkTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkType(int id)
        {
            if (_context.WorkTypes == null)
            {
                return NotFound();
            }
            var workType = await _context.WorkTypes.FindAsync(id);
            if (workType == null)
            {
                return NotFound();
            }

            _context.WorkTypes.Remove(workType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkTypeExists(int id)
        {
            return (_context.WorkTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
