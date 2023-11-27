using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estadosController : ControllerBase
    {

        private readonly RHDBContext _context;
        public estadosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            var estadosLista = _context.estados;
            return await estadosLista.ToListAsync();
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Estado>> GetEstado(string nombre)
        {
            var estadoS = _context.estados.SingleOrDefault(x => x.estado == nombre);
            if (estadoS == null)
            {
                return NotFound();
            }

            return estadoS;
        }
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado reqEstado)
        {
            var entidadExistente = _context.estados.SingleOrDefault(e => e.id_estado == reqEstado.id_estado);
            if (entidadExistente == null)
            {
                _context.estados.Add(reqEstado);
                _context.SaveChanges();
                reqEstado.id_estado = Funciones.ObtenerUltimoId<Estado>(_context);
            }
            else
            {
                reqEstado.id_estado = entidadExistente.id_estado;
                entidadExistente.estado = reqEstado.estado;
                _context.SaveChanges();
            }
            return Ok(new { id = reqEstado.id_estado });
        }

    }
}
