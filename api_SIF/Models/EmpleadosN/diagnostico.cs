using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("diagnostico")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class diagnostico
    {
        public diagnostico()
        {
            accidente_diagnosticos = new HashSet<accidente_diagnostico>();
            id_consulta = new HashSet<consultum>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_diagnostico { get; set; }
        [Required]
        [Column("diagnostico")]
        [StringLength(45)]
        public string diagnostico1 { get; set; }

        [InverseProperty("id_diagnosticoNavigation")]
        public virtual ICollection<accidente_diagnostico> accidente_diagnosticos { get; set; }

        [ForeignKey("id_diagnostico")]
        [InverseProperty("id_diagnosticos")]
        public virtual ICollection<consultum> id_consulta { get; set; }
    }
}
