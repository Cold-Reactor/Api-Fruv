using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class controlEntradasSeguridadController : ControllerBase
    {
        private readonly RHDBContext _context;

        public controlEntradasSeguridadController(RHDBContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<checada>> PostChecadaSeguridad(checada checada)
        {
            _context.checadas.Add(checada);
            await _context.SaveChangesAsync();
            checada.id_checada = Funciones.ObtenerUltimoId<checada>(_context);
            return Ok(new { id = checada.id_checada });
        }

        [HttpGet("/{sucursal}/{from1}/{to}")]
        public async Task<ActionResult<IEnumerable<checada[]>>> GetChecadaSeguridad(int sucursal, DateOnly from1, DateOnly to)
        {
            List<checada> check = (from c in _context.checadas join a in _context.empleados on c.id_empleado equals a.id_empleado
                                   where c.fecha >= from1 && c.fecha <= to && a.id_sucursal == sucursal && c.id_checador == 5
                                   select new checada
                                   {
                                     id_checada =c.id_checada,
                                     id_empleado =c.id_empleado,
                                     id_checador =c.id_checador,
                                     fechaHora =c.fechaHora,
                                     fecha =c.fecha,
                                     hora =c.hora,
                                     nomina =c.nomina,

                                   }).ToList();
            return Ok(check);

        }
    }
}
