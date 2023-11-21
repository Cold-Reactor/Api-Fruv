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
    public class ciudadesController : ControllerBase
    {
        private readonly RHDBContext _context;
        public ciudadesController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ciudad>>> Getciudades()
        {
            var ciudadesLista = _context.ciudads;
            return await ciudadesLista.ToListAsync();
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<ciudad>> GetCiudad(string nombre)
        {
            var ciudad =  _context.ciudads.SingleOrDefault(x => x.nombre==nombre);
            if (ciudad == null)
            {
                return NotFound();
            }
           
            return ciudad;
        }
        [HttpPost]
        public async Task<ActionResult<ciudad>> PostCiudad(ciudad reqCiudad)
        {
            var entidadExistente = _context.ciudads.SingleOrDefault(e => e.id_ciudad == reqCiudad.id_ciudad);
            if (entidadExistente == null)
            {
                var reqCiudadaN = new ciudad()
                {
                    id_ciudad = reqCiudad.id_ciudad,
                    nombre = reqCiudad.nombre,
                };
                _context.ciudads.Add(reqCiudadaN);
                _context.SaveChanges();
                reqCiudad.id_ciudad = Funciones.ObtenerUltimoId<ciudad>(_context);
            }
            else
            {
                reqCiudad.id_ciudad = entidadExistente.id_ciudad;
                entidadExistente.nombre = reqCiudad.nombre;
                _context.SaveChanges();

            }
            return Ok(new { id = reqCiudad.id_ciudad });
        }


    }
}
