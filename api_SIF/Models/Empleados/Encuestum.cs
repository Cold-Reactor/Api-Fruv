using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Encuestum
    {
        public int Id { get; set; }
        public DateOnly? FechaCreacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int? Creador { get; set; }
        public int? Estado { get; set; }
    }
}
