using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("departamento")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class departamento
    {
        public departamento()
        {
            //areas = new HashSet<area>();
            //formatos = new HashSet<formato>();
            //partida = new HashSet<partidum>();
            //trabajoexternos = new HashSet<trabajoexterno>();
            //trabajointernos = new HashSet<trabajointerno>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_departamento { get; set; }
        [Required]
        [Column("departamento", TypeName = "tinytext")]
        public string departamento1 { get; set; }

        //[InverseProperty("id_departamentoNavigation")]
        //public virtual ICollection<area> areas { get; set; }
        //[InverseProperty("id_departamentoNavigation")]
        //public virtual ICollection<formato> formatos { get; set; }
        //[InverseProperty("id_departamentoNavigation")]
        //public virtual ICollection<partidum> partida { get; set; }
        //[InverseProperty("id_departamentoNavigation")]
        //public virtual ICollection<trabajoexterno> trabajoexternos { get; set; }
        //[InverseProperty("id_departamentoNavigation")]
        //public virtual ICollection<trabajointerno> trabajointernos { get; set; }
    }
}
