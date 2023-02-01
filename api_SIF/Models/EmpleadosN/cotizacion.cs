using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("cotizacion")]
    [Index("id_iva", Name = "fk_cotizacion_iva1_idx")]
    [Index("id_proveedor", Name = "fk_cotizacion_proveedor1_idx")]
    [Index("id_solicitudC", Name = "fk_cotizacion_solicitudCompra1_idx")]
    public partial class cotizacion
    {
        public cotizacion()
        {
            ordencompras = new HashSet<ordencompra>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_cotizacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_solicitudC { get; set; }
        [Column(TypeName = "tinytext")]
        public string tipo { get; set; }
        public DateOnly? fechaAlta { get; set; }
        [Column(TypeName = "tinytext")]
        public string presentacion { get; set; }
        [Column(TypeName = "tinytext")]
        public string unidad { get; set; }
        [Column(TypeName = "tinytext")]
        public string producto { get; set; }
        public double? cantidad { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_proveedor { get; set; }
        public DateOnly? fechaEntrega { get; set; }
        [Column(TypeName = "tinytext")]
        public string pagoT { get; set; }
        [Column(TypeName = "tinytext")]
        public string monedaT { get; set; }
        public double? precioU { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_iva { get; set; }
        public double? precioTot { get; set; }

        [ForeignKey("id_iva")]
        [InverseProperty("cotizacions")]
        public virtual iva id_ivaNavigation { get; set; }
        [ForeignKey("id_proveedor")]
        [InverseProperty("cotizacions")]
        public virtual proveedor id_proveedorNavigation { get; set; }
        [ForeignKey("id_solicitudC")]
        [InverseProperty("cotizacions")]
        public virtual solicitudcompra id_solicitudCNavigation { get; set; }
        [InverseProperty("id_cotizacionNavigation")]
        public virtual ICollection<ordencompra> ordencompras { get; set; }
    }
}
