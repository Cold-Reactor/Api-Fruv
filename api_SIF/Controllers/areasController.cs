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
        [HttpGet("{id}")]
        public async Task<ActionResult<requestArea>> GetArea(int id)
        {
            var area = await _context.areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            var reqArea = new requestArea()
            {
                id_area = area.id_area,
                id_departamento = area.id_departamento,
                area = area.area1,
               
            };
            return reqArea;
        }
        [HttpPost]
        public ActionResult<requestArea> Postarea(requestArea reqArea)
        {
            var entidadExistente = _context.areas.SingleOrDefault(e => e.id_area == reqArea.id_area);
            if (entidadExistente == null)
            {
                var reqAreaN = new area()
                {
                    id_area = reqArea.id_area,
                    id_departamento = reqArea.id_departamento,
                    area1 = reqArea.area,
                };
                _context.areas.Add(reqAreaN);
                _context.SaveChanges();
                reqArea.id_area = Funciones.ObtenerUltimoId<area>(_context);
            }
            else
            {
                reqArea.id_area = entidadExistente.id_area;
                entidadExistente.area1 = reqArea.area;
                entidadExistente.id_departamento = reqArea.id_departamento;
                _context.SaveChanges();

            }
            return Ok(new { id = reqArea.id_area });
        }
    }
}
