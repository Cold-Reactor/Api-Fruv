using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("tipobaja")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class tipobaja
    {
        public tipobaja()
        {
            empleadohistorials = new HashSet<empleadohistorial>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_tipoBaja { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? tipo { get; set; }

        [InverseProperty("id_tipoBajaNavigation")]
        public virtual ICollection<empleadohistorial> empleadohistorials { get; set; }
    }
}
