using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using api_SIF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {

        private readonly RHDBContext _context;
        public PuestosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<puesto>>> GetPuestos()
        {
            var turnosLista = await _context.puestos.ToListAsync();
            return turnosLista;
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<puesto>> GetPuesto(string nombre)
        {
            var puesto = _context.puestos.FirstOrDefault<puesto>(x => x.nombre== nombre);

            return puesto;
        }
        //[HttpPost]
        //public async Task<ActionResult> PostPuesto(puesto turnoNuevo)
        //{
        //    turno turnoN = new turno();
        //    turnoN.turno1 = turnoNuevo.turno;
        //    turnoN.entradaF = turnoNuevo.entradaF;
        //    turnoN.entrada = turnoNuevo.entrada;
        //    turnoN.horas_trabajadas = turnoNuevo.horas_trabajadas;
        //    turnoN.comida = turnoNuevo.comida;
        //    turnoN.descanso = turnoNuevo.descanso;
        //    turnoN.salidaF = turnoNuevo.salidaF;
        //    turnoN.disponible = turnoNuevo.disponible;
        //    turnoN.horas = turnoNuevo.horas;
        //    turnoN.horasF = turnoNuevo.horasF;
        //    turnoN.id_sucursal = turnoNuevo.id_sucursal;
        //    turnoN.nocturno = turnoNuevo.nocturno;
        //    turnoN.salida = turnoNuevo.salida;

        //    _context.turnos.Add(turnoN);
        //    await _context.SaveChangesAsync();
        //    ReturnId ri = new ReturnId(turnoN.id_turno);
        //    return Ok(ri);
        //}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Putchecada(int id, TurnoRequest turnoNuevo)
        //{
        //    if (id != turnoNuevo.id_turno)
        //    {
        //        return BadRequest();
        //    }
        //    turno turnoN = _context.turnos
        //    .FirstOrDefault(p => p.id_turno == turnoNuevo.id_turno);
        //    try
        //    {
        //        turnoN.turno1 = turnoNuevo.turno;
        //        turnoN.entradaF = turnoNuevo.entradaF;
        //        turnoN.entrada = turnoNuevo.entrada;
        //        turnoN.horas_trabajadas = turnoNuevo.horas_trabajadas;
        //        turnoN.comida = turnoNuevo.comida;
        //        turnoN.descanso = turnoNuevo.descanso;
        //        turnoN.salidaF = turnoNuevo.salidaF;
        //        turnoN.disponible = turnoNuevo.disponible;
        //        turnoN.horas = turnoNuevo.horas;
        //        turnoN.horasF = turnoNuevo.horasF;
        //        turnoN.id_sucursal = turnoNuevo.id_sucursal;
        //        turnoN.nocturno = turnoNuevo.nocturno;
        //        turnoN.salida = turnoNuevo.salida;
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!turnoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();

        //}
        //private bool turnoExists(int id)
        //{
        //    return _context.turnos.Any(e => e.id_turno == id);
        //}
    }
}
