using api_SIF.Clases;
using api_SIF.dbContexts;
using api_SIF.Models.Empleados;
using api_SIF.Models.EmpleadosN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadosHistorialController : ControllerBase
    {
        private readonly RHDBContext _context;
        public empleadosHistorialController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<empleadohistorial>>> GetEmpleadosHistorial()
        {
            var Lista = _context.empleadohistorials;
            return await Lista.ToListAsync();
        }
        [HttpPost]
        public ActionResult<empleadohistorial> PostEmpleadoHistorial(empleadohistorial req)
        {
            var entidadExistente = _context.empleadohistorials.SingleOrDefault(e => e.id_empleadoHistorial == req.id_empleadoHistorial);
            if (entidadExistente == null)
            {
                var reqEmpleadoHistorial = new empleadohistorial()
                {
                    fecha = req.fecha,
                    id_empleado = req.id_empleado,
                    id_tipoBaja = req.id_tipoBaja,
                    id_puesto = req.id_puesto,
                    razon = req.razon,
                    salario = req.salario
                };
                _context.empleadohistorials.Add(req);
                _context.SaveChanges();
                req.id_empleadoHistorial = Funciones.ObtenerUltimoId<empleadohistorial>(_context);
            }
            else
            {
                req.id_empleadoHistorial = entidadExistente.id_empleadoHistorial;
                entidadExistente.fecha = req.fecha;
                entidadExistente.id_empleado = req.id_empleado;
                entidadExistente.id_tipoBaja = req.id_tipoBaja;
                entidadExistente.id_puesto = req.id_puesto;
                entidadExistente.razon = req.razon;
                entidadExistente.salario = req.salario;
                _context.SaveChanges();
            }
            return Ok(new { id = req.id_empleadoHistorial });
        }
    }
}
