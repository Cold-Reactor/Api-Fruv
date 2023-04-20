using System;

namespace api_SIF.Models.EmpleadosN
{
    public class requestCheck
    {
        public int id_checadas { get; set; }
        public int id_checador { get; set; }

        public int nomina { get; set; }
        public string hora { get; set; }
        public string horaM { get; set; }
        public DateOnly fecha { get; set; }
        public int id_empleado { get; set; }
    }
}
