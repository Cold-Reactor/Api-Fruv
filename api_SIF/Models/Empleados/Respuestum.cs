using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Respuestum
    {
        public int Id { get; set; }
        public int? Pregunta { get; set; }
        public int? EncuestaEmpleado { get; set; }
        public int? Respuesta { get; set; }
        public string Texto { get; set; }
        public int? RespuestaDirecta { get; set; }
    }
}
