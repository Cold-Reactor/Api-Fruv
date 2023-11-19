using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models.EmpleadosN;
using api_SIF.dbContexts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;

namespace api_SIF.Controllers
{
    [Authorize]

    [Route("RH/[controller]")]
    [ApiController]
    public class empleadosController : ControllerBase
    {
        private readonly RHDBContext _context;

        public empleadosController(RHDBContext context)
        {
            _context = context;
        }

        // GET: api/empleados
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requestEmpleado>>> Getempleados()
        {
            var empleadosLista = from x in _context.empleados
                        select new requestEmpleado()
                        {
     
                            id_empleado = x.id_empleado,
                            no_empleado = x.no_empleado,
                            nombre = x.nombre,
                            apellidoPaterno = x.apellidoPaterno,
                            apellidoMaterno = x.apellidoMaterno,
                            estadoCivil = x.estadoCivil,
                            sexo = x.sexo,
                            fechaNacimiento = x.fechaNacimiento,
                            IMSS = x.IMSS,
                            telefono = x.telefono,
                            telefonoEmergencias = x.telefonoEmergencias,
                            email = x.email,
                            CURP = x.CURP,
                            RFC = x.RFC,
                            id_ciudad = x.id_ciudad,
                            id_estado = x.id_estado,
                            direccion = x.direccion,
                            CP = x.CP,
                            gradoEstudios = x.gradoEstudios,
                            carrera = x.carrera,
                            instituto = x.instituto,
                            titulo = x.titulo,
                            id_empleadoTipo = 0,//x.id_empleadoTipo,
                            id_puesto = x.id_puesto,
                            jefeInmediato = x.jefeInmediato,
                            id_turno = x.id_turno,
                            salarioDiario = x.salarioDiario,
                            id_nomina = x.id_nomina,
                            fechaIngreso = x.fechaIngreso,
                            id_empresa = x.id_empresa,
                            id_sucursal = x.id_sucursal,
                            presencial = x.presencial,
                            //parentesco = x.parentesco,
                            imagen = x.imagen,
                            firma = x.firma,
                            id_rol = x.id_rol,
                            status = x.status,
                            externo = x.externo
                        };

            return await empleadosLista.ToListAsync();
            //return await _context.empleados.ToListAsync();
        }
        
        [HttpGet("GetempleadosPorSucursal/{id_sucursal}")]
        public async Task<ActionResult<IEnumerable<requestEmpleado>>> GetempleadosPorSucursal(int id_sucursal)
        {
            var empleadosLista = from x in _context.empleados.Where(x=>x.id_sucursal==id_sucursal)
                                 select new requestEmpleado()
                                 {

                                     id_empleado = x.id_empleado,
                                     no_empleado = x.no_empleado,
                                     nombre = x.nombre,
                                     apellidoPaterno = x.apellidoPaterno,
                                     apellidoMaterno = x.apellidoMaterno,
                                     estadoCivil = x.estadoCivil,
                                     sexo = x.sexo,
                                     fechaNacimiento = x.fechaNacimiento,
                                     IMSS = x.IMSS,
                                     telefono = x.telefono,
                                     telefonoEmergencias = x.telefonoEmergencias,
                                     email = x.email,
                                     CURP = x.CURP,
                                     RFC = x.RFC,
                                     id_ciudad = x.id_ciudad,
                                     id_estado = x.id_estado,
                                     direccion = x.direccion,
                                     CP = x.CP,
                                     gradoEstudios = x.gradoEstudios,
                                     carrera = x.carrera,
                                     instituto = x.instituto,
                                     titulo = x.titulo,
                                     id_empleadoTipo =0,// x.id_empleadoTipo,
                                     id_puesto = x.id_puesto,
                                     jefeInmediato = x.jefeInmediato,
                                     id_turno = x.id_turno,
                                     salarioDiario = x.salarioDiario,
                                     id_nomina = x.id_nomina,
                                     fechaIngreso = x.fechaIngreso,
                                     id_empresa = x.id_empresa,
                                     id_sucursal = x.id_sucursal,
                                     presencial = x.presencial,
                                     //parentesco = x.parentesco,
                                     imagen = x.imagen,
                                     firma = x.firma,
                                     id_rol = x.id_rol,
                                     status = x.status,
                                     externo = x.externo
                                 };

            return await empleadosLista.ToListAsync();
            //return await _context.empleados.ToListAsync();
        }
        

