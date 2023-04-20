using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("medicamento")]
    [Index("id_medicamentoT", Name = "fk_medicamentos_medicamentoTipo1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class medicamento
    {
        public medicamento()
        {
            consulta_medicamentos = new HashSet<consulta_medicamento>();
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
        [InverseProperty("id_medicamentoNavigation")]
        public virtual ICollection<consulta_medicamento> consulta_medicamentos { get; set; }
    }
}
