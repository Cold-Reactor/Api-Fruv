using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class faltasController : ControllerBase
    {

        private readonly RHDBContext _context;

        public faltasController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<falta>> GetFaltas()
        {
            var faltas = _context.faltas.ToList();

            return faltas;       

        }
        [HttpPost]
        public ActionResult<falta> PostFalta(falta falta)
        {
            _context.faltas.Add(falta);
            _context.SaveChanges();

            return Ok(new {id=falta.id_falta});
        }
        [HttpDelete("{id_falta}")]
        public ActionResult<falta> DeleteFalta(int id_falta)
        {
            var falta = _context.faltas.FirstOrDefault(e => e.id_falta == id_falta);
            if (falta == null)
            {
                return NotFound();
            }
            _context.faltas.Remove(falta);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("empleado/{id_empleado}")]
        public ActionResult<IEnumerable<falta>> GetFaltasEmpleado(int id_empleado)
        {
            var faltas = _context.faltas.Where(e => e.id_empleado == id_empleado).ToList();

            return faltas;

        }
        //funcion para obtener las faltas de un empleado en una fecha especifica
        [HttpGet("empleado/{id_empleado}/{fecha}")]
        public ActionResult<falta> GetFaltasEmpleadoFecha(int id_empleado, DateOnly fecha)
        {
            var falta = _context.faltas.FirstOrDefault(e => e.id_empleado == id_empleado && e.fecha == fecha);
            if (falta == null)
            {
                return NotFound();
            }
            return falta;

        }
    }
}
