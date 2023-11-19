using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using api_SIF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using api_SIF.Clases;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {

        private readonly RHDBContext _context;
        public PuestosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<puesto>>> GetPuestos()
        {
            var turnosLista = await _context.puestos.ToListAsync();

            return turnosLista;
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<puesto>> GetPuesto(string nombre)
        {
            var puesto = _context.puestos.FirstOrDefault<puesto>(x => x.nombre== nombre);

            return puesto;
        }
        [HttpPost]
        public async Task<ActionResult<puesto>> Postarea(PuestoRequest reqPuesto)
        {
            var entidadExistente = _context.puestos.SingleOrDefault(e => e.id_puesto == reqPuesto.id_puesto);
            if (entidadExistente == null)
            {
                var reqAreaN = new puesto()
                {
                    id_puesto = reqPuesto.id_puesto,
                    id_empleadoT = reqPuesto.id_empleadoT,
                    nombre = reqPuesto.nombre,
                };
                _context.puestos.Add(reqAreaN);
                _context.SaveChanges();
                reqPuesto.id_puesto = Funciones.ObtenerUltimoId<puesto>(_context);
            }
            else
            {
                reqPuesto.id_puesto = entidadExistente.id_puesto;
                entidadExistente.nombre = reqPuesto.nombre;
                entidadExistente.id_empleadoT = reqPuesto.id_empleadoT;
                _context.SaveChanges();

            }
            return Ok(new { id = reqPuesto.id_puesto });
        }
    }
}
