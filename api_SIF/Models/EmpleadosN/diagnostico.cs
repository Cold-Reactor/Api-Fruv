using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("diagnostico")]
    public partial class diagnostico
    {
        public diagnostico()
        {
            id_accidentes = new HashSet<accidente>();
            id_consulta = new HashSet<consultum>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_diagnostico { get; set; }
        [Required]
        [Column("diagnostico")]
        [StringLength(45)]
        public string diagnostico1 { get; set; }

        [ForeignKey("id_diagnostico")]
        [InverseProperty("id_diagnosticos")]
        public virtual ICollection<accidente> id_accidentes { get; set; }
        [ForeignKey("id_diagnostico")]
        [InverseProperty("id_diagnosticos")]
        public virtual ICollection<consultum> id_consulta { get; set; }
    }
}
