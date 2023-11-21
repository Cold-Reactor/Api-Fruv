using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("inmobiliario")]
    [Index("id_area", Name = "fk_inmobiliario_area1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class inmobiliario
    {
        public inmobiliario()
        {
            //trabajointernos = new HashSet<trabajointerno>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_inmobiliario { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Required]
        [Column("inmobiliario")]
        [StringLength(45)]
        public string inmobiliario1 { get; set; }

        //[ForeignKey("id_area")]
        //[InverseProperty("inmobiliarios")]
        //public virtual area id_areaNavigation { get; set; }
        //[InverseProperty("id_inmobiliarioNavigation")]
        //public virtual ICollection<trabajointerno> trabajointernos { get; set; }
    }
}
