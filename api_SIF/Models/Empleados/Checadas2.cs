using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Checadas2
    {
        public int Id { get; set; }
        public int? id_checador { get; set; }
        public int? idempleado { get; set; }

        public string Noempleado { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public string RazonManual { get; set; }
        public int? Numeroempleado { get; set; }
        public int? Sucursal { get; set; }
        public int? Retardo { get; set; }
        public DateTime? Fechasubida { get; set; }
    }
}
