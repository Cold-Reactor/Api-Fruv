using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace api_SIF.Models.EmpleadosN
{
    public class requestChecadas
    {
        public int id_checadas { get; set; }
        public int id_empleado { get; set; }
        public int id_checador { get; set; }
        public DateTime fechaHora { get; set; }
        public DateOnly fecha { get; set; }
        public TimeOnly hora { get; set; }
        public sbyte? nomina { get; set; }
    }
}
