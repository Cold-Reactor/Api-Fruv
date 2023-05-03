using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class sucursale
    {
        public sucursale()
        {
            turnos = new HashSet<turno>();
            usuario_empleadorols = new HashSet<usuario_empleadorol>();
            id_empresas = new HashSet<empresa>();
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

        [InverseProperty("id_sucursalNavigation")]
        public virtual ICollection<turno> turnos { get; set; }
        [InverseProperty("id_sucursalNavigation")]
        public virtual ICollection<usuario_empleadorol> usuario_empleadorols { get; set; }

        [ForeignKey("id_sucursal")]
        [InverseProperty("id_sucursals")]
        public virtual ICollection<empresa> id_empresas { get; set; }
    }
}
