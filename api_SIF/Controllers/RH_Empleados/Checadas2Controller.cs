using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.Empleados;
using api_SIF.dbContexts;

namespace api_SIF.Controllers.RH_Empleados
{
    [Route("RH_Empleados/[controller]")]
    [ApiController]
    public class Checadas2Controller : ControllerBase
    {
        private readonly EmpleadosContext _context;

        public Checadas2Controller(EmpleadosContext context)
        {
            _context = context;
        }

        // GET: api/Checadas2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checadas2>>> GetChecadas2()
        {
            return await _context.Checadas2.ToListAsync();
        }

        // GET: api/Checadas2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checadas2>> GetChecadas2(int id)
        {
            var checadas2 = await _context.Checadas2.FindAsync(id);

            if (checadas2 == null)
            {
                return NotFound();
            }

            return checadas2;
        }

        // PUT: api/Checadas2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecadas2(int id, Checadas2 checadas2)
        {
            if (id != checadas2.Id)
            {
                return BadRequest();
            }

            _context.Entry(checadas2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Checadas2Exists(id))
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

        // POST: api/Checadas2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Checadas2>> PostChecadas2(Checadas2 checadas2)
        {
            _context.Checadas2.Add(checadas2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChecadas2", new { id = checadas2.Id }, checadas2);
        }

        // DELETE: api/Checadas2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChecadas2(int id)
        {
            var checadas2 = await _context.Checadas2.FindAsync(id);
            if (checadas2 == null)
            {
                return NotFound();
            }

            _context.Checadas2.Remove(checadas2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Checadas2Exists(int id)
        {
            return _context.Checadas2.Any(e => e.Id == id);
        }
    }
}