        // GET: api/empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requestEmpleado>> Getempleado(int id)
        {
            var empleado = await _context.empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }
            var reqEmpleado = new requestEmpleado()
            {
                id_empleado = empleado.id_empleado,
                no_empleado = empleado.no_empleado,
                nombre = empleado.nombre,
                apellidoPaterno = empleado.apellidoPaterno,
                apellidoMaterno = empleado.apellidoMaterno,
                estadoCivil = empleado.estadoCivil,
                sexo = empleado.sexo,
                fechaNacimiento = empleado.fechaNacimiento,
                IMSS = empleado.IMSS,
                telefono = empleado.telefono,
                telefonoEmergencias = empleado.telefonoEmergencias,
                email = empleado.email,
                CURP = empleado.CURP,
                RFC = empleado.RFC,
                id_ciudad = empleado.id_ciudad,
                id_estado = empleado.id_estado,
                direccion = empleado.direccion,
                CP = empleado.CP,
                gradoEstudios = empleado.gradoEstudios,
                carrera = empleado.carrera,
                instituto = empleado.instituto,
                titulo = empleado.titulo,
                id_empleadoTipo =0,// empleado.id_empleadoTipo,
                id_puesto = empleado.id_puesto,
                jefeInmediato = empleado.jefeInmediato,
                id_turno = empleado.id_turno,
                salarioDiario = empleado.salarioDiario,
                id_nomina = empleado.id_nomina,
                fechaIngreso = empleado.fechaIngreso,
                id_empresa = empleado.id_empresa,
                id_sucursal = empleado.id_sucursal,
                presencial = empleado.presencial,
                //parentesco = empleado.parentesco,
                imagen = empleado.imagen,
                firma = empleado.firma,
                id_rol = empleado.id_rol,
                status = empleado.status,
                externo = empleado.externo
            };
            return reqEmpleado;
        }
        
        // GET: api/empleados/5/9
        [HttpGet("{noEmpleado}/{id_sucursal}")]
        public async Task<IEnumerable<requestEmpleado>> Getempleado(int noEmpleado,int id_sucursal)
        {
            var empleado = from x in _context.empleados.Where(x=>x.no_empleado==noEmpleado && x.id_sucursal==id_sucursal)                        
             select new requestEmpleado()
            {
                id_empleado = x.id_empleado,
                no_empleado = x.no_empleado,
                nombre = x.nombre,
                apellidoPaterno = x.apellidoPaterno,
                apellidoMaterno =   x.apellidoMaterno,
                estadoCivil = x.estadoCivil,
                sexo = x.sexo,
                fechaNacimiento = x.fechaNacimiento,
                IMSS = x.IMSS,
                telefono = x.telefono,
                telefonoEmergencias = x.telefonoEmergencias,
                email = x.email,
                CURP = x.CURP,
                RFC = x.RFC,
                id_ciudad = x.id_ciudad,
                id_estado = x.id_estado,
                direccion = x.direccion,
                CP = x.CP,
                gradoEstudios = x.gradoEstudios,
                carrera = x.carrera,
                instituto = x.instituto,
                titulo = x.titulo,
                id_empleadoTipo = 0,//x.id_empleadoTipo,
                id_puesto = x.id_puesto,
                jefeInmediato = x.jefeInmediato,
                id_turno = x.id_turno,
                salarioDiario = x.salarioDiario,
                id_nomina = x.id_nomina,
                fechaIngreso = x.fechaIngreso,
                id_empresa = x.id_empresa,
                id_sucursal = x.id_sucursal,
                presencial = x.presencial,
                //parentesco = x.parentesco,
                imagen = x.imagen,
                firma = x.firma,
                id_rol = x.id_rol,
                status = x.status,
                externo = x.externo
            };

            return empleado;
        }
        
        // PUT: api/empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putempleado(int id, empleado empleado)
        {
            if (id != empleado.id_empleado)
            {
                return BadRequest();
            }
            _context.Entry(empleado).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empleadoExists(id))
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
        
        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<empleado>> Postempleado(empleado empleado)
        {
            if (empleado==null || empleado.id_empleado>0)
            {
                return BadRequest();
            }
            empleado.no_empleado = this.ObtenerUltimoNumeroEmpleadoMasUno(empleado.id_sucursal);
            
            _context.empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getempleado", new { id = empleado.id_empleado,no_empleado=empleado.no_empleado }, empleado);
        }
        
        // DELETE: api/empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteempleado(int id)
        {
            var empleado = await _context.empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            _context.empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
       
        private int ObtenerUltimoNumeroEmpleadoMasUno(int? id_sucursal)
        {
            // Utiliza la función Max para obtener el valor máximo actual
            int? ultimoValor = _context.empleados.Where(e => e.id_sucursal == id_sucursal).Max(e => (int?)e.no_empleado);

            // Si no hay valores en la tabla, establece el valor inicial en 1
            if (!ultimoValor.HasValue)
            {
                return 1;
            }

            // Suma uno al último valor obtenido
            return ultimoValor.Value + 1;
        }
        private bool empleadoExists(int id)
        {
            return _context.empleados.Any(e => e.id_empleado == id);
        }
    }
}
