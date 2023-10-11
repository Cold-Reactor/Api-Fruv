using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empresa")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class empresa
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empresa { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }
    }
}
