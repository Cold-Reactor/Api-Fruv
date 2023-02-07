using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_empleado", Name = "fk_parientes_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class pariente
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_pariente { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleadoP { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string parentesco { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("parientes")]
        public virtual empleado id_empleadoNavigation { get; set; }
    }
}
