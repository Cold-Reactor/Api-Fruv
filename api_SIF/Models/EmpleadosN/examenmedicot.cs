using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("examenmedicot")]
    public partial class examenmedicot
    {
        public examenmedicot()
        {
            examenmedicos = new HashSet<examenmedico>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_examenMedicoT { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string examen { get; set; }
        [Column(TypeName = "int(1)")]
        public int utilizable { get; set; }

        [InverseProperty("id_examenMedicoTNavigation")]
        public virtual ICollection<examenmedico> examenmedicos { get; set; }
    }
}
