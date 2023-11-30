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
using System.Text;
using System.Reflection;
using api_SIF.Clases;

namespace api_SIF.Controllers
{

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
                            confianza = x.confianza,
                            //parentesco = x.parentesco,
                            //imagenByte = x.imagen,
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
                                     confianza = x.confianza,
                                     //parentesco = x.parentesco,
                                     //imagenByte = x.imagen,
                                     imagen = x.imagen,

                                     firma = x.firma,
                                     id_rol = x.id_rol,
                                     status = x.status,
                                     externo = x.externo
                                 };

            return await empleadosLista.ToListAsync();
            //return await _context.empleados.ToListAsync();
        }

        [HttpGet("GetProximoEmpleadoPorSucursal/{id_sucursal}")]
        public async Task<ActionResult<Object>> GetProximoEmpleadoPorSucursal(int id_sucursal)
        {
            try
            {
                int maximoValor = _context.empleados
            .Where(e => e.id_sucursal == id_sucursal)
            .Max(e => e.no_empleado);
                return Ok(new {no_empleado= maximoValor + 1 });
            }
            catch (Exception e) {
                return NotFound();
            }
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
                confianza = empleado.confianza,
                //parentesco = empleado.parentesco,
                //imagenByte = empleado.imagen,
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
                confianza = x.confianza,
                 imagen = x.imagen,

                 //parentesco = x.parentesco,
                 //imagenByte = x.imagen,
                 firma = x.firma,
                id_rol = x.id_rol,
                status = x.status,
                externo = x.externo
            };

            return empleado;
        }
        
        // PUT: api/empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id_empleado}")]
        public async Task<IActionResult> Putempleado(int id_empleado, requestEmpleado empleado)
        {
            if (id_empleado != empleado.id_empleado)
            {
                return BadRequest();
            }
            var emp1 = _context.empleados.FirstOrDefault(x => x.id_empleado == id_empleado);
            
            
            //if (empleado.imagen!=null && empleado.imagen.Length>0)
            //{
            //    emp1.imagen = Convert.FromBase64String(empleado.imagen.Replace("data:image/...;base64,", ""));
            //}
            ModificarAtributosNoNulos(emp1,empleado);


            _context.empleados.Update(emp1);
            _context.SaveChanges();

            return NoContent();
        }

        static void ModificarAtributosNoNulos(object objeto, object objetoRequest)
        {
            Type tipoObjeto = objeto.GetType();
            Type tipoObjetoRequest = objetoRequest.GetType();

            PropertyInfo[] propiedades = tipoObjeto.GetProperties();
            PropertyInfo[] propiedadesRequest = tipoObjetoRequest.GetProperties();

            for (int i = 0; i < propiedades.Length ; i++)
            {
                for (int j = 0; j < propiedadesRequest.Length; j++)

                {
                    if (propiedades[i].Name.Equals(propiedadesRequest[j].Name)
                        &&
                        (propiedadesRequest[j].GetValue(objetoRequest) != null && propiedadesRequest[j].GetValue(objetoRequest).Equals(0) && propiedadesRequest[j].GetValue(objetoRequest).Equals(""))
                        
                        )
                    {
                        if (propiedades[i].Name.Equals("imagen"))
                        {
                            propiedades[i].SetValue(objeto, propiedadesRequest[j].GetValue(objetoRequest));

                        }
                        else
                        {
                            propiedades[i].SetValue(objeto, propiedadesRequest[j].GetValue(objetoRequest));
                        }
                        continue;
                    }
                }
                    
                
            }
        }
        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<empleado>> Postempleado(requestEmpleado empleado)
        {
            //byte[] datosBlob = Encoding.UTF8.GetBytes(empleado.imagen);
            //byte[] datosBlob = Convert.FromBase64String(empleado.imagen.Replace("data:image/...;base64,", ""));

            if (empleado==null || empleado.id_empleado>0)
            {
               //return BadRequest();
            }
            var emp1 = new empleado
            {
                email = empleado.email,
                confianza = empleado.confianza,
                apellidoMaterno = empleado.apellidoMaterno,
                apellidoPaterno =empleado.apellidoPaterno,
                bonoProd = empleado.bonoProd,
                carrera = empleado.carrera,
                CP = empleado.CP,
                CURP = empleado.CURP,
                direccion = empleado.direccion,
                estadoCivil =  empleado.estadoCivil,
                externo = empleado.externo,
                fechaIngreso = empleado.fechaIngreso,
                fechaNacimiento = empleado.fechaNacimiento,
                firma = empleado.firma,
                gradoEstudios = empleado.gradoEstudios,
                id_area = empleado.id_area,
                id_ciudad = empleado.id_ciudad,
                id_empleado = empleado.id_empleado,
                id_estado = empleado.id_estado,
                id_empresa = empleado.id_empresa,
                id_nomina = empleado.id_nomina,
                id_puesto = empleado.id_puesto,
                id_rol = empleado.id_rol,
                id_sucursal = empleado.id_sucursal,
                id_turno = empleado.id_turno,
                imagen = empleado.imagen,
                IMSS = empleado.IMSS,
                instituto = empleado.instituto,
                jefeInmediato = empleado.jefeInmediato,
                nombre = empleado.nombre,
                no_empleado = empleado.no_empleado,
                RFC = empleado.RFC,
                salarioDiario = empleado.salarioDiario,
                sexo = empleado.sexo,
                status = empleado.status,
                telefono = empleado.telefono,
                telefonoEmergencias = empleado.telefonoEmergencias,
                titulo = empleado.titulo,
                

            };
            //empleado.no_empleado = this.ObtenerUltimoNumeroEmpleadoMasUno(empleado.id_sucursal);
            
            _context.empleados.Add(emp1);
            await _context.SaveChangesAsync();
            empleado.id_empleado = Funciones.ObtenerUltimoId<empleado>(_context); ;

            return Ok(new { id = empleado.id_empleado});
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
