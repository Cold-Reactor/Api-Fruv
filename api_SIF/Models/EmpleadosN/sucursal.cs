using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("sucursal")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class Sucursal
    {
        public Sucursal()
        {
            //usuario_empleadorols = new HashSet<usuario_empleadorol>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        [Column("sucursal")]
        [StringLength(45)]
        public string sucursal { get; set; }
        [Column(TypeName = "tinytext")]
        public string nomenclatura { get; set; }

        //[InverseProperty("id_sucursalesNavigation")]
        //public virtual ICollection<usuario_empleadorol> usuario_empleadorols { get; set; }
    }
}
