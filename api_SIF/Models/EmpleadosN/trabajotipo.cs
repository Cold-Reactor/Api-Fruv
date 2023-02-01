using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("trabajotipo")]
    public partial class trabajotipo
    {
        public trabajotipo()
        {
            trabajoexternos = new HashSet<trabajoexterno>();
            trabajointernos = new HashSet<trabajointerno>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_trabajoT { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string trabajoT { get; set; }

        [InverseProperty("id_tipoNavigation")]
        public virtual ICollection<trabajoexterno> trabajoexternos { get; set; }
        [InverseProperty("id_tipo_trabajoNavigation")]
        public virtual ICollection<trabajointerno> trabajointernos { get; set; }
    }
}
