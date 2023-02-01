using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("iva")]
    public partial class iva
    {
        public iva()
        {
            cotizacions = new HashSet<cotizacion>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_iva { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cantidad { get; set; }

        [InverseProperty("id_ivaNavigation")]
        public virtual ICollection<cotizacion> cotizacions { get; set; }
    }
}
