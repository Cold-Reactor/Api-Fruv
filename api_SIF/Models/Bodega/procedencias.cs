using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.Bodega
{
    [MySqlCharSet("latin1")]
    [MySqlCollation("latin1_swedish_ci")]
    public partial class procedencias
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Nombre { get; set; }
        [StringLength(45)]
        public string numero { get; set; }
        [StringLength(45)]
        public string calle { get; set; }
        [StringLength(45)]
        public string ciudad { get; set; }
        [Column(TypeName = "int(11)")]
        public int? estado { get; set; }
        [StringLength(45)]
        public string zip { get; set; }
        [StringLength(45)]
        public string nombreCorto { get; set; }
        [StringLength(3)]
        public string inicial { get; set; }
        [StringLength(10)]
        public string color { get; set; }
        [Column(TypeName = "smallint(6)")]
        public short? compania { get; set; }
        public bool? externo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? tipo { get; set; }
        [StringLength(30)]
        public string impresora { get; set; }
        [Column(TypeName = "int(11)")]
        public int? capacidad { get; set; }
        [Column(TypeName = "int(11)")]
        public int? padre { get; set; }
        public bool? coa { get; set; }
        [StringLength(45)]
        public string ip { get; set; }
        [StringLength(45)]
        public string colonia { get; set; }
        [Column(TypeName = "int(11)")]
        public int? produce { get; set; }
        [Column(TypeName = "int(11)")]
        public int? status { get; set; }
        [Column(TypeName = "int(11)")]
        public int? materiaprima { get; set; }
        [Column(TypeName = "int(1)")]
        public int? controlGafetesMP { get; set; }
    }
}
