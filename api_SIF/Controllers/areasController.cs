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
    public class areasController : ControllerBase
    {
        private readonly RHDBContext _context;
        public areasController(RHDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestArea>>> Getareas()
        {
            var areasLista = from x in  _context.areas
                             select new requestArea()
                             {  id_area = x.id_area,
                                 id_departamento = x.id_departamento,
                                 area = x.area1
                             };
            return await areasLista.ToListAsync();            
        }
    }
}
