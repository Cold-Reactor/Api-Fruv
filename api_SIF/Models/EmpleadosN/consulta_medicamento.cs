using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("consulta_medicamento")]
    [Index("id_consulta", Name = "fk_consulta_has_medicamentos_consulta1_idx")]
    [Index("id_medicamento", Name = "fk_consulta_has_medicamentos_medicamentos1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class consulta_medicamento
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_consulta { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_medicamento { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? cantidad { get; set; }

        [ForeignKey("id_consulta")]
        [InverseProperty("consulta_medicamentos")]
        public virtual consultum id_consultaNavigation { get; set; }
        [ForeignKey("id_medicamento")]
        [InverseProperty("consulta_medicamentos")]
        public virtual medicamento id_medicamentoNavigation { get; set; }
    }
}
