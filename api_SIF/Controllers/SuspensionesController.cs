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
    public class SuspensionesController : ControllerBase
    {
        private readonly RHDBContext _context;

        public SuspensionesController(RHDBContext context)
        {
            _context = context;
        }

        // GET: RH/Suspensiones
        [HttpGet]
        public ActionResult<IEnumerable<suspension>> GetSuspensiones()
        {
            return _context.suspensions.ToList();
        }

        // GET: RH/Suspensiones/5
        [HttpGet("{id_suspension}")]
        public ActionResult<suspension> GetSuspension(int id_suspension)
        {
            var suspension = _context.suspensions.FirstOrDefault(s => s.id_suspension == id_suspension);

            if (suspension == null)
            {
                suspension = new suspension();
            }

            return suspension;
        }
        [HttpGet("sucursal/{id_sucursal}/{status}")]
        public ActionResult<IEnumerable<RequestSuspension>> GetSuspensionBySucursal(int id_sucursal,string status)
        {
            var suspension = _context.suspensions
                .Join(_context.empleados, p => p.id_empleado, e => e.id_empleado, (p, e) => new { p, e })
                .Where(pe => pe.e.id_sucursal == id_sucursal)
                .Select(pe => pe.p);
            if (int.TryParse(status, out int result1))
            {
                if (result1 >= 0)
                {
                    suspension = suspension.Where(p => p.status == result1);
                }
            }
            var suspensiones = new List<RequestSuspension>();
            foreach (var item in suspensiones)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                var vacacionesRequest = new RequestSuspension()
                {
                    id_suspension = item.id_suspension,
                    fecha = item.fecha,
                    id_empleado = item.id_empleado,
                    fechaInicio = item.fechaInicio,
                    fechaRegreso = item.fechaRegreso,
                    dias = item.dias,
                    motivo = item.motivo,
                    realizo = item.realizo,
                    nombreEmpleado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                    status = item.status,
                    firmaAmonestado = item.firmaAmonestado,
                    firmaSupervisor = item.firmaSupervisor,
                    firmaRH = item.firmaRH
                };
                suspensiones.Add(vacacionesRequest);
            }
            return suspensiones;
        }

        // POST: RH/Suspensiones
        [HttpPost]
        public ActionResult<suspension> CreateSuspension(suspension suspension)
        {
            _context.suspensions.Add(suspension);
            _context.SaveChanges();

            return Ok(new { id = suspension.id_suspension });
        }

        // PUT: RH/Suspensiones/5
        [HttpPut("{id}")]
        public IActionResult UpdateSuspension(int id, suspension suspension)
        {
            var existingSuspension = _context.suspensions.FirstOrDefault(s => s.id_suspension == id);

            if (existingSuspension == null)
            {
                return NotFound();
            }
            existingSuspension.status = suspension.status ?? existingSuspension.status;
            existingSuspension.motivo = suspension.motivo ?? existingSuspension.motivo;
            existingSuspension.firmaRH = suspension.firmaRH ?? existingSuspension.firmaRH;

            existingSuspension.firmaAmonestado = suspension.firmaAmonestado ?? existingSuspension.firmaAmonestado;
            existingSuspension.fecha = suspension.fecha ;
            existingSuspension.fechaRegreso = suspension.fechaRegreso ?? existingSuspension.fechaRegreso;

            existingSuspension.dias = suspension.dias;
            existingSuspension.fechaInicio = suspension.fechaInicio;
            existingSuspension.firmaSupervisor = suspension.firmaSupervisor;
            existingSuspension.realizo = suspension.realizo;
            existingSuspension.id_empleado = suspension.id_empleado;
            _context.suspensions.Update(existingSuspension);
            _context.SaveChanges();


            return NoContent();
        }
        [HttpGet("next")]
        public ActionResult<int> GetNextIdSuspension()
        {
            return _context.suspensions.Max(s => s.id_suspension) + 1;
        }
        // DELETE: RH/Suspensiones/5
        //[HttpDelete("{id_empleado}")]
        //public IActionResult DeleteSuspension(int id_empleado)
        //{
        //    var suspension = _context.suspensions.FirstOrDefault(s => s.id_empleado == id);

        //    if (suspension == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.suspensions.Remove(suspension);

        //    return NoContent();
        //}
    }
}
