using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("turno")]
    [Index("id_sucursal", Name = "fk_sucursal_idx")]
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
        [StringLength(45)]
        public string descanso { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly comida { get; set; }
        public double horas_trabajadas { get; set; }
        [Column(TypeName = "int(1)")]
        public int id_sucursal { get; set; }
        [Column(TypeName = "int(1)")]
        public int nocturno { get; set; }
        [Column(TypeName = "int(1)")]
        public int disponible { get; set; }

        [ForeignKey("id_sucursal")]
        [InverseProperty("turnos")]
        public virtual sucursale id_sucursalNavigation { get; set; }
    }
}
