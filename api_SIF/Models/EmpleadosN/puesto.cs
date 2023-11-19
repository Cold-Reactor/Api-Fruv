using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("puesto")]
    [Index("id_empleadoT", Name = "fk_puesto_empleadoT_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class puesto
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_puesto { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleadoT { get; set; }

        //[ForeignKey("id_empleadoT")]
        //[InverseProperty("puestos")]
        //public virtual empleadotipo id_empleadoTNavigation { get; set; }
    }
}
