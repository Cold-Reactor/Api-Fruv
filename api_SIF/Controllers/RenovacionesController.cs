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
    public class RenovacionesController : ControllerBase
    {
        private readonly RHDBContext _context;

        public RenovacionesController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<renovacion>> GetRenovaciones()
        {
            var Lista = _context.renovacions;
            return Lista.ToList();            
        }
        [HttpGet]
        [Route("{id_renovacion}")]
        public ActionResult<renovacion> GetRenovacion(int id_renovacion)
        {
            var renovacion = _context.renovacions.FirstOrDefault(t => t.id_renovacion == id_renovacion);
            if (renovacion == null)
            {
                return NotFound();
            }
            return renovacion;
        }
        [HttpPost]
        public ActionResult<renovacion> CreateRenovacion(renovacion renovacion)
        {
            _context.renovacions.Add(renovacion);
            _context.SaveChanges();
            return Ok(new { id = renovacion.id_renovacion });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRenovacion(int id, renovacion renovacion)
        {
            if (id != renovacion.id_renovacion)
            {
                return BadRequest();
            }
            _context.Entry(renovacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
