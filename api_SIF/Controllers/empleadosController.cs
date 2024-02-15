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
using api_SIF.Services;

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
                            id_area = x.id_area,

                            id_rol = x.id_rol,
                            status = x.status,
                            externo = x.externo,
                            discapacidad = x.discapacidad,
                        };

            return await empleadosLista.ToListAsync();
            //return await _context.empleados.ToListAsync();
        }
        
        [HttpGet("GetempleadosPorSucursal/{id_sucursal}")]
        public async Task<ActionResult<IEnumerable<requestEmpleado>>> GetempleadosPorSucursal(int id_sucursal)
        {
            var empleadosLista = from x in _context.empleados.Where(x => x.id_sucursal == id_sucursal)
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
                                     id_empleadoTipo = 0,// x.id_empleadoTipo,
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
                                     id_area = x.id_area,

                                     firma = x.firma,
                                     id_rol = x.id_rol,
                                     status = x.status,
                                     externo = x.externo,
                                     discapacidad = x.discapacidad,
                                 };

            return await empleadosLista.ToListAsync();
        //return await _context.empleados.ToListAsync();
    }
    [HttpGet("Getempleados/{id_empresa}/{id_sucursal}/{id_departamento}/{id_area}/{id_turno}/{status}")]
        public async Task<ActionResult<IEnumerable<requestEmpleado>>> Getempleados(int id_empresa, string id_sucursal, string id_departamento, string id_area, string id_turno,string status)
        {
            var empleadosLista = from x in _context.empleados.Where(x => x.id_empresa == id_empresa)
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
                                     id_empleadoTipo = 0,// x.id_empleadoTipo,
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
                                     id_area = x.id_area,

                                     firma = x.firma,
                                     id_rol = x.id_rol,
                                     status = x.status,
                                     externo = x.externo,
                                     discapacidad = x.discapacidad,
                                 };
            if (int.TryParse(status, out int result5))
            {
                empleadosLista = empleadosLista.Where(x => x.status == result5);
            }
            if (int.TryParse(id_sucursal, out int result4) && result4 != 0)
            {
                empleadosLista = empleadosLista.Where(x => x.id_sucursal == result4);
            }
            if (int.TryParse(id_area, out int result) && result != 0)
            {
                empleadosLista = empleadosLista.Where(x => x.id_area == result);
            }
            if (int.TryParse(id_turno, out int result2) && result2 != 0)
            {
                empleadosLista = empleadosLista.Where(x => x.id_turno == result2);
            }
            if (int.TryParse(id_departamento, out int result3) && result3 != 0)
            {
                var areasLista = _context.areas.Where<area>(xx => xx.id_departamento == result3).Select(ts => ts.id_area).ToList();
                empleadosLista = empleadosLista.Where(x => areasLista.Contains((int)x.id_area));
            }

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
                return Ok(new { no_empleado = 0 });
            }
        }


        // GET: api/empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requestEmpleado>> Getempleado(int id)
        {
            var empleado = await _context.empleados.FindAsync(id);

            
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
                bonoProd = empleado.bonoProd,
                id_nomina = empleado.id_nomina,
                fechaIngreso = empleado.fechaIngreso,
                id_empresa = empleado.id_empresa,
                id_sucursal = empleado.id_sucursal,
                confianza = empleado.confianza,
                //parentesco = empleado.parentesco,
                //imagenByte = empleado.imagen,
                imagen = empleado.imagen,
                id_area = empleado.id_area,

                firma = empleado.firma,
                id_rol = empleado.id_rol,
                status = empleado.status,
                externo = empleado.externo,
                discapacidad = empleado.discapacidad,
            };
            return reqEmpleado;
        }
        
        // GET: api/empleados/5/9
        [HttpGet("{noEmpleado}/{id_sucursal}")]
        public async Task<ActionResult<requestEmpleado>> Getempleado(int noEmpleado,int id_sucursal)
        {
            var x = _context.empleados.FirstOrDefault(x => x.no_empleado == noEmpleado && x.id_sucursal == id_sucursal);
            if (x == null)
            {
                return new requestEmpleado();
            }
            requestEmpleado empleadoReq = new requestEmpleado()
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
                imagen = x.imagen,
                id_area = x.id_area,

                //parentesco = x.parentesco,
                //imagenByte = x.imagen,
                firma = x.firma,
                id_rol = x.id_rol,
                status = x.status,
                externo = x.externo,
                discapacidad = x.discapacidad,
            };
            
            return empleadoReq;
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

            #region validacionesParaActualizarRegistros
            if (empleado.nombre != null && empleado.nombre.Length > 0)
            {
                emp1.nombre = empleado.nombre;
            }
            if (empleado.apellidoPaterno != null && empleado.apellidoPaterno.Length > 0)
            {
                emp1.apellidoPaterno = empleado.apellidoPaterno;
            }
            if (empleado.apellidoMaterno != null && empleado.apellidoMaterno.Length > 0)
            {
                emp1.apellidoMaterno = empleado.apellidoMaterno;
            }
            if (empleado.estadoCivil != null && empleado.estadoCivil.Length > 0)
            {
                emp1.estadoCivil = empleado.estadoCivil;
            }
            if (empleado.sexo != null && empleado.sexo.Length > 0)
            {
                emp1.sexo = empleado.sexo;
            }



            if (empleado.fechaNacimiento != null )
            {
                emp1.fechaNacimiento = empleado.fechaNacimiento;
            }
            if (empleado.IMSS != null && empleado.IMSS.Length > 0)
            {
                emp1.IMSS = empleado.IMSS;
            }
            if (empleado.telefono != null && empleado.telefono.Length > 0)
            {
                emp1.telefono = empleado.telefono;
            }


            if (empleado.telefonoEmergencias != null && empleado.telefonoEmergencias.Length > 0)
            {
                emp1.telefonoEmergencias = empleado.telefonoEmergencias;
            }
            if (empleado.email != null && empleado.email.Length > 0)
            {
                emp1.email = empleado.email;
            }
            if (empleado.CURP != null && empleado.CURP.Length > 0)
            {
                emp1.CURP = empleado.CURP;
            }
            if (empleado.RFC != null && empleado.RFC.Length > 0)
            {
                emp1.RFC = empleado.RFC;
            }
            if (empleado.id_ciudad != null && empleado.id_ciudad > 0)
            {
                emp1.id_ciudad = empleado.id_ciudad;
            }
            if (empleado.id_estado != null && empleado.id_estado > 0)
            {
                emp1.id_estado = empleado.id_estado;
            }
            if (empleado.direccion != null && empleado.direccion.Length > 0)
            {
                emp1.direccion = empleado.direccion;
            }
            if (empleado.CP != null && empleado.CP > 0)
            {
                emp1.CP = empleado.CP;
            }
            if (empleado.gradoEstudios != null && empleado.gradoEstudios.Length > 0)
            {
                emp1.gradoEstudios = empleado.gradoEstudios;
            }
            if (empleado.carrera != null && empleado.carrera.Length > 0)
            {
                emp1.carrera = empleado.carrera;
            }
            if (empleado.instituto != null && empleado.instituto.Length > 0)
            {
                emp1.instituto = empleado.instituto;
            }
            if (empleado.titulo != null)
            {
                emp1.titulo = empleado.titulo;
            }
            //if (empleado.id_empleadoTipo != null && empleado.id_empleadoTipo.Length > 0)
            //{
            //    emp1.id_empleadoT = empleado.id_empleadoTipo;
            //}
            if (empleado.id_puesto != null && empleado.id_puesto > 0)
            {
                emp1.id_puesto = empleado.id_puesto;
            }
            if (empleado.jefeInmediato != null && empleado.jefeInmediato > 0)
            {
                emp1.jefeInmediato = empleado.jefeInmediato;
            }
            if (empleado.id_turno != null && empleado.id_turno > 0)
            {
                emp1.id_turno = empleado.id_turno;
            }
            if (empleado.salarioDiario != null && empleado.salarioDiario > 0)
            {
                emp1.salarioDiario = empleado.salarioDiario;
            }
            if (empleado.id_nomina != null && empleado.id_nomina > 0)
            {
                emp1.id_nomina = empleado.id_nomina;
            }
            if (empleado.fechaIngreso != null)
            {
                emp1.fechaIngreso = empleado.fechaIngreso;
            }
            if (empleado.id_nomina != null && empleado.id_nomina > 0)
            {
                emp1.id_nomina = empleado.id_nomina;
            }
            if (empleado.fechaIngreso != null )
            {
                emp1.fechaIngreso = empleado.fechaIngreso;
            }
                if (empleado.id_empresa != null && empleado.id_empresa > 0)
                {
                    emp1.id_empresa = empleado.id_empresa;
                }
                if (empleado.id_sucursal != null && empleado.id_sucursal > 0)
                {
                    emp1.id_sucursal = empleado.id_sucursal;
                }
                if (empleado.confianza != null )
                {
                    emp1.confianza = empleado.confianza;
                }
                //if (empleado.parentesco != null && empleado.parentesco.Length > 0)
                //{
                //    emp1.parentesco = empleado.parentesco;
                //}
                if (empleado.imagen != null && empleado.imagen.Length > 0)
                {
                    emp1.imagen = empleado.imagen;
                }
                if (empleado.bonoProd != null && empleado.bonoProd > 0)
                {
                    emp1.bonoProd = empleado.bonoProd;
                }
                if (empleado.firma != null && empleado.firma.Length > 0)
                {
                    emp1.firma = empleado.firma;
                }
                if (empleado.id_rol != null && empleado.id_rol > 0)
                {
                    emp1.id_rol = empleado.id_rol;
                }
                if (empleado.status != null)
                {
                    emp1.status = empleado.status;
                }
                if (empleado.externo != null)
                {
                    emp1.externo = empleado.externo;
                }
                if (empleado.id_area != null)
                {
                    emp1.id_area = empleado.id_area;
                }
                if(empleado.discapacidad != null)
            {
                    emp1.discapacidad = empleado.discapacidad;
                }

            #endregion

            //ModificarAtributosNoNulos(emp1, empleado);



            _context.empleados.Update(emp1);
            _context.SaveChanges();

            return Ok();
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
                //status = empleado.status,
                telefono = empleado.telefono,
                telefonoEmergencias = empleado.telefonoEmergencias,
                titulo = empleado.titulo,
                discapacidad = empleado.discapacidad

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
        [HttpGet("GetUltimoNoEmpleado/{id_empresa}/{id_sucursal}")]
        public async Task<ActionResult<Object>> GetUltimoNoEmpleado(int id_empresa, int id_sucursal)
        {
            try
            {
                int maximoValor = _context.empleados
            .Where(e => e.id_sucursal == id_sucursal && e.id_empresa == id_empresa)
            .Max(e => e.no_empleado);
                return Ok(new { no_empleado = maximoValor + 1 });
            }
            catch (Exception e)
            {
                return Ok(new {no_empleado=0});
            }
        }
        private bool empleadoExists(int id)
        {
            return _context.empleados.Any(e => e.id_empleado == id);
        }
        [HttpGet("GetEmpleadosPorJefeInmediato/{id_jefeInmediato}")]
        public async Task<ActionResult<IEnumerable<requestEmpleado>>> GetEmpleadosPorJefeInmediato(int id_jefeInmediato)
        {
            var empleadosLista = from x in _context.empleados.Where(x => x.jefeInmediato == id_jefeInmediato)
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
                                     id_empleadoTipo = 0,// x.id_empleadoTipo,
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
                                     id_area = x.id_area,

                                     firma = x.firma,
                                     id_rol = x.id_rol,
                                     status = x.status,
                                     externo = x.externo,
                                     discapacidad = x.discapacidad,
                                 };

            return await empleadosLista.ToListAsync();
        }

        
        
        
    }
}
