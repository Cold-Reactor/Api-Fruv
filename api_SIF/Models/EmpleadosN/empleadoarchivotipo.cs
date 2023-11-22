using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleadotipoarchivo")]
    [MySqlCollation("utf8_spanish_ci")]
    public partial class empleadoarchivotipo
    {
        public empleadoarchivotipo()
        {
            //empleadoarchivos = new HashSet<empleadoarchivo>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleadoArchivoT { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string tipo { get; set; }

        //[InverseProperty("id_empleadoArchivoTNavigation")]
        //public virtual ICollection<empleadoarchivo> empleadoarchivos { get; set; }
    }
}
