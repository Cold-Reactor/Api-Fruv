using System;

namespace api_SIF.Models.EmpleadosN
{
    public class requestCheck
    {
        public int id { get; set; }
        public int nomina { get; set; }
        public string hora { get; set; }
        public DateTime horaM { get; set; }
        public DateOnly fecha { get; set; }
        public int id_empleado { get; set; }
    }
}
