using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Empleadoarchivo
    {
        public int Id { get; set; }
        public int? Noempleado { get; set; }
        public int? Tipo { get; set; }
        public string Ruta { get; set; }
    }
}
