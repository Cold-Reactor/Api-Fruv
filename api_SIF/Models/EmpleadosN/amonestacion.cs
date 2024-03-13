using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("amonestacion")]
    [Index("id_empleado", Name = "fk_amonestacion_empleado1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class amonestacion
    {
        public amonestacion()
        {
            //status = 1;
        }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_amonestacion { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fecha { get; set; }
        [Column(TypeName = "text")]
        public string causa { get; set; }
        [Column(TypeName = "text")]
        public string comentario { get; set; }
        [Column(TypeName = "int(11)")]
        public int? realizo { get; set; }
        [Column(TypeName = "text")]
        public string firmaAmonestado { get; set; }
        //agrega status de tipo bit
        [Column(TypeName = "int(1)")]
        public int? status { get; set; }
       
        //[ForeignKey("id_empleado")]
        //[InverseProperty("amonestacions")]
        //public virtual empleado id_empleadoNavigation { get; set; }
    }
}
