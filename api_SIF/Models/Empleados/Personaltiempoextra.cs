using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Personaltiempoextra
    {
        public int Id { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdEmpleado { get; set; }
        public int? NoEmpleado { get; set; }
        public TimeOnly? Desde { get; set; }
        public TimeOnly? Hasta { get; set; }
        public double? Horas { get; set; }
        public sbyte? Autorizado { get; set; }
        public double? TiempoTrabajado { get; set; }
        public string Actividad { get; set; }
        public int? Idactividad { get; set; }
        public double? Pago { get; set; }
    }
}
