using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class IncapacidadesController : ControllerBase
    {
        private readonly RHDBContext _context;

        public IncapacidadesController(RHDBContext context)
        {
            _context = context;
        }

        [HttpPut("{id_incapacidad}")]
        public ActionResult<Incapacidad> PutIncapacidad(int id_incapacidad, Incapacidad incapacidad)
        {
            if (id_incapacidad != incapacidad.id_incapacidad)
            {
                return BadRequest();
            }
            _context.Entry(incapacidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public ActionResult<Incapacidad> PostIncapacidad(Incapacidad incapacidad)
        {
            _context.incapacidads.Add(incapacidad);
            _context.SaveChanges();

            return Ok(new { id = incapacidad.id_incapacidad });
        }
        [HttpDelete("{id_incapacidad}")]
        public ActionResult<Incapacidad> DeleteIncapacidad(int id_incapacidad)
        {
            var incapacidad = _context.incapacidads.FirstOrDefault(e => e.id_incapacidad == id_incapacidad);
            if (incapacidad == null)
            {
                return NotFound();
            }
            _context.incapacidads.Remove(incapacidad);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("empleado/{id_empleado}")]
        public ActionResult<Incapacidad> GetIncapacidadesEmpleado(int id_empleado)
        {
            var incapacidades = _context.incapacidads.Where(e => e.id_empleado == id_empleado).ToList();

            return Ok(incapacidades);

        }
        
        [HttpGet("{id_incapacidad}")]
        public ActionResult<Incapacidad> GetIncapacidad(int id_incapacidad)
        {
            var incapacidad = _context.incapacidads.FirstOrDefault(e => e.id_incapacidad == id_incapacidad);

            if (incapacidad == null)
            {
                incapacidad = new Incapacidad();
            }

            return Ok(incapacidad);
        }
        [HttpGet("sucursal/{id_sucursal}/{status}")]
        public ActionResult<Incapacidad> GetIncapacidadesSucursal(int id_sucursal,string status)
        {
            var incapacidades = _context.incapacidads
                .Join(_context.empleados, p => p.id_empleado, e => e.id_empleado, (p, e) => new { p, e })
                .Where(pe => pe.e.id_sucursal == id_sucursal)
                .Select(pe => pe.p);
            if (int.TryParse(status, out int result1))
            {
                if (result1 >= 0)
                {
                    incapacidades = incapacidades.Where(p => p.status == result1);
                }
            }
            return Ok(incapacidades);
        }
        
        [HttpGet]
        public ActionResult<Incapacidad> GetIncapacidades()
        {
            var incapacidades = _context.incapacidads.ToList();

            return Ok(incapacidades);
        }
        [HttpGet("next")]
        public ActionResult<int> GetNextIdIncapacidad()
        {
            var nextId = 1;
            if (_context.incapacidads.Count() > 0)
            {
                nextId = _context.incapacidads.Max(s => s.id_incapacidad) + 1;
            }

            return Ok(nextId);
        }



    }
}
