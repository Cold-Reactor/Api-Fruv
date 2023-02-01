using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("refaccion")]
    public partial class refaccion
    {
        public refaccion()
        {
            trabajo_refaccions = new HashSet<trabajo_refaccion>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_refaccion { get; set; }
        [Column("refaccion")]
        [StringLength(45)]
        public string refaccion1 { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cantidad { get; set; }

        [InverseProperty("id_refaccionNavigation")]
        public virtual ICollection<trabajo_refaccion> trabajo_refaccions { get; set; }
    }
}
