using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace api_SIF.Models.EmpleadosN
{
    public class empleadoRequest
    {

      
        
            public int id_empleado { get; set; }
            public int no_empleado { get; set; }
            public string nombre { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string estadoCivil { get; set; }
            public string sexo { get; set; }
            public DateOnly? fechaNacimiento { get; set; }
            public string IMSS { get; set; }
            public string telefono { get; set; }
            public string telefonoEmergencias { get; set; }
            public string email { get; set; }
            public string CURP { get; set; }
            public string RFC { get; set; }
            public int? id_ciudad { get; set; }
            public int? id_estado { get; set; }
            public string direccion { get; set; }
            public int? CP { get; set; }
            public string gradoEstudios { get; set; }
            public string carrera { get; set; }
            public string instituto { get; set; }
            public int? titulo { get; set; }
            public int? id_empleadoTipo { get; set; }
            public int? id_puesto { get; set; }
            public int? jefeInmediato { get; set; }
            public int? id_turno { get; set; }
            public double? salarioDiario { get; set; }
            public int? id_nomina { get; set; }
            public DateOnly? fechaIngreso { get; set; }
            public int? id_empresa { get; set; }
            public int? id_sucursal { get; set; }
            public int? presencial { get; set; }
            public string parentesco { get; set; }
            public string imagen { get; set; }
            public string firma { get; set; }
            public int? id_rol { get; set; }
            public int? status { get; set; }
            public int? externo { get; set; }
            public int id_area { get; set; }

            

}
}
