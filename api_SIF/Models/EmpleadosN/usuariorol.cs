using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("usuariorol")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class usuariorol
    {
        public usuariorol()
        {
            //submodulos = new HashSet<submodulo>();
            //usuario_empleadorols = new HashSet<usuario_empleadorol>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_rol { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string descripcion { get; set; }

        //[InverseProperty("id_rolNavigation")]
        //public virtual ICollection<submodulo> submodulos { get; set; }
        //[InverseProperty("id_rolNavigation")]
        //public virtual ICollection<usuario_empleadorol> usuario_empleadorols { get; set; }
    }
}
