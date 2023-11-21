using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("crud")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class crud
    {
        public crud()
        {
            //usuario_empleadorols = new HashSet<usuario_empleadorol>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_crud { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string permiso { get; set; }

        //[InverseProperty("id_crudNavigation")]
        //public virtual ICollection<usuario_empleadorol> usuario_empleadorols { get; set; }
    }
}
