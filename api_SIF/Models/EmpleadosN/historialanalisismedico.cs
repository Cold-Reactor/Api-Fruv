using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("historialanalisismedico")]
    [Index("id_analisisT", Name = "fk_historialAnalisis_analisisTipo1_idx")]
    [Index("id_empleado", Name = "fk_historialAnalisis_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class HistorialAnalisisMedico
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_historialA { get; set; }
        public DateOnly fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_analisisT { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        public string resultados { get; set; }

        //[ForeignKey("id_analisisT")]
        //[InverseProperty("historialanalisismedicos")]
        //public virtual analisistipo id_analisisTNavigation { get; set; }
        //[ForeignKey("id_empleado")]
        //[InverseProperty("historialanalisismedicos")]
        //public virtual empleado id_empleadoNavigation { get; set; }
    }
}
