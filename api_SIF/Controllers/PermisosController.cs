using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [HttpGet("siguiente")]
        public ActionResult<int> GetSiguienteId()
        {
            var ultimoId = Funciones.ObtenerUltimoId<Permiso>(_context);
            if (ultimoId == -1)
            {
                ultimoId = 0;
            }            
            return Ok(new { id = ultimoId + 1 });
        }

        [HttpGet("sucursal/{id_sucursal}/{status}")]
        public ActionResult<IEnumerable<RequestPermisos>> GetPermisosBySucursal(int id_sucursal,int status)
        {
            var permiso = from x in _context.permisos.Where(x => x.status == status)
                          select new RequestPermisos()
                          {
                              id_permiso = x.id_permiso,
                              id_empleado = x.id_empleado,
                              fechaCreacion = x.fechaCreacion,
                              id_supervisor = x.id_supervisor,
                              id_modalidad = x.id_modalidad,
                              fechaSalida = x.fechaSalida,
                              fechaEntrada = x.fechaEntrada,
                              dias = x.dias,
                              horaSalida = x.horaSalida,
                              horaEntrada = x.horaEntrada,
                              horas = x.horas,
                              motivo = x.motivo,
                              pagado = x.pagado,
                              status = x.status,
                              autorizo = x.autorizo,
                          };

            var permisos = new List<RequestPermisos>();

            foreach (var item in permiso.ToList())
            {
                Debug.WriteLine(item);
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                if (empleado.id_sucursal != id_sucursal)
                {
                    continue;
                }
                var supervisor = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_supervisor);
                if (supervisor == null)
                {
                    supervisor = new empleado();
                    supervisor.nombre = "";
                    supervisor.apellidoPaterno = "";
                    supervisor.apellidoMaterno = "";
                }
                var permisoRequest = new RequestPermisos()
                {
                    id_permiso = item.id_permiso,
                    id_empleado = item.id_empleado,
                    fechaCreacion = item.fechaCreacion,
                    id_supervisor = item.id_supervisor,
                    id_modalidad = item.id_modalidad,
                    fechaSalida = item.fechaSalida,
                    fechaEntrada = item.fechaEntrada,
                    dias = item.dias,
                    horaSalida = item.horaSalida,
                    horaEntrada = item.horaEntrada,
                    horas = item.horas,
                    motivo = item.motivo,
                    pagado = item.pagado,
                    status = item.status,
                    autorizo = item.autorizo,
                    nombreEmpleado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                    nombreSupervisor = supervisor.nombre + " " + supervisor.apellidoPaterno + " " + supervisor.apellidoMaterno
                };
                permisos.Add(permisoRequest);
            }
            return permisos;

            //var Lista = _context.permisos
            //    .Join(_context.empleados, p => p.id_empleado, e => e.id_empleado, (p, e) => new { p, e })
            //    .Where(pe => pe.e.id_sucursal == id_sucursal)
            //    .Select(pe => pe.p);
            //return Lista.ToList();
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