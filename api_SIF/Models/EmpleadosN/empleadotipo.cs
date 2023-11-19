using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleadotipo")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class empleadotipo
    {
        public empleadotipo()
        {
            //puestos = new HashSet<puesto>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleadoT { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }

        //[InverseProperty("id_empleadoTNavigation")]
        //public virtual ICollection<puesto> puestos { get; set; }
    }
}
