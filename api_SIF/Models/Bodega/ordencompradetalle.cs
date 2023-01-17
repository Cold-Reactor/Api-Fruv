using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.Bodega
{
    [Table("ordencompradetalle")]
    [Index("id", Name = "id_UNIQUE", IsUnique = true)]
    [Index("idorden", Name = "idorden_idx")]
    [MySqlCharSet("utf8")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class ordencompradetalle
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "int(11)")]
        public int? idorden { get; set; }
        public double? cantidad { get; set; }
        [Column(TypeName = "int(11)")]
        public int? unidad { get; set; }
        [Column(TypeName = "text")]
        [MySqlCollation("utf8_general_ci")]
        public string descripcion { get; set; }
        [Column(TypeName = "int(11)")]
        public int? provedor1 { get; set; }
        [Column(TypeName = "int(11)")]
        public int? provedor2 { get; set; }
        [Column(TypeName = "int(11)")]
        public int? provedor3 { get; set; }
        public double? cotizacion1 { get; set; }
        public double? cotizacion2 { get; set; }
        public double? cotizacion3 { get; set; }
        [Column(TypeName = "int(11)")]
        public int? proveedor { get; set; }
        [Column(TypeName = "int(11)")]
        public int? vehiculo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? marca { get; set; }
        [StringLength(120)]
        [MySqlCollation("utf8_general_ci")]
        public string modelo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? recibido { get; set; }
        public double? cantidadrecibida { get; set; }
        [Column(TypeName = "int(11)")]
        public int? noparte { get; set; }
    }
}
