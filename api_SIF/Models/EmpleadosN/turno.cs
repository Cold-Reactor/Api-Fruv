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
        [Column("turno", TypeName = "tinytext")]
        public string turno1 { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly entrada { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly salida { get; set; }
        [Column(TypeName = "int(1)")]
        public int horas { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly entradaF { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly salidaF { get; set; }
        [Column(TypeName = "int(1)")]
        public int horasF { get; set; }
        [Required]
        [StringLength(45)]
        public string descanso { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly comida { get; set; }
        public double horas_trabajadas { get; set; }
        [Column(TypeName = "int(1)")]
        public int nocturno { get; set; }
    }
}
