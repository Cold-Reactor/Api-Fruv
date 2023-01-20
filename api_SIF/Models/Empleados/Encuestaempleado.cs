using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Encuestaempleado
    {
        public int Id { get; set; }
        public int? Encuesta { get; set; }
        public int? Noempleado { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFinal { get; set; }
        public int? Area { get; set; }
    }
}
