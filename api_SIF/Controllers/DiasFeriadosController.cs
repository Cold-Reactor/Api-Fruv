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
    public class DiasFeriadosController : ControllerBase
    {
        private readonly RHDBContext _context;

        public DiasFeriadosController(RHDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<diasferiado>> GetDiasFeriados()
        {
            var diasFeriados = _context.diasferiados.ToList();

            return diasFeriados;

        }

        [HttpPost]
        public ActionResult<diasferiado> PostDiasFeriados(diasferiado diasFeriados)
        {
            _context.diasferiados.Add(diasFeriados);
            _context.SaveChanges();

            return Ok(new { id = diasFeriados.id_diasFeriados });
        }

        [HttpDelete("{id_diaFeriado}")]
        public ActionResult<diasferiado> DeleteDiasFeriados(int id_diaFeriado)
        {
            var diasFeriados = _context.diasferiados.FirstOrDefault(e => e.id_diasFeriados == id_diaFeriado);
            if (diasFeriados == null)
            {
                return NotFound();
            }
            _context.diasferiados.Remove(diasFeriados);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id_diasFeriados}")]
        public ActionResult<diasferiado> GetDiasFeriados(int id_diasFeriados)
        {
            var diasFeriados = _context.diasferiados.FirstOrDefault(e => e.id_diasFeriados == id_diasFeriados);

            if (diasFeriados == null)
            {
                return NotFound();
            }

            return diasFeriados;
        }
        [HttpPut("{id_diasFeriados}")]
        public ActionResult<diasferiado> PutDiasFeriados(int id_diasFeriados, diasferiado diasFeriados)
        {
            if (id_diasFeriados != diasFeriados.id_diasFeriados)
            {
                return BadRequest();
            }
            _context.Entry(diasFeriados).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
    }
}
