using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_empleado", Name = "fk_faltas_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class falta
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_falta { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        public DateOnly fecha { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("falta")]
        public virtual empleado id_empleadoNavigation { get; set; }
    }
}
