using api_SIF.dbContexts;
using api_SIF.Models;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class plantillaSeguridadController : ControllerBase
    {
        private readonly RHDBContext _context;

        public plantillaSeguridadController(RHDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id_empleado}/{fecha}")]
        public async Task<ActionResult<plantillaSeguridad>> GetPlantilla(int id_empleado, DateOnly fecha)
        {
            var entity = await _context.plantillas.FirstOrDefaultAsync(item => item.id_empleado == id_empleado && item.fecha == fecha);
            if (entity == null)
            {
                return NotFound();
            }
            var reqPlantilla = new plantillaSeguridad()
            {
                id_plantillaS = entity.id_plantillaS,
                id_empleado = entity.id_empleado,
                id_turno = entity.id_turno,
                fecha = entity.fecha,
            };
            return reqPlantilla;
        }
        
        [HttpGet("{id_sucursal}/{from1}/{to}")]
        public async Task<ActionResult<IEnumerable<RequestPlantillaGuardia>>> GetPlantillaGuardia(int id_sucursal, DateOnly from1, DateOnly to)
        {
            List<DateOnly> fechas = new List<DateOnly>();
            DateOnly date1 = from1;
            while (date1 >= from1 && date1 <= to)
            {
                fechas.Add(date1);
                date1 = date1.AddDays(1);
            }
            List<plantillaSeguridad> plantillaS = await (from c in _context.plantillas
                                                         where c.fecha >= from1 && c.fecha <= to
                                                          select new plantillaSeguridad
                                                          { id_plantillaS = c.id_plantillaS,
                                                            id_empleado=c.id_empleado,
                                                            id_turno = c.id_turno,
                                                            fecha = c.fecha,
                                                          }).ToListAsync();
            plantillaS = plantillaS.OrderBy(x => x.fecha).ToList();

            var empleados = await (from p in _context.empleados
                                     join a in _context.areas on p.id_area equals a.id_area
                                     where p.status == 1 && p.id_sucursal == id_sucursal && a.id_departamento == 11
                                     select new RequestPlantillaGuardia
                                     { id_empleado = p.id_empleado,
                                       nombre = p.apellidoPaterno + " " + p.apellidoMaterno + " " + p.nombre,
                                       imagen = p.imagen
                                     }).ToListAsync();

            foreach (var empleado in empleados)
            { 
                var plantilla = new List<plantillaSeguridad>();
                foreach (var fecha in fechas)
                {
                    foreach (var p in plantillaS)
                    {
                        if (p.fecha == fecha)
                        {
                            if (empleado.id_empleado == p.id_empleado)
                            {
                                plantilla.Add(p);
                            }
                        }

                    }
                }
                empleado.plantilla = plantilla;
            }
            return empleados;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostPlantillaS(List<plantillaSeguridad> plantillas)
        {
            //_context.plantillas.Add(plantilla);
            //await _context.SaveChangesAsync();

            //return Ok(new { id = plantilla.id_plantillaS });

            foreach (var p in plantillas)
            {
                _context.plantillas.Add(p);
            }
                await _context.SaveChangesAsync();

            return "Plantilla Creada";
        }

        [HttpPut]
        public async Task<IActionResult> PutPlantillaS(List<plantillaSeguridad> plantillas)
        {
            foreach(var p in plantillas)
            {
                var entity = await _context.plantillas.FirstOrDefaultAsync(item => item.id_plantillaS == p.id_plantillaS);
                if (entity != null)
                {
                    //entity.id_plantillaS = checada.fecha;
                    //entity.hora = checada.hora;
                    entity.id_turno = p.id_turno;
                    await _context.SaveChangesAsync();
                }
            }
            return Ok("Plantilla Actualizada");
        }
    }
}
