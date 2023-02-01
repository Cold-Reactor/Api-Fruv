using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_area", Name = "fk_consultorio_area1_idx")]
    [Index("id_empleado", Name = "fk_consultorio_empleados1_idx")]
    public partial class consultum
    {
        public consultum()
        {
            id_diagnosticos = new HashSet<diagnostico>();
            id_medicamentos = new HashSet<medicamento>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_consulta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }

        [ForeignKey("id_area")]
        [InverseProperty("consulta")]
        public virtual area id_areaNavigation { get; set; }
        [ForeignKey("id_empleado")]
        [InverseProperty("consulta")]
        public virtual empleado id_empleadoNavigation { get; set; }

        [ForeignKey("id_consulta")]
        [InverseProperty("id_consulta")]
        public virtual ICollection<diagnostico> id_diagnosticos { get; set; }
        [ForeignKey("id_consulta")]
        [InverseProperty("id_consulta")]
        public virtual ICollection<medicamento> id_medicamentos { get; set; }
    }
}
