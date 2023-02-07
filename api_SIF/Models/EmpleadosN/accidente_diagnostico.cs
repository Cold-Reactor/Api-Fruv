using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("accidente_diagnostico")]
    [Index("id_diagnostico", Name = "fk_incapacidad_has_diagnostico_diagnostico1_idx")]
    [Index("id_accidente", Name = "fk_incapacidad_has_diagnostico_incapacidad1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class accidente_diagnostico
    {
        [Column(TypeName = "int(11)")]
        public int id_accidente { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_diagnostico { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }

        [ForeignKey("id_accidente")]
        [InverseProperty("accidente_diagnosticos")]
        public virtual accidente id_accidenteNavigation { get; set; }
        [ForeignKey("id_diagnostico")]
        [InverseProperty("accidente_diagnosticos")]
        public virtual diagnostico id_diagnosticoNavigation { get; set; }
    }
}
