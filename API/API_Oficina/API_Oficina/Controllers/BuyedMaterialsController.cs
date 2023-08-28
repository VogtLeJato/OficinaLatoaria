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
    public class BuyedMaterialsController : ControllerBase
    {
        private readonly OficinaContext _context;

        public BuyedMaterialsController(OficinaContext context)
        {
            _context = context;
        }

        // GET: api/BuyedMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyedMaterial>>> GetBuyedMaterials()
        {
          if (_context.BuyedMaterials == null)
          {
              return NotFound();
          }
            return await _context.BuyedMaterials.ToListAsync();
        }

        // GET: api/BuyedMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyedMaterial>> GetBuyedMaterial(int id)
        {
          if (_context.BuyedMaterials == null)
          {
              return NotFound();
          }
            var buyedMaterial = await _context.BuyedMaterials.FindAsync(id);

            if (buyedMaterial == null)
            {
                return NotFound();
            }

            return buyedMaterial;
        }

        // PUT: api/BuyedMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyedMaterial(int id, BuyedMaterial buyedMaterial)
        {
            if (id != buyedMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyedMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyedMaterialExists(id))
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

        // POST: api/BuyedMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuyedMaterial>> PostBuyedMaterial(BuyedMaterial buyedMaterial)
        {
          if (_context.BuyedMaterials == null)
          {
              return Problem("Entity set 'OficinaContext.BuyedMaterials'  is null.");
          }
            _context.BuyedMaterials.Add(buyedMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyedMaterial", new { id = buyedMaterial.Id }, buyedMaterial);
        }

        // DELETE: api/BuyedMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyedMaterial(int id)
        {
            if (_context.BuyedMaterials == null)
            {
                return NotFound();
            }
            var buyedMaterial = await _context.BuyedMaterials.FindAsync(id);
            if (buyedMaterial == null)
            {
                return NotFound();
            }

            _context.BuyedMaterials.Remove(buyedMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyedMaterialExists(int id)
        {
            return (_context.BuyedMaterials?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
