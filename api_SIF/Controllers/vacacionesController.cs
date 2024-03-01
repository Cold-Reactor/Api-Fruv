using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var id = _context.vacaciones.Max(x => x.id_vacaciones) + 1;
            return id;
        }
        [HttpGet("sucursal/{id_sucursal}")]
        public ActionResult<IEnumerable<vacacione>> GetVacacionesPorSucursal(int id_sucursal)
        {
            var Lista = _context.vacaciones
                .Join(_context.empleados, p => p.id_empleado, e => e.id_empleado, (p, e) => new { p, e })
                .Where(pe => pe.e.id_sucursal == id_sucursal)
                .Select(pe => pe.p);
            return Lista.ToList();
        }
    }
}
