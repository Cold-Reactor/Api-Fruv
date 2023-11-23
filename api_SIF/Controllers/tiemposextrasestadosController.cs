using api_SIF.dbContexts;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class tiemposextrasestadosController : ControllerBase
    {


        private readonly RHDBContext _context;
        public tiemposextrasestadosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiempoExtraEstado>>> GetTiempoExtra()
        {
            var tiempoExtraEstadoLista =_context.tiempoextraestados;
            return await tiempoExtraEstadoLista.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TiempoExtraEstado>> GetTiempoExtra(int id)
        {
            var tiempoextraestado = await _context.tiempoextraestados.FindAsync(id);
            if (tiempoextraestado == null)
            {
                return NotFound();
            }
           
            return tiempoextraestado;
        }
    }
}
