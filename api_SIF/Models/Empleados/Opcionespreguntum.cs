using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Opcionespreguntum
    {
        public int Id { get; set; }
        public int? Opcion { get; set; }
        public int? Pregunta { get; set; }
    }
}
