using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Faltaxrh
    {
        public int Id { get; set; }
        public int? Noempleado { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? NoempleadoRegistro { get; set; }
    }
}
