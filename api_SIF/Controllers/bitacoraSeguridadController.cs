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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class bitacoraSeguridadController : ControllerBase
    {
        private readonly RHDBContext _context;

        public bitacoraSeguridadController(RHDBContext context)
        {
            _context = context;
        }

        [HttpGet("{sucursal}/{from1}/{to}")]
        public async Task<ActionResult<bitacoraSeguridad>> GetBitacora(int sucursal, DateTime from1, DateTime to)

        {

            List<bitacoraSeguridad> check = (from c in _context.bitacoras
                                             join a in _context.empleados on c.registro equals a.id_empleado
                                             where c.fecha >= from1 && c.fecha <= to && a.id_sucursal == sucursal
                                             select new bitacoraSeguridad
                                             {
                                                 id_bitacoraS = c.id_bitacoraS,
                                                 fecha = c.fecha,
                                                 descripcion = c.descripcion,
                                                 imagen = c.imagen,
                                                 relevante = c.relevante,
                                                 registro = c.registro

                                             }).ToList();
            return Ok(check);
        }
        [HttpPost]
        public async Task<ActionResult<bitacoraSeguridad[]>> PostBitacora(bitacoraSeguridad bitacora)
        {
            var emp1 = new bitacoraSeguridad
            {
                id_bitacoraS =bitacora.id_bitacoraS,
                fecha = bitacora.fecha,
                descripcion  = bitacora.descripcion,
                imagen  = bitacora.imagen,
                relevante = bitacora.relevante,
                registro =bitacora.registro
            };
            _context.bitacoras.Add(emp1);
            await _context.SaveChangesAsync();
            emp1.id_bitacoraS = Funciones.ObtenerUltimoId<bitacoraSeguridad>(_context); ;
            return Ok(new { id = emp1.id_bitacoraS });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitacora(int id, bitacoraSeguridad bitacora)
        {
            var entity = await _context.bitacoras.FirstOrDefaultAsync(item => item.id_bitacoraS == id);

            // Validate entity is not null
            if (entity != null)
            {
                entity.imagen = bitacora.imagen;
                entity.relevante = bitacora.relevante;  
                _context.SaveChanges();
            }
            return Ok();
        }

    }
}