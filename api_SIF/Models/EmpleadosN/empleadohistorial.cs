using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleadohistorial")]
    [Index("id_tipoBaja", Name = "fk_empleado_historial_tipo_baja1_idx")]
    [Index("id_empleado", Name = "fk_empleado_status_empleados1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class empleadohistorial
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleadoHistorial { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_tipoBaja { get; set; }
        public DateOnly? fecha { get; set; }
        public double? salario { get; set; }
        public int id_puesto { get; set; }
        [StringLength(45)]
        public string razon { get; set; }

        //[ForeignKey("id_empleado")]
        //[InverseProperty("empleadohistorials")]
        //public virtual empleado id_empleadoNavigation { get; set; }
        //[ForeignKey("id_tipoBaja")]
        //[InverseProperty("empleadohistorials")]
        //public virtual tipobaja id_tipoBajaNavigation { get; set; }
    }
}
