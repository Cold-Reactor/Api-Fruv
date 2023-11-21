using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("formato")]
    [Index("id_departamento", Name = "fk_formato_departamento1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class formato
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_formato { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_departamento { get; set; }
        [Required]
        [StringLength(45)]
        public string noFormato { get; set; }
        public DateOnly fechaI { get; set; }

        //[ForeignKey("id_departamento")]
        //[InverseProperty("formatos")]
        //public virtual departamento id_departamentoNavigation { get; set; }
    }
}
