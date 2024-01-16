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
    public class empleado_tiempoextrasController : ControllerBase
    {
        private readonly RHDBContext _context;

        public empleado_tiempoextrasController(RHDBContext context)
        {
            _context = context;
        }

        [HttpGet("empleado/{id_empleado}/{fecha}")]
        public ActionResult<IEnumerable<empleado_tiempoextra>> Getempleado_tiempoextraPorEmpleado(int id_empleado,DateTime fecha)
        {
            //que se filtre la fecha sin importar la hora
            var Fecha = fecha.Date;

            var empleado_tiempoextra = _context.empleado_tiempoextras.Where(e => e.id_empleado == id_empleado && e.fechaInicio.Value.Date <= Fecha && e.fechaSalida.Value.Date >= Fecha).ToList();

            if (empleado_tiempoextra == null)
            {
                return NotFound();
            }

            return empleado_tiempoextra;
        }




        // GET: api/empleado_tiempoextras/5
        [HttpGet("{id_tiempoExtra}")]
        public ActionResult<empleado_tiempoextra> Getempleado_tiempoextra(int id_tiempoExtra)
        {
            var empleado_tiempoextra = _context.empleado_tiempoextras.FirstOrDefault(e => e.id_tiempoExtra == id_tiempoExtra);

            if (empleado_tiempoextra == null)
            {
                return NotFound();
            }

            return empleado_tiempoextra;
        }

       

        // POST: api/empleado_tiempoextras
        [HttpPost]
        public ActionResult<empleado_tiempoextra> Postempleado_tiempoextra(empleado_tiempoextra empleado_tiempoextra)
        {
            empleado_tiempoextra nuevo = new empleado_tiempoextra();
            nuevo.id_empleado = empleado_tiempoextra.id_empleado;
            nuevo.fechaInicio = empleado_tiempoextra.fechaInicio;
            nuevo.fechaSalida = empleado_tiempoextra.fechaSalida;
            nuevo.horas = empleado_tiempoextra.horas;
            nuevo.actividad = empleado_tiempoextra.actividad;
            nuevo.pago = empleado_tiempoextra.pago;

            _context.empleado_tiempoextras.Add(empleado_tiempoextra);
            _context.SaveChanges();

            return Ok(new { id = nuevo.id_tiempoExtra });
        }
        // PUT: api/empleado_tiempoextras/5
        [HttpPut("{id_tiempoExtra}")]
        public ActionResult<empleado_tiempoextra> Putempleado_tiempoextra(int id_tiempoExtra, empleado_tiempoextra empleado_tiempoextra)
        {
            if (id_tiempoExtra != empleado_tiempoextra.id_tiempoExtra)
            {
                return BadRequest();
            }
            _context.Entry(empleado_tiempoextra).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

    }
}
