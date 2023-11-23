using api_SIF.Clases;
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
    public class empleadosTiposController : ControllerBase
    {
        private readonly RHDBContext _context;
        public empleadosTiposController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoTipo>>> GetEmpleadosTipos()
        {
            var empleadosTiposLista = _context.empleadotipos;
            return await empleadosTiposLista.ToListAsync();
        }

        [HttpPost]
        public ActionResult<EmpleadoTipo> PostEmpleadosTipos(EmpleadoTipo reqEmpleadoTipo)
        {
            var entidadExistente = _context.empleadotipos.SingleOrDefault(e => e.id_empleadoT == reqEmpleadoTipo.id_empleadoT);
            if (entidadExistente == null)
            {
                _context.empleadotipos.Add(reqEmpleadoTipo);
                _context.SaveChanges();
                reqEmpleadoTipo.id_empleadoT = Funciones.ObtenerUltimoId<Ciudad>(_context);
            }
            else
            {
                reqEmpleadoTipo.id_empleadoT = entidadExistente.id_empleadoT;
                entidadExistente.empleadoT = reqEmpleadoTipo.empleadoT;
                _context.SaveChanges();

            }
            return Ok(new { id = reqEmpleadoTipo.id_empleadoT });
        }



    }
}
