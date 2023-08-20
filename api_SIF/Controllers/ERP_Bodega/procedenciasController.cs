using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.Bodega;
using api_SIF.dbContexts;

namespace api_SIF.Controllers.ERP_Bodega
{
    [Route("ERP_Bodega/[controller]")]
    [ApiController]
    public class procedenciasController : ControllerBase
    {
        private readonly BodegaDBContext _context;

        public procedenciasController(BodegaDBContext context)
        {
            _context = context;
        }

        // GET: api/procedencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<procedencias>>> Getprocedencia()
        {
            return await _context.procedencia.ToListAsync();
        }

        // GET: api/procedencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<procedencias>> Getprocedencias(int id)
        {
            var procedencias = await _context.procedencia.FindAsync(id);

            if (procedencias == null)
            {
                return NotFound();
            }

            return procedencias;
        }

        // PUT: api/procedencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprocedencias(int id, procedencias procedencias)
        {
            if (id != procedencias.id)
            {
                return BadRequest();
            }

            _context.Entry(procedencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!procedenciasExists(id))
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

        // POST: api/procedencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<procedencias>> Postprocedencias(procedencias procedencias)
        {
            _context.procedencia.Add(procedencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprocedencias", new { id = procedencias.id }, procedencias);
        }

        // DELETE: api/procedencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprocedencias(int id)
        {
            var procedencias = await _context.procedencia.FindAsync(id);
            if (procedencias == null)
            {
                return NotFound();
            }

            _context.procedencia.Remove(procedencias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool procedenciasExists(int id)
        {
            return _context.procedencia.Any(e => e.id == id);
        }
    }
}
