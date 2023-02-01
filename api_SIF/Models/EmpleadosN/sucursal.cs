using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("sucursal")]
    public partial class sucursal
    {
        public sucursal()
        {
            checadors = new HashSet<checador>();
            id_empresas = new HashSet<empresa>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }

        [InverseProperty("id_sucursalNavigation")]
        public virtual ICollection<checador> checadors { get; set; }

        [ForeignKey("id_sucursal")]
        [InverseProperty("id_sucursals")]
        public virtual ICollection<empresa> id_empresas { get; set; }
    }
}
