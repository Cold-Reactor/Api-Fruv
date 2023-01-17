using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.Bodega
{
    [Table("ordencompra")]
    [MySqlCharSet("utf8")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class ordencompra
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "int(11)")]
        public int? usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int? tipodepago { get; set; }
        public double? importe { get; set; }
        [Column(TypeName = "int(11)")]
        public int? solicitante { get; set; }
        [Column(TypeName = "int(11)")]
        public int? supervisor { get; set; }
        [Column(TypeName = "int(11)")]
        public int? autoriza { get; set; }
        [Column(TypeName = "text")]
        [MySqlCollation("utf8_general_ci")]
        public string comentarios { get; set; }
        [Column(TypeName = "int(11)")]
        public int? empresa { get; set; }
        [Column(TypeName = "int(11)")]
        public int? proveedor { get; set; }
        [Column(TypeName = "int(11)")]
        public int? unidad { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? procedencia { get; set; }
        public bool? cancelado { get; set; }
        public bool? tipocambio { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_departamento { get; set; }
        public bool? estado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cuenta { get; set; }
        [Column(TypeName = "int(11)")]
        public int? subcuenta { get; set; }
        public bool? cotizado { get; set; }
        public bool? autorizado { get; set; }
        [StringLength(45)]
        [MySqlCollation("utf8_general_ci")]
        public string nofactura { get; set; }
        [Column(TypeName = "text")]
        [MySqlCollation("utf8_general_ci")]
        public string motivo_noAut { get; set; }
        public bool? impreso { get; set; }
        [Column(TypeName = "int(15)")]
        public int? padre { get; set; }
        [Column(TypeName = "text")]
        public string comentarios_Autorizado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? userNOAutorizo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? encamino { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fechaencamino { get; set; }
        public bool? autorizadoSupervisor { get; set; }
    }
}
