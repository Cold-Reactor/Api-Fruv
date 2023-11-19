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
    public class departamentosController : ControllerBase
    {
        private readonly RHDBContext _context;

        public departamentosController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestDepartamento>>> Getdepartamentos()
        {
            var departamentosLista = from x in _context.departamentos
                                     select new requestDepartamento()
                                     {
                                         id_departamento = x.id_departamento,
                                         departamento = x.departamento1                                         
                                     };
            return await departamentosLista.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<requestDepartamento>> GetDepartamento(int id)
        {
            var depto = await _context.departamentos.FindAsync(id);
            if (depto == null)
            {
                return NotFound();
            }
            var reqDepto = new requestDepartamento()
            {
                departamento = depto.departamento1,
                id_departamento = depto.id_departamento,

            };
            return reqDepto;
;
        }
        [HttpPost]
        public async Task<ActionResult<requestDepartamento>> PostDepartamentos(requestDepartamento reqDepto)
        {
            var entidadExistente = _context.departamentos.SingleOrDefault(e => e.id_departamento == reqDepto.id_departamento);
            if (entidadExistente == null)
            {
                var reqDepto2 = new departamento()
                {
                    departamento1 = reqDepto.departamento,
                };
                _context.departamentos.Add(reqDepto2);
                _context.SaveChanges();
                reqDepto.id_departamento = Funciones.ObtenerUltimoId<departamento>(_context);
            }
            else
            {
                entidadExistente.departamento1 = reqDepto.departamento;
                entidadExistente.id_departamento = reqDepto.id_departamento;
                _context.SaveChanges();
                reqDepto.id_departamento = entidadExistente.id_departamento;


            }
            return Ok(new { id = reqDepto.id_departamento });
        }
    }
}



