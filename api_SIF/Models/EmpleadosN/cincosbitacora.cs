using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("cincosbitacora")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class cincosbitacora
    {
        public cincosbitacora()
        {
            //cincosbitacora_cincostipos = new HashSet<cincosbitacora_cincostipo>();
            //id_areas = new HashSet<area>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_bitacora { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_sucursal { get; set; }
        public DateOnly fecha { get; set; }

        //[InverseProperty("id_bitacoraNavigation")]
        //public virtual ICollection<cincosbitacora_cincostipo> cincosbitacora_cincostipos { get; set; }

        //[ForeignKey("id_bitacora")]
        //[InverseProperty("id_bitacoras")]
        //public virtual ICollection<area> id_areas { get; set; }
    }
}
