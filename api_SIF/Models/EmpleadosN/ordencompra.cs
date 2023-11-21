using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("ordencompra")]
    [Index("id_cotizacion", Name = "fk_ordenCompra_cotizacion1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class ordencompra
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_ordenC { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_cotizacion { get; set; }
        [Column(TypeName = "tinytext")]
        public string tipo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cantidad { get; set; }
        [StringLength(45)]
        public string descripcion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? provedor { get; set; }
        public double? precioU { get; set; }
        public double? iva { get; set; }
        public double? precioT { get; set; }

        //[ForeignKey("id_cotizacion")]
        //[InverseProperty("ordencompras")]
        //public virtual cotizacion id_cotizacionNavigation { get; set; }
    }
}
