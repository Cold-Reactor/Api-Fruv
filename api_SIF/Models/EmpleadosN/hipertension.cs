using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("hipertension")]
    [Index("id_trabajoE", Name = "fk_hiperTension_trabajoExterno1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class hipertension
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_hiperT { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_trabajoE { get; set; }
        [Required]
        [StringLength(45)]
        public string nombre { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string hta { get; set; }

        //[ForeignKey("id_trabajoE")]
        //[InverseProperty("hipertensions")]
        //public virtual trabajoexterno id_trabajoENavigation { get; set; }
    }
}
