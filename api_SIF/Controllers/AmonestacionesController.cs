using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class AmonestacionesController : ControllerBase
    {
        private readonly RHDBContext _context;

        public AmonestacionesController(RHDBContext context)
        {
            _context = context;
        }

        // GET: RH/Amonestaciones
        [HttpGet]
        public ActionResult<IEnumerable<amonestacion>> GetAmonestaciones()
        {
            return _context.amonestacions.ToList();
        }

        // GET: RH/Amonestaciones/5
        [HttpGet("{id_amonestacion}")]
        public ActionResult<amonestacion> GetAmonestacion(int id_amonestacion)
        {
            var amonestacion = _context.amonestacions.FirstOrDefault(a => a.id_amonestacion == id_amonestacion);

            if (amonestacion == null)
            {
                return NotFound();
            }

            return amonestacion;
        }

        // POST: RH/Amonestaciones
        [HttpPost]
        public ActionResult<amonestacion> CreateAmonestacion(amonestacion amonestacion)
        {
            _context.amonestacions.Add(amonestacion);
            _context.SaveChanges();

            return Ok(new { id = amonestacion.id_amonestacion });
        }

        // PUT: RH/Amonestaciones/5
        [HttpPut("{id}")]
        public IActionResult UpdateAmonestacion(int id, amonestacion amonestacion)
        {
            var existingAmonestacion = _context.amonestacions.FirstOrDefault(a => a.id_amonestacion == id);

            if (existingAmonestacion == null)
            {
                return NotFound();
            }
            existingAmonestacion.firmaAmonestado = amonestacion.firmaAmonestado ?? existingAmonestacion.firmaAmonestado;
            existingAmonestacion.fecha = amonestacion.fecha ?? existingAmonestacion.fecha;
            existingAmonestacion.id_empleado = amonestacion.id_empleado ;
            existingAmonestacion.causa = amonestacion.causa ?? existingAmonestacion.causa;
            existingAmonestacion.comentario = amonestacion.comentario ?? existingAmonestacion.comentario;
            existingAmonestacion.realizo = amonestacion.realizo ?? existingAmonestacion.realizo;
            

            _context.amonestacions.Update(existingAmonestacion);
            _context.SaveChanges();

            return Ok(new { id = existingAmonestacion.id_amonestacion });
        }

        // DELETE: RH/Amonestaciones/5
    }
}
