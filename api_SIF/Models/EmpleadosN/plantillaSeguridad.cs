using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    public class plantillaSeguridad
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_plantillaS { get; set; }
        [Required]
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_turno { get; set; }
        public DateOnly fecha { get; set; }

    }
}
