using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.EmpleadosN;
using api_SIF.dbContexts;
using api_SIF.Models;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class trabajotiposController : ControllerBase
    {
        private readonly RHDBContext _context;

        public trabajotiposController(RHDBContext context)
        {
            _context = context;
        }

        // GET: api/trabajotipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrabajoTipoRequest>>> Gettrabajotipos()
        {
            var trabajoTipos = from x in _context.trabajotipos
                 select new TrabajoTipoRequest
                 {
                     id_trabajoT = x.id_trabajoT,
                     trabajoT = x.trabajoT
                 };
            return  trabajoTipos.ToList();
        }

        // GET: api/trabajotipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrabajoTipoRequest>>> Gettrabajotipo(int id)
        {
            var trabajoTipos = from x in _context.trabajotipos
                               select new TrabajoTipoRequest
                               {
                                   id_trabajoT = x.id_trabajoT,
                                   trabajoT = x.trabajoT
                               };
            if (trabajoTipos == null)
            {
                return NotFound();
            }

            return trabajoTipos.Where(x=>x.id_trabajoT==id).ToList();
        }
    }

}
