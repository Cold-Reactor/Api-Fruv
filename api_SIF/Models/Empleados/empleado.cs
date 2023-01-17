using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.Empleados
{
    [MySqlCharSet("latin1")]
    [MySqlCollation("latin1_swedish_ci")]
    public partial class empleado
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Key]
        [Column(TypeName = "int(50)")]
        public int noEmpleado { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Nombres { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Apellido_paterno { get; set; }
        [Required]
        [Column("Apellido materno", TypeName = "tinytext")]
        public string Apellido_materno { get; set; }
        [Required]
        [Column("Tipo _de_empleado", TypeName = "tinytext")]
        public string Tipo__de_empleado { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Departamento { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Puesto { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Turno { get; set; }
        [Column("Jefe Inmediato", TypeName = "tinytext")]
        public string Jefe_Inmediato { get; set; }
        [Required]
        [Column("No IMSS", TypeName = "tinytext")]
        public string No_IMSS { get; set; }
        [Column("Alta IMSS")]
        public DateOnly Alta_IMSS { get; set; }
        [Column(TypeName = "tinytext")]
        public string RFC { get; set; }
        [Column(TypeName = "tinytext")]
        public string CURP { get; set; }
        public DateOnly Fecha_de_Ingreso { get; set; }
        [Column(TypeName = "tinytext")]
        public string Sexo { get; set; }
        [Column(TypeName = "tinytext")]
        public string Edo_civil { get; set; }
        [Column(TypeName = "tinytext")]
        public string sangre { get; set; }
        [Column(TypeName = "tinytext")]
        public string Calle_y_Numero { get; set; }
        [Column(TypeName = "tinytext")]
        public string Colonia { get; set; }
        [Column(TypeName = "int(11)")]
        public int? CP { get; set; }
        [Column(TypeName = "tinytext")]
        public string Ciudad { get; set; }
        [Column(TypeName = "tinytext")]
        public string Estado { get; set; }
        [Column(TypeName = "tinytext")]
        public string Telefono { get; set; }
        [Column(TypeName = "tinytext")]
        public string Telefono_emergencias { get; set; }
        public double? SD_salario { get; set; }
        [Column(TypeName = "tinytext")]
        public string Nomina { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string Empresa { get; set; }
        public DateOnly Fecha_Nacimiento { get; set; }
        [Column(TypeName = "int(11)")]
        public int Status { get; set; }
        [Column(TypeName = "int(11)")]
        public int? noHuella { get; set; }
        [StringLength(300)]
        public string imagen { get; set; }
        [Column(TypeName = "tinytext")]
        public string Clave_electoral { get; set; }
        [Column(TypeName = "tinytext")]
        public string email { get; set; }
        [Column(TypeName = "tinytext")]
        public string grado_de_estudios { get; set; }
        [Column(TypeName = "tinytext")]
        public string Carrera { get; set; }
        [Column(TypeName = "tinytext")]
        public string Instituto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Titulo { get; set; }
        [Column(TypeName = "tinytext")]
        public string NoCedula { get; set; }
        [Column(TypeName = "text")]
        public string firma { get; set; }
        [StringLength(100)]
        public string nombreContacto { get; set; }
        [StringLength(45)]
        public string parentesco { get; set; }
        [Column(TypeName = "tinytext")]
        public string tipoempleado { get; set; }
        public bool? presencial { get; set; }
        public bool? renovacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? turnoId { get; set; }
        [Column(TypeName = "int(11)")]
        public int? supervisor { get; set; }
        public bool? RegistraPermiso { get; set; }
        public DateOnly? fecha_baja { get; set; }
        public bool? user { get; set; }
        [StringLength(45)]
        public string password { get; set; }
        [Column(TypeName = "int(11)")]
        public int? areaid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [Column(TypeName = "int(1)")]
        public int? tipoBaja { get; set; }
        [StringLength(45)]
        public string motivoBaja { get; set; }
        public DateOnly? fechaUltimaNomina { get; set; }
    }
}
