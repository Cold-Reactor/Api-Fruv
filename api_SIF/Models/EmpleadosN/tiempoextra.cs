using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("tiempoextra")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class tiempoextra
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_tiempoExtra { get; set; }
        public DateOnly? fechaSolicitud { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_supervisor { get; set; }
        [Column(TypeName = "int(11)")]
        public int? departamento { get; set; }
        [Column(TypeName = "int(11)")]
        public int? area { get; set; }
        [Column(TypeName = "text")]
        public string justificacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? realizo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_estado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? autorizoRH { get; set; }
    }
}
