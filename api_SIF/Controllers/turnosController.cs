using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                                  comida = x.comida,
                                  turno = x.turno1,
                                  descanso = x.descanso,
                                  entrada = x.entrada,
                                  entradaF = x.entradaF,
                                  horas = x.horas,
                                  horasF = x.horasF,
                                  horas_trabajadas = x.horas_trabajadas,
                                  id_turno = x.id_turno,
                                  nocturno = x.nocturno,
                                  salida = x.salida,
                                  salidaF = x.salidaF
                              };

            return await turnosLista.ToListAsync();
            //return await _context.empleados.ToListAsync();
        }


    }
}
