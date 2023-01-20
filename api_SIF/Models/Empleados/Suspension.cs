using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Suspension
    {
        public int Id { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public int? Supervisor { get; set; }
        public int? Empleado { get; set; }
        public string Causa { get; set; }
        public int? Estado { get; set; }
        public int? Registro { get; set; }
        public int? Departamento { get; set; }
        public string Firmaamonestado { get; set; }
        public string FirmaSupervisor { get; set; }
        public string FirmaRecursosHumanos { get; set; }
        public int? Dias { get; set; }
    }
}
