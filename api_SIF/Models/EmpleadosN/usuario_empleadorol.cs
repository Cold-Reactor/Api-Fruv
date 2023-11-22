using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("usuario_empleadorol")]
    [Index("id_crud", Name = "fk_usuario_has_empleadoRol_crud1_idx")]
    [Index("id_rol", Name = "fk_usuario_has_empleadoRol_empleadoRol1_idx")]
    [Index("id_sucursal", Name = "fk_usuario_has_empleadoRol_sucursal1_idx")]
    [Index("id_usuario", Name = "fk_usuario_has_empleadoRol_usuario1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class usuario_empleadorol
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_usuario { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_rol { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_subM { get; set; }
        [Column(TypeName = "int(11)")]
        [Required(ErrorMessage = "El campo MiEntero es obligatorio")]

        public int? id_crud { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        [Column(TypeName = "int(1)")]
        public int? master { get; set; }

        //[ForeignKey("id_crud")]
        //[InverseProperty("usuario_empleadorols")]
        //public virtual crud id_crudNavigation { get; set; }
        //[ForeignKey("id_rol")]
        //[InverseProperty("usuario_empleadorols")]
        //public virtual usuariorol id_rolNavigation { get; set; }
        //[ForeignKey("id_sucursal")]
        //[InverseProperty("usuario_empleadorols")]
        //public virtual sucursale id_sucursalNavigation { get; set; }
        //[ForeignKey("id_usuario")]
        //[InverseProperty("usuario_empleadorol")]
        //public virtual usuario id_usuarioNavigation { get; set; }
    }
}
