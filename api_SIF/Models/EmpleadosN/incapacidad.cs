using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("incapacidad")]
    [Index("id_empleado", Name = "fk_incapacidad_empleado1_idx")]
    public partial class incapacidad
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_incapacidad { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [StringLength(45)]
        public string incapacidadT { get; set; }
        public DateOnly? fechaInicio { get; set; }
        public DateOnly? fechaRegreso { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? dias { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? temporal { get; set; }
        [StringLength(45)]
        public string comentario { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("incapacidads")]
        public virtual empleado id_empleadoNavigation { get; set; }
    }
}
