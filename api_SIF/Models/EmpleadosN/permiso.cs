using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("permiso")]
    [Index("id_empleado", Name = "fk_permiso_empleados1_idx")]
    [Index("id_modalidad", Name = "fk_permiso_permisoModalidad1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class permiso
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_permiso { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_empleado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fechaCreacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? supervisor { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_modalidad { get; set; }
        public DateOnly? fechaSalida { get; set; }
        public DateOnly? fechaEntrada { get; set; }
        [Column(TypeName = "int(11)")]
        public int? dias { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly? horaSalida { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly? horaEntrada { get; set; }
        public double? horas { get; set; }
        [Column(TypeName = "text")]
        public string motivo { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? pagado { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? status { get; set; }
        [Column(TypeName = "int(11)")]
        public int? autorizo { get; set; }

        //[ForeignKey("id_empleado")]
        //[InverseProperty("permisos")]
        //public virtual empleado id_empleadoNavigation { get; set; }
        //[ForeignKey("id_modalidad")]
        //[InverseProperty("permisos")]
        //public virtual permisomodalidad id_modalidadNavigation { get; set; }
    }
}
