using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("turno")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class turno
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_turno { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string name { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly entrada { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly salida { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly entradaF { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly salidaF { get; set; }
        [Required]
        [StringLength(20)]
        public string descanso { get; set; }
    }
}
