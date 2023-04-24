using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.EmpleadosN;
using api_SIF.dbContexts;
using api_SIF.Models.Empleados;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class checadoresController : ControllerBase
    {
        private readonly RHDBContext _context;

        public checadoresController(RHDBContext context)
        {
            _context = context;
        }

        // GET: api/checadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestChecador>>> Getchecadors()
        {
            var checadoresLista = from x in _context.checadors
                                 select new requestChecador()
                                 {

                                     id_checador = x.id_checador,
                                     nombre =x.nombre,
                                     serialNumber = x.serialNumber,
                                     id_sucursal= x.id_sucursal,
                                 };

            return await checadoresLista.ToListAsync();
        }

        // GET: api/checadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requestChecador>> Getchecador(int id)
        {
            var checador = await _context.checadors.FindAsync(id);

            if (checador == null)
            {
                return NotFound();
            }
            var reqChecador = new requestChecador()
            {
                id_checador = checador.id_checador,
                nombre = checador.nombre, serialNumber = checador.serialNumber,id_sucursal=checador.id_sucursal
      
            };


            return reqChecador;
        }

        // PUT: api/checadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putchecador(int id, checador checador)
        {
            if (id != checador.id_checador)
            {
                return BadRequest();
            }

            _context.Entry(checador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!checadorExists(id))
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

        // POST: api/checadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<checador>> Postchecador(checador checador)
        {
            _context.checadors.Add(checador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getchecador", new { id = checador.id_checador }, checador);
        }

        // DELETE: api/checadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletechecador(int id)
        {
            var checador = await _context.checadors.FindAsync(id);
            if (checador == null)
            {
                return NotFound();
            }

            _context.checadors.Remove(checador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool checadorExists(int id)
        {
            return _context.checadors.Any(e => e.id_checador == id);
        }
    }
}
