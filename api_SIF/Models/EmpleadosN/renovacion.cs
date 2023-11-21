using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("renovacion")]
    [Index("id_empleado", Name = "fk_renovacion_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class renovacion
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_renovacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_empleado { get; set; }
        public DateOnly? fecha { get; set; }

        //[ForeignKey("id_empleado")]
        //[InverseProperty("renovacions")]
        //public virtual empleado id_empleadoNavigation { get; set; }
    }
}
