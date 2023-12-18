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
    public class PermisosController : ControllerBase
    {
        private readonly RHDBContext _context;
        public PermisosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Permiso>> GetPermisos()
        {
            var Lista = _context.permisos;
            return Lista.ToList();
        }

        [HttpPost]
        public ActionResult<Permiso> CreatePermiso(Permiso permiso)
        {
            _context.permisos.Add(permiso);
            _context.SaveChanges();
            return Ok( new { id = permiso.id_permiso });
        }

        [HttpGet("{id_permiso}")]
        public ActionResult<Permiso> GetPermisoById(int id_permiso)
        {
            var permiso = _context.permisos.FirstOrDefault(p => p.id_permiso == id_permiso);
            if (permiso == null)
            {
                return NotFound();
            }
            return permiso;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermiso(int id, Permiso permiso)
        {
            if (id != permiso.id_permiso)
            {
                return BadRequest();
            }
            _context.Entry(permiso).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeletePermiso(int id)
        //{
        //    var permiso = _context.permisos.FirstOrDefault(p => p.id_permiso == id);
        //    if (permiso == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.permisos.Remove(permiso);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
