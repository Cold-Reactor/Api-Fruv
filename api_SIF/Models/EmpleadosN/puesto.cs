using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class puesto
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_puesto { get; set; }
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }
    }
}
