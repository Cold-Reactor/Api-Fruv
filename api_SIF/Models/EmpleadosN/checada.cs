using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_checador", Name = "fk_checadas_checador1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class checada
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_checada { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_checador { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fechaHora { get; set; }
        public DateOnly fecha { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly hora { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte nomina { get; set; }

        [ForeignKey("id_checador")]
        [InverseProperty("checada")]
        public virtual checador id_checadorNavigation { get; set; }
    }
}
