using api_SIF.dbContexts;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class tiemposExtrasController : ControllerBase
    {
        private readonly RHDBContext _context;

        public tiemposExtrasController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TiempoExtra>> GettiemposExtras()
        {
            var Lista = _context.tiempoextras;
            return Lista.ToList();            
        }
        [HttpGet]
        [Route("{id_tiempoExtra}")]
        public ActionResult<TiempoExtra> GettiempoExtra(int id_tiempoExtra)
        {
            var tiempoExtra = _context.tiempoextras.FirstOrDefault(t => t.id_tiempoExtra == id_tiempoExtra);
            if (tiempoExtra == null)
            {
                tiempoExtra = new TiempoExtra();
            }
            return tiempoExtra;
        }
        [HttpPost]
        public ActionResult<TiempoExtra> CreatetiempoExtra(TiempoExtra tiempoExtra)
        {
            _context.tiempoextras.Add(tiempoExtra);
            _context.SaveChanges();
            return Ok(new { id = tiempoExtra.id_tiempoExtra });
        }
        [HttpPut("{id}")]
        public IActionResult UpdatetiempoExtra(int id, TiempoExtra tiempoExtra)
        {
            if (id != tiempoExtra.id_tiempoExtra)
            {
                return BadRequest();
            }
            _context.Entry(tiempoExtra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("sucursal/{id_sucursal}/{id_estado}")]
        public ActionResult<IEnumerable<TiempoExtra>> GetTiempoExtraBySucursal(int id_sucursal,string id_estado)
        {
            var Lista = _context.tiempoextras
                .Join(_context.empleados, p => p.id_supervisor, e => e.id_empleado, (p, e) => new { p, e })
                .Where(pe => pe.e.id_sucursal == id_sucursal)
                .Select(pe => pe.p).ToList();
            if (int.TryParse(id_estado, out int result1))
            {
                if (result1 >= 0)
                {
                   Lista = Lista.Where(p => p.id_estado == result1).ToList();
                }
            }
            
            return Lista;
        }

        [HttpGet("next")]
        public ActionResult<int> GetNextIdTiempoExtra()
        {
            var nextId = 1;
            if (_context.tiempoextras.Count() > 0)
            {
                nextId = _context.tiempoextras.Max(s => s.id_tiempoExtra) + 1;
            }

            return Ok(nextId);
        }



    }
}
