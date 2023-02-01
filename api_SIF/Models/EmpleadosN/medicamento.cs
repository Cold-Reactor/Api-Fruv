using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("medicamento")]
    [Index("id_medicamentoT", Name = "fk_medicamentos_medicamentoTipo1_idx")]
    public partial class medicamento
    {
        public medicamento()
        {
            id_consulta = new HashSet<consultum>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_medicamento { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_medicamentoT { get; set; }
        [Required]
        [Column("medicamento")]
        [StringLength(45)]
        public string medicamento1 { get; set; }
        [Precision(10, 0)]
        public decimal cantidad { get; set; }

        [ForeignKey("id_medicamentoT")]
        [InverseProperty("medicamentos")]
        public virtual medicamentotipo id_medicamentoTNavigation { get; set; }

        [ForeignKey("id_medicamento")]
        [InverseProperty("id_medicamentos")]
        public virtual ICollection<consultum> id_consulta { get; set; }
    }
}
