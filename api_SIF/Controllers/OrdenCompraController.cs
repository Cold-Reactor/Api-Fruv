using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.Bodega;
using api_SIF.dbContexts;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly BodegaDBContext _context;

        public OrdenCompraController(BodegaDBContext context)
        {
            _context = context;
        }

        // GET: api/ordencompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ordencompra>>> Getordencompra()
        {
            return await _context.ordencompra.ToListAsync();
        }

        // GET: api/ordencompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ordencompra>> Getordencompra(int id)
        {
            var ordencompra = await _context.ordencompra.FindAsync(id);

            if (ordencompra == null)
            {
                return NotFound();
            }

            return ordencompra;
        }

        // PUT: api/ordencompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putordencompra(int id, ordencompra ordencompra2)
        {

            var entity = _context.ordencompra.FirstOrDefault(x => x.id == id);

            // Validate entity is not null
            if (entity != null)
            {
                // Answer for question #2

                // Make changes on entity
                entity = ordencompra2;

                await _context.SaveChangesAsync();
            }
            /*
            if (id != ordencompra.id)
            {
                return BadRequest();
            }

            _context.Entry(ordencompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ordencompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ordencompra);
            */

            return Ok(entity);
        }

        // POST: api/ordencompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ordencompra>> Postordencompra(ordencompra ordencompra)
        {
            _context.ordencompra.Add(ordencompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getordencompra", new { id = ordencompra.id }, ordencompra);
        }

        // DELETE: api/ordencompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteordencompra(int id)
        {
            var ordencompra = await _context.ordencompra.FindAsync(id);
            if (ordencompra == null)
            {
                return NotFound();
            }

            _context.ordencompra.Remove(ordencompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ordencompraExists(int id)
        {
            return _context.ordencompra.Any(e => e.id == id);
        }
    }
}
