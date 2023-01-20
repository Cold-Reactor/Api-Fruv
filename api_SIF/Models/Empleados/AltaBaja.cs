using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class AltaBaja
    {
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public DateOnly Fecha { get; set; }
        public int? Alta { get; set; }
        public int? Baja { get; set; }
        public string Razon { get; set; }
    }
}
