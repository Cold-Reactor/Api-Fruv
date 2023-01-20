using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Preguntum
    {
        public int Id { get; set; }
        public int? Idencuesta { get; set; }
        public string DescripcionPregunta { get; set; }
        public int? Tipo { get; set; }
        public string Adicional { get; set; }
    }
}
