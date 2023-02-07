using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("sucursal")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class sucursal
    {
        public sucursal()
        {
            id_empresas = new HashSet<empresa>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }

        [ForeignKey("id_sucursal")]
        [InverseProperty("id_sucursals")]
        public virtual ICollection<empresa> id_empresas { get; set; }
    }
}
