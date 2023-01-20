using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Vacacione
    {
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public DateOnly Fecha { get; set; }
        public int? Sale { get; set; }
        public int? Entra { get; set; }
        public int? Pagadas { get; set; }
        public string Comentario { get; set; }
    }
}
