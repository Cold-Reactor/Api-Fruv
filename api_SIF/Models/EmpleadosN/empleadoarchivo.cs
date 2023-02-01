using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("empleadoarchivo")]
    [Index("id_empleadoArchivoT", Name = "fk_empleadoArchivo_empleadoTipoArchivo1_idx")]
    [MySqlCollation("utf8_spanish_ci")]
    public partial class empleadoarchivo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_empleadoArchivo { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleadoArchivoT { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string ruta { get; set; }

        [ForeignKey("id_empleadoArchivoT")]
        [InverseProperty("empleadoarchivos")]
        public virtual empleadotipoarchivo id_empleadoArchivoTNavigation { get; set; }
    }
}
