using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleado_tiempoextra")]
    [Index("id_empleado", Name = "fk_empleado_has_tiempoExtra_empleado1_idx")]
    [Index("id_tiempoExtra", Name = "fk_empleado_has_tiempoExtra_tiempoExtra1_idx")]
    public partial class empleado_tiempoextra
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_tiempoExtra { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fechaInicio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fechaSalida { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? horas { get; set; }
        public double? tiempoTrabajado { get; set; }
        public double? pago { get; set; }
        [Column(TypeName = "text")]
        public string actividad { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? status { get; set; }
    }
}
