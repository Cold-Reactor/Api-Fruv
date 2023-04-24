using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.MateriaPrima
{
    [Table("foliomp")]
    [Index("identradadetalle", Name = "identradadetalle")]
    [MySqlCharSet("utf8")]
    [MySqlCollation("utf8_spanish_ci")]
    public partial class foliomp
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [StringLength(11)]
        [MySqlCollation("utf8_general_ci")]
        public string folio { get; set; }
        public bool? disponible { get; set; }
        [Column(TypeName = "int(11)")]
        public int? identradadetalle { get; set; }
    }
}
