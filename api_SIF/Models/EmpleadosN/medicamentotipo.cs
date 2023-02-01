using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("medicamentotipo")]
    public partial class medicamentotipo
    {
        public medicamentotipo()
        {
            medicamentos = new HashSet<medicamento>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_medicamentoT { get; set; }
        [Required]
        [StringLength(45)]
        public string tipo { get; set; }

        [InverseProperty("id_medicamentoTNavigation")]
        public virtual ICollection<medicamento> medicamentos { get; set; }
    }
}
