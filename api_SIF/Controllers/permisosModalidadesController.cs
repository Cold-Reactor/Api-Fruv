using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class permisosModalidadesController : ControllerBase
    {
        private readonly RHDBContext _context;
        public permisosModalidadesController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PermisoModalidad>> GetPermisosModalidades()
        {
            var Lista = _context.permisomodalidads;
            return Lista.ToList();
        }

        [HttpPost]
        public ActionResult<PermisoModalidad> CreatePermisoModalidad(PermisoModalidad permisoModalidad)
        {
            _context.permisomodalidads.Add(permisoModalidad);
            _context.SaveChanges();
            return Ok(new { id = permisoModalidad.id_modalidad });
        }

        [HttpGet("{id_modalidad}")]
        public ActionResult<PermisoModalidad> GetPermisoModalidadById(int id_modalidad)
        {
            var permisoModalidad = _context.permisomodalidads.FirstOrDefault(p => p.id_modalidad == id_modalidad);
            if (permisoModalidad == null)
            {
                return NotFound();
            }
            return permisoModalidad;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermisoModalidad(int id, PermisoModalidad permisoModalidad)
        {
            if (id != permisoModalidad.id_modalidad)
            {
                return BadRequest();
            }
            _context.Entry(permisoModalidad).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeletePermisoModalidad(int id)
        //{
        //    var permisoModalidad = _context.permisomodalidads.FirstOrDefault(p => p.id_modalidad == id);
        //    if (permisoModalidad == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.permisomodalidads.Remove(permisoModalidad);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

    }
}
