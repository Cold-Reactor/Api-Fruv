using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Turno
    {
        public int Id { get; set; }
        public string Turno1 { get; set; }
        public bool? Disponible { get; set; }
    }
}
