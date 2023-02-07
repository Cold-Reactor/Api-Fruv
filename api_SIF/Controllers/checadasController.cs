using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.EmpleadosN;
using api_SIF.dbContexts;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class checadasController : ControllerBase
    {
        private readonly RHDBContext _context;

        public checadasController(RHDBContext context)
        {
            _context = context;
        }

        // GET: api/checadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestChecadas>>> Getchecadas()
        {

            var checadoresLista = from x in _context.checadas
                                  select new requestChecadas()
                                  {

                                      id_checador = x.id_checador,
                                     nomina= x.nomina,
                                     fecha= x.fecha,
                                     fechaHora= x.fechaHora,
                                     hora= x.hora,  
                                     id_checadas = x.id_checadas    ,
                                     id_empleado = x.id_empleado,
                                     
                                     
                                  };
            return await checadoresLista.ToListAsync();
        }

        // GET: api/checadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requestChecadas>> Getchecada(int id)
        {
            var checada = await _context.checadas.FindAsync(id);

            if (checada == null)
            {
                return NotFound();
            }
            var reqChecada =  new requestChecadas()
            {

                id_checador = checada.id_checador,
                nomina = checada.nomina,
                fecha = checada.fecha,
                fechaHora = checada.fechaHora,
                hora = checada.hora,
                id_checadas = checada.id_checadas,
                id_empleado = checada.id_empleado,


            };
            return reqChecada;
        }

        // PUT: api/checadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putchecada(int id, checada checada)
        {
            if (id != checada.id_checadas)
            {
                return BadRequest();
            }

            _context.Entry(checada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!checadaExists(id))
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

        // POST: api/checadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<checada>> Postchecada(checada checada)
        {
            _context.checadas.Add(checada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getchecada", new { id = checada.id_checadas }, checada);
        }

        // DELETE: api/checadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletechecada(int id)
        {
            var checada = await _context.checadas.FindAsync(id);
            if (checada == null)
            {
                return NotFound();
            }

            _context.checadas.Remove(checada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool checadaExists(int id)
        {
            return _context.checadas.Any(e => e.id_checadas == id);
        }
    }
}
