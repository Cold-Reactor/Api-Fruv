using api_SIF.Clases;
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
        public ActionResult<IEnumerable<RequestAmonestacion>> GetAmonestaciones()
        {
            var amonestaciones = _context.amonestacions.ToList();
            var amonestacionesRequest = new List<RequestAmonestacion>();
            foreach (var item in amonestaciones)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                var supervisor = _context.empleados.FirstOrDefault(e => e.id_empleado == empleado.jefeInmediato);
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
                    realizo = item.realizo,
                    status = item.status
                };
                amonestacionesRequest.Add(amonestacionRequest);
            }
            return amonestacionesRequest;

        }

        // GET: RH/Amonestaciones/5
        [HttpGet("{id_amonestacion}")]
        public ActionResult<RequestAmonestacion> GetAmonestacion(int id_amonestacion)
        {
            var amonestacion = _context.amonestacions.FirstOrDefault(a => a.id_amonestacion == id_amonestacion);
            var amonestacionRequest = new RequestAmonestacion();
            if (amonestacion == null)
            {
                return amonestacionRequest;
            }
            var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == amonestacion.id_empleado);
            var supervisor = _context.empleados.FirstOrDefault(e => e.id_empleado == empleado.jefeInmediato);
            if (supervisor == null)
            {
                supervisor = new empleado();
                supervisor.nombre = "";
                supervisor.apellidoPaterno = "";
                supervisor.apellidoMaterno = "";
            }
            amonestacionRequest = new RequestAmonestacion()
            {
                id_amonestacion = amonestacion.id_amonestacion,
                id_empleado = amonestacion.id_empleado,
                nombreAmonestado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                nombreSupervisor = supervisor.nombre + " " + supervisor.apellidoPaterno + " " + supervisor.apellidoMaterno,
                fecha = amonestacion.fecha,
                causa = amonestacion.causa,
                comentario = amonestacion.comentario,
                firmaAmonestado = amonestacion.firmaAmonestado,
                realizo = amonestacion.realizo,
                status = amonestacion.status
            };
            return amonestacionRequest;
        }
        [HttpGet("sucursal/{id_sucursal}")]
        public ActionResult<IEnumerable<RequestAmonestacion>> GetAmonestacionSucursal(int id_sucursal)
        {
          

            var amonestacion = _context.amonestacions
               // .Where(a => empleadoIds.Contains(a.id_empleado))
                .ToList();
            var amonestaciones = new List<RequestAmonestacion>();

            foreach (var item in amonestacion)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                if(empleado.id_sucursal != id_sucursal)
                {
                    continue;
                }
                var supervisor = _context.empleados.FirstOrDefault(e => e.id_empleado == empleado.jefeInmediato);
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
                    realizo = item.realizo,
                    status = item.status
                };
                amonestaciones.Add(amonestacionRequest);
            }


            return amonestaciones;
        }

        

        // POST: RH/Amonestaciones
        [HttpPost]
        public ActionResult<amonestacion> CreateAmonestacion(amonestacion amonestacion)
        {
            if(amonestacion.status == null)
            {
                amonestacion.status = 1;
            }
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
            existingAmonestacion.status = amonestacion.status ?? existingAmonestacion.status;

            _context.amonestacions.Update(existingAmonestacion);
            _context.SaveChanges();

            return Ok(new { id = existingAmonestacion.id_amonestacion });
        }

        [HttpGet("siguiente")]
        public ActionResult<int> GetSiguienteId()
        {
            return Ok(new { id = Funciones.ObtenerUltimoId<amonestacion>(_context) + 1 });
        }

    }
}
