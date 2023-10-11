using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("cincostipo")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class cincostipo
    {
        public cincostipo()
        {
            cincosbitacora_cincostipos = new HashSet<cincosbitacora_cincostipo>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_cincoStipo { get; set; }
        [Required]
        [StringLength(45)]
        public string tipo { get; set; }
        [Required]
        [StringLength(45)]
        public string color { get; set; }

        [InverseProperty("id_cincoStipoNavigation")]
        public virtual ICollection<cincosbitacora_cincostipo> cincosbitacora_cincostipos { get; set; }
    }
}
