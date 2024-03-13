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
        public ActionResult<IEnumerable<RequestIncapacidad>>GetIncapacidadesSucursal(int id_sucursal,string status)
        {
            var incapacidad = _context.incapacidads
                .Join(_context.empleados, p => p.id_empleado, e => e.id_empleado, (p, e) => new { p, e })
                .Where(pe => pe.e.id_sucursal == id_sucursal)
                .Select(pe => pe.p);
            if (int.TryParse(status, out int result1))
            {
                if (result1 >= 0)
                {
                    incapacidad = incapacidad.Where(p => p.status == result1);
                }
            }
            var incapacidades = new List<RequestIncapacidad>();
            foreach (var item in incapacidades)
            {
                var empleado = _context.empleados.FirstOrDefault(e => e.id_empleado == item.id_empleado);
                var vacacionesRequest = new RequestIncapacidad()
                {
                    id_incapacidad = item.id_incapacidad,
                    id_empleado = item.id_empleado,
                    motivo = item.motivo,
                    fechaInicio = item.fechaInicio,
                    fechaRegreso = item.fechaRegreso,
                    dias = item.dias,
                    temporal = item.temporal,
                    comentario = item.comentario,
                    embarazo = item.embarazo,
                    nombreEmpleado = empleado.nombre + " " + empleado.apellidoPaterno + " " + empleado.apellidoMaterno,
                    status = item.status
                };
                incapacidades.Add(vacacionesRequest);
            }
            return incapacidades;
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
