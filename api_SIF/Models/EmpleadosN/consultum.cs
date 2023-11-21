using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_area", Name = "fk_consultorio_area1_idx")]
    [Index("id_empleado", Name = "fk_consultorio_empleados1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class consultum
    {
        public consultum()
        {
            //consulta_medicamentos = new HashSet<consulta_medicamento>();
            //id_diagnosticos = new HashSet<diagnostico>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_consulta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_area { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_empleado { get; set; }
        [StringLength(45)]
        public string nombre { get; set; }
        [Column(TypeName = "tinytext")]
        public string hta { get; set; }
        [StringLength(45)]
        public string comentario { get; set; }

        //[ForeignKey("id_area")]
        //[InverseProperty("consulta")]
        //public virtual area id_areaNavigation { get; set; }
        //[ForeignKey("id_empleado")]
        //[InverseProperty("consulta")]
        //public virtual empleado id_empleadoNavigation { get; set; }
        //[InverseProperty("id_consultaNavigation")]
        //public virtual ICollection<consulta_medicamento> consulta_medicamentos { get; set; }

        //[ForeignKey("id_consulta")]
        //
        //"id_consulta")]
        //public virtual ICollection<diagnostico> id_diagnosticos { get; set; }
    }
}
