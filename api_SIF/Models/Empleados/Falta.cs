using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Falta
    {
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public DateOnly Falta1 { get; set; }
        public int? Permiso { get; set; }
        public int? Suspencion { get; set; }
        public int? Justificada { get; set; }
        public string Comentario { get; set; }
    }
}
