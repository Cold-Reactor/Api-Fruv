using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("tiempoextraestado")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class TiempoExtraEstado
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_estado { get; set; }
        [StringLength(45)]
        public string estado { get; set; }
        [StringLength(10)]
        public string color { get; set; }
    }
}
