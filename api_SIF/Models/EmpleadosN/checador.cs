using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("checador")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class checador
    {
        public checador()
        {
            checada = new HashSet<checada>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_checador { get; set; }
        [StringLength(45)]
        public string nombre { get; set; }
        [StringLength(45)]
        public string serialNumber { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }

        [InverseProperty("id_checadorNavigation")]
        public virtual ICollection<checada> checada { get; set; }
    }
}
