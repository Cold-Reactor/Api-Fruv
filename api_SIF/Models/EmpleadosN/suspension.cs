using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("suspension")]
    [Index("id_empleado", Name = "fk_suspension_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class suspension
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_suspension { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        public DateOnly? fechaInicio { get; set; }
        public DateOnly? fechaRegreso { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? dias { get; set; }
        [Column(TypeName = "text")]
        public string motivo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? realizo { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? status { get; set; }
        [Column(TypeName = "text")]
        public string firmaAmonestado { get; set; }
        [Column(TypeName = "text")]
        public string firmaSupervisor { get; set; }
        [Column(TypeName = "text")]
        public string firmaRH { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("suspensions")]
        public virtual empleado id_empleadoNavigation { get; set; }
    }
}
