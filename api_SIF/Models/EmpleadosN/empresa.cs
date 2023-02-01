using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empresa")]
    public partial class empresa
    {
        public empresa()
        {
            id_sucursals = new HashSet<sucursal>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empresa { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }

        [ForeignKey("id_empresa")]
        [InverseProperty("id_empresas")]
        public virtual ICollection<sucursal> id_sucursals { get; set; }
    }
}
