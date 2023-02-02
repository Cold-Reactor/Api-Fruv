using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleado")]
    [Index("id_area", Name = "fk_empleado_area1_idx")]
    [Index("id_ciudad", Name = "fk_empleados_ciudad1_idx")]
    [Index("id_rol", Name = "fk_empleados_empleadoRol1_idx")]
    [Index("id_empleadoTipo", Name = "fk_empleados_empleadoTipo1_idx")]
    [Index("id_empresa", Name = "fk_empleados_empresa1_idx")]
    [Index("id_estado", Name = "fk_empleados_estado1_idx")]
    [Index("id_turno", Name = "fk_empleados_jornada1_idx")]
    [Index("id_nomina", Name = "fk_empleados_nomina1_idx")]
    [Index("id_puesto", Name = "fk_empleados_puestos1_idx")]
    [Index("id_sucursal", Name = "fk_empleados_sucursal1_idx")]
    public partial class empleado
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(50)")]
        public int no_empleado { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string apellidoPaterno { get; set; }
        [Column(TypeName = "tinytext")]
        public string apellidoMaterno { get; set; }
        [Column(TypeName = "tinytext")]
        public string estadoCivil { get; set; }
        [Column(TypeName = "tinytext")]
        public string sexo { get; set; }
        public DateOnly? fechaNacimiento { get; set; }
        [Column(TypeName = "tinytext")]
        public string IMSS { get; set; }
        [Column(TypeName = "tinytext")]
        public string telefono { get; set; }
        [Column(TypeName = "tinytext")]
        public string telefonoEmergencias { get; set; }
        [Column(TypeName = "tinytext")]
        public string email { get; set; }
        [Column(TypeName = "tinytext")]
        public string CURP { get; set; }
        [Column(TypeName = "tinytext")]
        public string RFC { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_ciudad { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_estado { get; set; }
        [Column(TypeName = "tinytext")]
        public string direccion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? CP { get; set; }
        [Column(TypeName = "tinytext")]
        public string gradoEstudios { get; set; }
        [Column(TypeName = "tinytext")]
        public string carrera { get; set; }
        [Column(TypeName = "tinytext")]
        public string instituto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? titulo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_empleadoTipo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_puesto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? jefeInmediato { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_turno { get; set; }
        public double? salarioDiario { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_nomina { get; set; }
        public DateOnly? fechaIngreso { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_empresa { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_sucursal { get; set; }
        [Column(TypeName = "int(1)")]
        public int? presencial { get; set; }
        [StringLength(45)]
        public string parentesco { get; set; }
        [StringLength(300)]
        public string imagen { get; set; }
        [Column(TypeName = "text")]
        public string firma { get; set; }
        [Column(TypeName = "int(1)")]
        public int? id_rol { get; set; }
        [Column(TypeName = "int(1)")]
        public int? status { get; set; }
        [Column(TypeName = "int(1)")]
        public int? externo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_area { get; set; }
    }
}
