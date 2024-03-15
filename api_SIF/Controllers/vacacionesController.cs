using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]

    public class vacacionesController : ControllerBase
    {
        private readonly RHDBContext _context;

        public vacacionesController(RHDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<vacacione>> GetVacaciones()
        {
            var vacaciones = _context.vacaciones.ToList();

            return vacaciones;

        }

        [HttpPost]
        public ActionResult<vacacione> PostVacaciones(vacacione vacaciones)
        {
            if(vacaciones.status ==null || vacaciones.status ==0)
            {
                vacaciones.status = 1;
            }
            _context.vacaciones.Add(vacaciones);
            _context.SaveChanges();

            return Ok(new { id = vacaciones.id_vacaciones });
        }

        [HttpDelete("{id_vacaciones}")]
        public ActionResult<vacacione> DeleteVacaciones(int id_vacaciones)
        {
            var vacaciones = _context.vacaciones.FirstOrDefault(e => e.id_vacaciones == id_vacaciones);
            if (vacaciones == null)
            {
                return new vacacione();
            }
            _context.vacaciones.Remove(vacaciones);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id_vacaciones}")]
        public ActionResult<vacacione> GetVacaciones(int id_vacaciones)
        {
            var vacaciones = _context.vacaciones.FirstOrDefault(e => e.id_vacaciones == id_vacaciones);

            if (vacaciones == null)
            {
                return new vacacione();
            }
            return vacaciones;
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVacaciones(int id, vacacione vacaciones)
        {
            if (id != vacaciones.id_vacaciones)
            {
                return BadRequest();
            }
            _context.Entry(vacaciones).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("siguiente")]
        public ActionResult<int> GetSiguienteId()
        {
            //obtener el siguiente id de la tabla vacaciones si no hay ningun registro devolver 1
            var nextId = 1;
            if (_context.vacaciones.Count() > 0)
            {
                nextId = _context.vacaciones.Max(s => s.id_vacaciones) + 1;
            }
            return Ok(nextId);
        }
        [HttpGet("empleado/{id_empleado}")]
        public ActionResult<IEnumerable<requestVacaciones>> GetVacacionesPorEmpleado(int id_empleado)
        {
            return Ok(_context.vacaciones.Where(v => v.id_empleado == id_empleado).ToList());
        }
        [HttpGet("sucursal/{id_sucursal}/{status}")]
        public ActionResult<IEnumerable<requestVacaciones>> GetVacacionesPorSucursal(int id_sucursal,int status)
        {
            var vacacion = _context.vacaciones.Where(p => p.status == status).ToList();

            var vacaciones = new List<requestVacaciones>();
            foreach(var item in vacacion)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                if (empleado.id_sucursal != id_sucursal)
                {
                    continue;
                }
                var vacacionesRequest = new requestVacaciones()
                {
                    id_vacaciones = item.id_vacaciones,
                    id_empleado = item.id_empleado,
                    fechaInicio = item.fechaInicio,
                    fechaRegreso = item.fechaRegreso,
                    dias = item.dias,
                    gozado = item.gozado,
                    pagado = item.pagado,
                    cantidadPago = item.cantidadPago,
                    nombreEmpleado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                    status = item.status
                };
                vacaciones.Add(vacacionesRequest);
            }
            return vacaciones;
        }
    }
}
