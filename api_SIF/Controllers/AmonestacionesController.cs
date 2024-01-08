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
        //funcion que busque amonestaciones por id_sucursal pero el id_sucursal se obtiene de la tabla empleados tienes que unir tabla amonestaciones con empleados
        [HttpGet("sucursal/{id_sucursal}")]
        public ActionResult<IEnumerable<RequestAmonestacion>> GetAmonestacionSucursal(int id_sucursal)
        {
            //var empleadoIds = _context.empleados
            //.Where(e => e.id_sucursal == id_sucursal)
            //.Select(e => e.id_empleado)
            //.ToList();

            var amonestacion = _context.amonestacions
               // .Where(a => empleadoIds.Contains(a.id_empleado))
                .ToList();
            //llena un nuevo listado de amonestaciones con el modelo de requestAmonestaciones en especial el nombreSupervisor y nombreAmonestado
            var amonestaciones = new List<RequestAmonestacion>();

            foreach (var item in amonestacion)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                if(empleado.id_sucursal != id_sucursal)
                {
                    continue;
                }
                var supervisor = _context.empleados.FirstOrDefault(e => e.id_empleado == empleado.jefeInmediato);
                //soluciona cuando supervisor es null llenar valores vacios
                if (supervisor == null)
                {
                    supervisor = new empleado();
                    supervisor.nombre = "";
                    supervisor.apellidoPaterno = "";
                    supervisor.apellidoMaterno = "";
                }
                var amonestacionRequest = new RequestAmonestacion()
                {
                    id_amonestacion = item.id_amonestacion,
                    id_empleado = item.id_empleado,
                    nombreAmonestado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                    nombreSupervisor = supervisor.nombre + " " + supervisor.apellidoPaterno + " " + supervisor.apellidoMaterno,
                    fecha = item.fecha,
                    causa = item.causa,
                    comentario = item.comentario,
                    firmaAmonestado = item.firmaAmonestado,
                    realizo = item.realizo
                };
                amonestaciones.Add(amonestacionRequest);
            }


            return amonestaciones;
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
