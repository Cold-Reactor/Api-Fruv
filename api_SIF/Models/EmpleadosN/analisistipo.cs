using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("analisistipo")]
    public partial class analisistipo
    {
        public analisistipo()
        {
            historialanalisismedicos = new HashSet<historialanalisismedico>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_analisisT { get; set; }
        [Required]
        [StringLength(45)]
        public string analisis { get; set; }

        [InverseProperty("id_analisisTNavigation")]
        public virtual ICollection<historialanalisismedico> historialanalisismedicos { get; set; }
    }
}
