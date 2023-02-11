using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.EmpleadosN;
using api_SIF.dbContexts;

namespace api_SIF.Controllers
{
    [Route("RH/[controller]")]
    [ApiController]
    public class checadasController : ControllerBase
    {
        private readonly RHDBContext _context;

        public checadasController(RHDBContext context)
        {
            _context = context;
        }

        // GET: api/checadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestChecadas>>> Getchecadas()
        {

            var checadoresLista = from x in _context.checadas
                                  select new requestChecadas()
                                  {

                                      id_checador = x.id_checador,
                                     nomina= x.nomina,
                                     fecha= x.fecha,
                                     fechaHora= x.fechaHora,
                                     hora= x.hora,  
                                     id_checadas = x.id_checadas    ,
                                     id_empleado = x.id_empleado,
                                     
                                     
                                  };
            return await checadoresLista.ToListAsync();
        }

        // GET: api/checadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requestChecadas>> Getchecada(int id)
        {
            var checada = await _context.checadas.FindAsync(id);

            if (checada == null)
            {
                return NotFound();
            }
            var reqChecada =  new requestChecadas()
            {

                id_checador = checada.id_checador,
                nomina = checada.nomina,
                fecha = checada.fecha,
                fechaHora = checada.fechaHora,
                hora = checada.hora,
                id_checadas = checada.id_checadas,
                id_empleado = checada.id_empleado,


            };
            return reqChecada;
        }

