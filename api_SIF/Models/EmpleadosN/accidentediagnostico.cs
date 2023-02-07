using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("accidentediagnostico")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class accidentediagnostico
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_accidente { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_diagnostico { get; set; }
    }
}
