using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    public class RequestPlantillaGuardia
    {

        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "tinytext")]
        public string nombre { get; set; }
        [MaxLength(1000)]
        public string imagen { get; set; }
        public List<plantillaSeguridad> plantilla { get; set; }

    }
}
