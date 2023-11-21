using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_rol", Name = "fk_subModulos_empleadoRol1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class submodulo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_subM { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_rol { get; set; }
        [StringLength(45)]
        public string nombre { get; set; }

        //[ForeignKey("id_rol")]
        //[InverseProperty("submodulos")]
        //public virtual usuariorol id_rolNavigation { get; set; }
    }
}
