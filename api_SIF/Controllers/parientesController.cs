using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class parientesController : ControllerBase
    {


        private readonly RHDBContext _context;
        public parientesController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pariente>>> GetParientes()
        {
            var parientesLista = _context.parientes;
            return await parientesLista.ToListAsync();
        }
        [HttpGet("{id_pariente}")]
        public async Task<ActionResult<pariente>> GetPariente(int id_pariente)
        {
            var parienteS = _context.parientes.SingleOrDefault(x => x.id_pariente == id_pariente);
            if (parienteS == null)
            {
                return NotFound();
            }

            return parienteS;
        }
        [HttpPost]
        public async Task<ActionResult<pariente>> PostPariente(pariente reqPariente)
        {
            var entidadExistente = _context.parientes.SingleOrDefault(e => e.id_pariente == reqPariente.id_pariente);
            if (entidadExistente == null)
            {
                _context.parientes.Add(reqPariente);
                _context.SaveChanges();
                reqPariente.id_empleado = Funciones.ObtenerUltimoId<pariente>(_context);
            }
            else
            {
                reqPariente.id_pariente = entidadExistente.id_pariente;
                entidadExistente.parentesco = reqPariente.parentesco;
                entidadExistente.id_empleadoP = reqPariente.id_empleadoP;

                _context.SaveChanges();
            }
            return Ok(new { id = reqPariente.id_pariente });
        }
    }
}
