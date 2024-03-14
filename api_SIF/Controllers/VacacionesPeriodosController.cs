using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class VacacionesPeriodosController : ControllerBase
    {
        private readonly RHDBContext _context;

        public VacacionesPeriodosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetVacacionesPeriodos()
        {
            var vacacionesPeriodos = _context.vacacionesperiodos.ToList();
            return Ok(vacacionesPeriodos);
        }
        [HttpGet("{id}")]
        public ActionResult GetVacacionesPeriodo(int id)
        {
            var vacacionesPeriodo = _context.vacacionesperiodos.FirstOrDefault(p => p.id_vacacionesP == id);
            if (vacacionesPeriodo == null)
            {
                return NotFound();
            }
            return Ok(vacacionesPeriodo);
        }
        [HttpGet("Periodo/{periodo}")]
        public async Task<ActionResult<Object>> GetVacacionesPeriodoDias(int periodo)
        {
            try
            {
                int dias = _context.vacacionesperiodos.FirstOrDefault(p => p.años == periodo).dias;
                return Ok(new { dias = dias });
            }
            catch (Exception e)
            {
                return Ok(new { dias = 0 });
            }
        }
        [HttpPost]
        public ActionResult CreateVacacionesPeriodo(vacacionesperiodo vacacionesPeriodo)
        {
            _context.vacacionesperiodos.Add(vacacionesPeriodo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVacacionesPeriodo), new { id = vacacionesPeriodo.id_vacacionesP }, vacacionesPeriodo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateVacacionesPeriodo(int id, vacacionesperiodo vacacionesPeriodo)
        {
            if (id != vacacionesPeriodo.id_vacacionesP)
            {
                return BadRequest();
            }
            var existingVacacionesPeriodo = _context.vacacionesperiodos.FirstOrDefault(p => p.id_vacacionesP == id);
            if (existingVacacionesPeriodo == null)
            {
                return NotFound();
            }
            existingVacacionesPeriodo.pago = vacacionesPeriodo.pago;
            existingVacacionesPeriodo.años = vacacionesPeriodo.años;
            existingVacacionesPeriodo.dias = vacacionesPeriodo.dias;
            _context.vacacionesperiodos.Update(existingVacacionesPeriodo);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
