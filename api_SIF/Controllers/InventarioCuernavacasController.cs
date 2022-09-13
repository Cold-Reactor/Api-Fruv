using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models;
using api_SIF.dbContexts;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioCuernavacasController : ControllerBase
    {
        private readonly MyDBContext _context;

        public InventarioCuernavacasController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/InventarioCuernavacas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioCuernavaca>>> GetInventarioCuernavaca()
        {
            return await _context.InventarioCuernavaca.ToListAsync();
        }

        // GET: api/InventarioCuernavacas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioCuernavaca>> GetInventarioCuernavaca(int id)
        {
            var inventarioCuernavaca = await _context.InventarioCuernavaca.FindAsync(id);

            if (inventarioCuernavaca == null)
            {
                return NotFound();
            }

            return inventarioCuernavaca;
        }

        // PUT: api/InventarioCuernavacas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarioCuernavaca(int id, InventarioCuernavaca inventarioCuernavaca)
        {
            if (id != inventarioCuernavaca.idConsecutivo)
            {
                return BadRequest();
            }

            _context.Entry(inventarioCuernavaca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioCuernavacaExists(id))
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

        // POST: api/InventarioCuernavacas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventarioCuernavaca>> PostInventarioCuernavaca(InventarioCuernavaca inventarioCuernavaca)
        {
            _context.InventarioCuernavaca.Add(inventarioCuernavaca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventarioCuernavaca", new { id = inventarioCuernavaca.idConsecutivo }, inventarioCuernavaca);
        }

        // DELETE: api/InventarioCuernavacas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventarioCuernavaca>> DeleteInventarioCuernavaca(int id)
        {
            var inventarioCuernavaca = await _context.InventarioCuernavaca.FindAsync(id);
            if (inventarioCuernavaca == null)
            {
                return NotFound();
            }

            _context.InventarioCuernavaca.Remove(inventarioCuernavaca);
            await _context.SaveChangesAsync();

            return inventarioCuernavaca;
        }

        private bool InventarioCuernavacaExists(int id)
        {
            return _context.InventarioCuernavaca.Any(e => e.idConsecutivo == id);
        }
    }
}