        [HttpGet("getEmpleadoChecadas/{from1}/{to}")]
        public async Task<ActionResult<IEnumerable<requestEmpleadoChecadas>>> GetEmpleadoChecadasint (DateOnly from1, DateOnly to)
        {
            List<DateOnly> fechas = new List<DateOnly>();
            DateOnly date1 = from1;
            while (date1>=from1 && date1<=to)
            {
                fechas.Add(date1);
                date1= date1.AddDays(1);

            }
            List<requestCheck> checks = (from c in _context.checadas
                                         where c.fecha >=from1 && c.fecha<=to
                                         select new requestCheck
                                         {
                                             
                                             id = c.id_checadas,
                                             fecha=c.fecha,
                                             hora = c.hora.ToString("HH:mm:ss"),
                                             horaM = c.fechaHora,
                                             nomina = (int)c.nomina,
                                             id_empleado = c.id_empleado

                                         }).ToList();

            List<requestChecadaCheck> checadas1 = new List<requestChecadaCheck>();

           

            /*var checks = (from ch in _context.checadas

                          where ch.fecha >= from1 && ch.fecha <= to
                          select new
                          {
                              fecha = ch.fecha,
                              id_empleado = ch.id_empleado,
                              ausentismo = "",
                              extra = 0,
                          } into x
                          group x by new { x.fecha, x.id_empleado, x.ausentismo, x.extra } into g
                          select new requestChecadaCheck
                          {
                              id_empleado=g.Key.id_empleado,
                              ausentismo = g.Key.ausentismo,
                              extra = g.Key.extra,
                              fecha = g.Key.fecha,
                              checks = (from c in _context.checadas
                                        where c.fecha == g.Key.fecha && g.Key.id_empleado == c.id_empleado
                                        select new requestCheck
                                        {
                                            id = c.id_checadas,
                                            hora = c.hora,
                                            horaM = c.fechaHora,
                                            nomina = (int)c.nomina,
                                            id_empleado=c.id_empleado
                                            
                                        }).ToList()
                          }).ToList();
            ;
            */

            var empleados = (from p in _context.empleados 
                             
                             where p.status==1 && p.id_sucursal==9
                             select new requestEmpleadoChecadas
                             {
                                 id = p.id_empleado,
                                 noEmpleado = p.no_empleado,
                                 nombre = p.apellidoPaterno + " " + p.apellidoMaterno + " " + p.nombre,
                                 turno = p.id_turno.ToString(),
                                 area = p.id_area.ToString(),
                                 precencial = (int)p.presencial,
                                 //checadas = checadas1.Where(x=>x.id_empleado==p.id_empleado).ToList()

                                 //(from ch in _context.checadas

                                 // where ch.fecha >= from1 && ch.fecha <= to && ch.id_empleado==p.id_empleado
                                 // //select new
                                 // //{
                                 // //    fecha = ch.fecha,
                                 // //    id_empleado = ch.id_empleado,
                                 // //    ausentismo = "",
                                 // //    extra = 0,
                                 // //} into x
                                 // //group x by new { x.fecha, x.id_empleado, x.ausentismo, x.extra } into g
                                 // select new requestChecadaCheck
                                 // {
                                 //     id_empleado = ch.id_empleado,
                                 //     ausentismo = "",
                                 //     extra = 0,
                                 //     fecha = ch.fecha,
                                 //     checks = (from c in _context.checadas
                                 //               where c.fecha == ch.fecha && ch.id_empleado == c.id_empleado
                                 //               select new requestCheck
                                 //               {
                                 //                   id = c.id_checadas,
                                 //                   hora = c.hora,
                                 //                   horaM = c.fechaHora,
                                 //                   nomina = (int)c.nomina,
                                 //                   id_empleado = c.id_empleado

                                 //               }).ToList()
                                 // }).ToList()


                             }).ToList();

            foreach(var empleado in empleados)
            {
                var checadasEmpleados = new List<requestChecadaCheck>();

                foreach (var fecha in fechas)
                {
                    var checadaEmpleado = new requestChecadaCheck();
                    checadaEmpleado.fecha = fecha;
                    checadaEmpleado.extra = 0;
                    checadaEmpleado.ausentismo = "";
                    
                    var checksEmpleado = new List<requestCheck>();

                    foreach (var check in checks) {
                        if (check.fecha==fecha) {
                            if (empleado.id == check.id_empleado)
                            {
                                requestCheck ch = new requestCheck();
                                ch.id = check.id;
                                ch.fecha = check.fecha;
                                ch.hora = check.hora;
                                ch.horaM = check.horaM;
                                ch.nomina = check.nomina;
                                //ch.id_empleado = check.id_empleado;
                                checksEmpleado.Add(ch);
                            }
                        }
                     }
                    checadaEmpleado.checks = checksEmpleado;
                    checadasEmpleados.Add(checadaEmpleado);


                    
                }
                
                empleado.checadas = checadasEmpleados;
            }
            /*var checadas = (from ch in _context.checadas
                            
                             where ch.fecha >= from1 && ch.fecha <= to && ch.id_empleado==1
                            select new
                            {
                                fecha = ch.fecha,
                                id_empleado =ch.id_empleado,
                                ausentismo = "",
                                extra = 0,
                            } into x
                             group x by new { x.fecha,x.id_empleado,x.ausentismo,x.extra } into g 
                          select new requestChecadaCheck
                             {
                              ausentismo = g.Key.ausentismo,
                              extra = g.Key.extra,
                              fecha = g.Key.fecha,
                              checks = (from c in _context.checadas
                                        where c.fecha == g.Key.fecha && g.Key.id_empleado == c.id_empleado
                                        select new requestCheck
                                        {
                                            id = c.id_checadas,
                                            hora = c.hora,
                                            horaM = c.fechaHora,
                                            nomina = (int)c.nomina

                                        }).ToList()

                          }).ToList();*/

            return empleados;
        }
        // PUT: api/checadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putchecada(int id, checada checada)
        {
            if (id != checada.id_checadas)
            {
                return BadRequest();
            }

            _context.Entry(checada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!checadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/checadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<checada>> Postchecada(checada checada)
        {
            _context.checadas.Add(checada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getchecada", new { id = checada.id_checadas }, checada);
        }

        // DELETE: api/checadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletechecada(int id)
        {
            var checada = await _context.checadas.FindAsync(id);
            if (checada == null)
            {
                return NotFound();
            }

            _context.checadas.Remove(checada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool checadaExists(int id)
        {
            return _context.checadas.Any(e => e.id_checadas == id);
        }
    }
}
