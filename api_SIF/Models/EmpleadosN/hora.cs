using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("hora")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class hora
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_hora { get; set; }
        [Column("hora", TypeName = "time")]
        public TimeOnly hora1 { get; set; }
    }
}
