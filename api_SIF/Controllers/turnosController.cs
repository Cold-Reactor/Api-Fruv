using api_SIF.dbContexts;
using api_SIF.Models;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class turnosController : ControllerBase
    {

        private readonly RHDBContext _context;
        public turnosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestTurno>>> GetTurnos()
        {
            var turnosLista = from x in _context.turnos
                              select new requestTurno()
                              {
                                  comida = Clases.Funciones.HoraAString(x.comida),
                                  turno = x.turno1,
                                  descanso = x.descanso,
                                  entrada = Clases.Funciones.HoraAString(x.entrada),
                                  entradaF = Clases.Funciones.HoraAString(x.entradaF),
                                  horas = x.horas,
                                  horasF = x.horasF,
                                  horas_trabajadas = x.horas_trabajadas,
                                  id_turno = x.id_turno,
                                  nocturno = x.nocturno,
                                  salida = Clases.Funciones.HoraAString(x.salida),
                                  salidaF = Clases.Funciones.HoraAString(x.salidaF)
                              };
            return await turnosLista.ToListAsync();
        }

        [HttpGet("{id_sucursal}")]
        public async Task<ActionResult<IEnumerable<requestTurno>>> GetTurno(int id_sucursal)
        {
            var turnosLista = from x in _context.turnos
                              where x.id_sucursal == id_sucursal && x.mixto == 0
                              select new requestTurno()
                              {
                                  disponible = x.disponible,
                                  comida = Clases.Funciones.HoraAString(x.comida),
                                  turno = x.turno1,
                                  descanso = x.descanso,
                                  entrada = Clases.Funciones.HoraAString(x.entrada),
                                  entradaF = Clases.Funciones.HoraAString(x.entradaF),
                                  horas = x.horas,
                                  horasF = x.horasF,
                                  horas_trabajadas = x.horas_trabajadas,
                                  id_turno = x.id_turno,
                                  nocturno = x.nocturno,
                                  id_sucursal = x.id_sucursal,
                                  salida = Clases.Funciones.HoraAString(x.salida),
                                  salidaF = Clases.Funciones.HoraAString(x.salidaF)
                              };

            return await turnosLista.ToListAsync();
        }
        [HttpGet("mixto/{id_sucursal}")]
        public async Task<ActionResult<IEnumerable<requestTurno>>> GetTurno(int id_sucursal, int mixto)
        {
            var turnosLista = from x in _context.turnos
                              where x.id_sucursal == id_sucursal && x.mixto == 1
                              select new requestTurno()
                              {
                                  disponible = x.disponible,
                                  comida = Clases.Funciones.HoraAString(x.comida),
                                  turno = x.turno1,
                                  descanso = x.descanso,
                                  entrada = Clases.Funciones.HoraAString(x.entrada),
                                  entradaF = Clases.Funciones.HoraAString(x.entradaF),
                                  horas = x.horas,
                                  horasF = x.horasF,
                                  horas_trabajadas = x.horas_trabajadas,
                                  id_turno = x.id_turno,
                                  nocturno = x.nocturno,
                                  id_sucursal = x.id_sucursal,
                                  salida = Clases.Funciones.HoraAString(x.salida),
                                  salidaF = Clases.Funciones.HoraAString(x.salidaF)
                              };

            return await turnosLista.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Postchecada(TurnoRequest turnoNuevo)
        {
            turno turnoN = new turno();
            turnoN.turno1 = turnoNuevo.turno;
            turnoN.entradaF = turnoNuevo.entradaF;
            turnoN.entrada = turnoNuevo.entrada;
            turnoN.horas_trabajadas = turnoNuevo.horas_trabajadas;
            turnoN.comida = turnoNuevo.comida;
            turnoN.descanso = turnoNuevo.descanso;
            turnoN.salidaF = turnoNuevo.salidaF;
            turnoN.disponible = turnoNuevo.disponible;
            turnoN.horas = turnoNuevo.horas;
            turnoN.horasF = turnoNuevo.horasF;
            turnoN.id_sucursal = turnoNuevo.id_sucursal;
            turnoN.nocturno = turnoNuevo.nocturno;
            turnoN.salida = turnoNuevo.salida;

            _context.turnos.Add(turnoN);
            await _context.SaveChangesAsync();
            ReturnId ri = new ReturnId(turnoN.id_turno);
            return Ok(ri);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Putchecada(int id, TurnoRequest turnoNuevo)
        {
            if (id != turnoNuevo.id_turno)
            {
                return BadRequest();
            }
            turno turnoN = _context.turnos
            .FirstOrDefault(p => p.id_turno == turnoNuevo.id_turno);             
            try
            {
                turnoN.turno1 = turnoNuevo.turno;
                turnoN.entradaF = turnoNuevo.entradaF;
                turnoN.entrada = turnoNuevo.entrada;
                turnoN.horas_trabajadas = turnoNuevo.horas_trabajadas;
                turnoN.comida = turnoNuevo.comida;
                turnoN.descanso = turnoNuevo.descanso;
                 turnoN.salidaF = turnoNuevo.salidaF;
                turnoN.disponible = turnoNuevo.disponible;
                turnoN.horas = turnoNuevo.horas;
                turnoN.horasF = turnoNuevo.horasF;
                turnoN.id_sucursal = turnoNuevo.id_sucursal;
                turnoN.nocturno = turnoNuevo.nocturno;
                turnoN.salida = turnoNuevo.salida;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!turnoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();        
        
        }
        private bool turnoExists(int id)
        {
            return _context.turnos.Any(e => e.id_turno == id);
        }
        [HttpGet("GetTurnoId/{id}")]
        public async Task<ActionResult<requestTurno>> GetTurnoId(int id)
        {
            var x = await _context.turnos.FindAsync(id);

            if (x == null)
            {
                x = new turno();
            }
            requestTurno tr = new requestTurno()
            {
                disponible = x.disponible,
                comida = Clases.Funciones.HoraAString(x.comida),
                turno = x.turno1,
                descanso = x.descanso,
                entrada = Clases.Funciones.HoraAString(x.entrada),
                entradaF = Clases.Funciones.HoraAString(x.entradaF),
                horas = x.horas,
                horasF = x.horasF,
                horas_trabajadas = x.horas_trabajadas,
                id_turno = x.id_turno,
                nocturno = x.nocturno,
                id_sucursal = x.id_sucursal,
                salida = Clases.Funciones.HoraAString(x.salida),
                salidaF = Clases.Funciones.HoraAString(x.salidaF)
            };


            return tr;
        }

    }
}
