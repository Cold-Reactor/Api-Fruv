using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("permisomodalidad")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class permisomodalidad
    {
        public permisomodalidad()
        {
            //permisos = new HashSet<permiso>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_modalidad { get; set; }
        [StringLength(45)]
        public string nombre { get; set; }

        //[InverseProperty("id_modalidadNavigation")]
        //public virtual ICollection<permiso> permisos { get; set; }
    }
}
