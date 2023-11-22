using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class Sucursale
    {
        public Sucursale()
        {
            //turnos = new HashSet<turno>();
            //usuario_empleadorols = new HashSet<usuario_empleadorol>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string sucursal { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nomenclatura { get; set; }

        //[InverseProperty("id_sucursalNavigation")]
        //public virtual ICollection<turno> turnos { get; set; }
        //[InverseProperty("id_sucursalNavigation")]
        //public virtual ICollection<usuario_empleadorol> usuario_empleadorols { get; set; }
    }
}
