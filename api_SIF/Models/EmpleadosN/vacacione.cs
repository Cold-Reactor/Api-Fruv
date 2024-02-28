using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_empleado", Name = "fk_vacaciones_empleados1_idx")]
    [MySqlCollation("utf8_spanish_ci")]
    public partial class vacacione
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_vacaciones { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        public DateOnly? fechaInicio { get; set; }
        public DateOnly? fechaRegreso { get; set; }
        [Column(TypeName = "int(11)")]
        public int? dias { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? gozado { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? pagado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cantidadPago { get; set; }
        [Column(TypeName = "int(1)")]
        public ulong? status { get; set; }


        //[ForeignKey("id_empleado")]
        //[InverseProperty("vacaciones")]
        //public virtual empleado id_empleadoNavigation { get; set; }
    }
}
