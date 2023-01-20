using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Diasferiado
    {
        public int Id { get; set; }
        public DateOnly? Fechafinal { get; set; }
        public DateOnly? FechaOriginal { get; set; }
        public string Motivo { get; set; }
        public string Texto { get; set; }
        public bool? Turno { get; set; }
    }
}
