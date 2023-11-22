using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("estado")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class Estado
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_estado { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string estado { get; set; }
    }
}
