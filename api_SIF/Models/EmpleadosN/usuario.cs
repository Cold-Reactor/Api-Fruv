using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("usuario")]
    [Index("id_empleado", Name = "fk_usuario_empleado1_idx")]
    public partial class usuario
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_usuario { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string user { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string password { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? compras { get; set; }
        public bool? god { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("usuarios")]
        public virtual empleado id_empleadoNavigation { get; set; }
        [InverseProperty("id_usuarioNavigation")]
        public virtual usuario_empleadorol usuario_empleadorol { get; set; }
    }
}
