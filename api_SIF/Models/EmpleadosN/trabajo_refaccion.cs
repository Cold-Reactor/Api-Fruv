using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("trabajo_refaccion")]
    [Index("id_refaccion", Name = "fk_refaccion_has_trabajoInterno_refaccion1_idx")]
    [Index("id_trabajoI", Name = "fk_refaccion_has_trabajoInterno_trabajoInterno1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class trabajo_refaccion
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_trabajoRefaccion { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_trabajoI { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_refaccion { get; set; }
        [Column(TypeName = "int(11)")]
        public int cantidad { get; set; }

        //[ForeignKey("id_refaccion")]
        //[InverseProperty("trabajo_refaccions")]
        //public virtual refaccion id_refaccionNavigation { get; set; }
        //[ForeignKey("id_trabajoI")]
        //[InverseProperty("trabajo_refaccions")]
        //public virtual trabajointerno id_trabajoINavigation { get; set; }
    }
}
