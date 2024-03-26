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
            var entity = await _context.plantilaseguridad.FirstOrDefaultAsync(item => item.id_empleado == id_empleado && item.fecha == fecha);
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
            List<plantillaSeguridad> plantillaS = (from c in _context.plantilaseguridad
                                                      where c.fecha >= from1 && c.fecha <= to
                                                      select new plantillaSeguridad
                                                      { id_plantillaS = c.id_plantillaS,
                                                        id_empleado=c.id_empleado,
                                                        id_turno = c.id_turno,
                                                        fecha = c.fecha,
                                                      }).ToList();
            plantillaS = plantillaS.OrderBy(x => x.fecha).ToList();

            var empleados = (from p in _context.empleados
                             join a in _context.areas on p.id_area equals a.id_area into joinedTable
                             from a in joinedTable.DefaultIfEmpty()
                             where p.status == 1 && p.id_sucursal == id_sucursal && a.id_departamento == 11
                             select new RequestPlantillaGuardia
                             {
                                 id_empleado = p.id_empleado,
                                 nombre = p.apellidoPaterno + " " + p.apellidoMaterno + " " + p.nombre,
                                 imagen = p.imagen
                             }).ToList();

            //if (int.TryParse("11", out int result3) && result3 != 0)
            //{
            //    var areasLista = _context.areas.Where<area>(xx => xx.id_departamento == result3).Select(ts => ts.id_area).ToList();
            //    empleados = empleados.Where(x => areasLista.Contains((int)x.id_area));
            //}
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
    }
}
