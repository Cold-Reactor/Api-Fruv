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
    public class empresasController : ControllerBase
    {

        private readonly RHDBContext _context;
        public empresasController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> Getempresas()
        {
            var empresasLista = _context.empresas.ToListAsync();
            return await empresasLista;
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(string nombre)
        {
            var empresa = _context.empresas.SingleOrDefault(x=>x.empresa==nombre);
            if (empresa == null)
            {
                return NotFound();
            }
            
            return empresa;
        }
        [HttpPost]
        public async Task<ActionResult<Empresa>> Postarea(Empresa reqEmpresa)
        {
            var entidadExistente = _context.empresas.SingleOrDefault(e => e.id_empresa == reqEmpresa.id_empresa);
            if (entidadExistente == null)
            {
                var reqempresaN = new Empresa()
                {
                    id_empresa = reqEmpresa.id_empresa,
                    empresa = reqEmpresa.empresa,
                };
                _context.empresas.Add(reqempresaN);
                _context.SaveChanges();
                reqEmpresa.id_empresa = Funciones.ObtenerUltimoId<Empresa>(_context);
            }
            else
            {
                reqEmpresa.id_empresa = entidadExistente.id_empresa;
                entidadExistente.empresa = reqEmpresa.empresa;
                _context.SaveChanges();

            }
            return Ok(new { id = reqEmpresa.id_empresa });
        }

    }
}
