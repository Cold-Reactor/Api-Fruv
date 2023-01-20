using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Vacacion
    {
        public int Id { get; set; }
        public DateOnly? FechaRegistro { get; set; }
        public int? NoEmpleado { get; set; }
        public bool? Gozado { get; set; }
        public bool? Pagado { get; set; }
        public string TotalDias { get; set; }
        public bool? Estado { get; set; }
        public DateOnly? FechaRegreso { get; set; }
        public int? IdSupervisor { get; set; }
        public int? UserRegistroId { get; set; }
        public int? Diascorrespondientes { get; set; }
        public int? Periodo { get; set; }
    }
}
