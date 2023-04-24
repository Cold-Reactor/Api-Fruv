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
            //return await _context.empleados.ToListAsync();
        }
    }
}



