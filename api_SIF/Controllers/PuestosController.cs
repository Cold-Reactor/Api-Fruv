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
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuestos()
        {
            var turnosLista = await _context.puestos.ToListAsync();

            return turnosLista;
        }

        [HttpGet("{id_puesto}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id_puesto)
        {
            var puesto = _context.puestos.FirstOrDefault<Puesto>(x => x.id_puesto== id_puesto);

            return puesto;
        }
        [HttpPost]
        public async Task<ActionResult<Puesto>> Postarea(PuestoRequest reqPuesto)
        {
            var entidadExistente = _context.puestos.SingleOrDefault(e => e.id_puesto == reqPuesto.id_puesto);
            if (entidadExistente == null)
            {
                var reqAreaN = new Puesto()
                {
                    id_puesto = reqPuesto.id_puesto,
                    id_empleadoT = reqPuesto.id_empleadoT,
                    puesto = reqPuesto.nombre,
                };
                _context.puestos.Add(reqAreaN);
                _context.SaveChanges();
                reqPuesto.id_puesto = Funciones.ObtenerUltimoId<Puesto>(_context);
            }
            else
            {
                reqPuesto.id_puesto = entidadExistente.id_puesto;
                entidadExistente.puesto = reqPuesto.nombre;
                entidadExistente.id_empleadoT = reqPuesto.id_empleadoT;
                _context.SaveChanges();

            }
            return Ok(new { id = reqPuesto.id_puesto });
        }
    }
}
