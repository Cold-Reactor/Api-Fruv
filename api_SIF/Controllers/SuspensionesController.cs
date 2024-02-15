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
