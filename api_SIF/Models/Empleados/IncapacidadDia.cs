using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class IncapacidadDia
    {
        public int Id { get; set; }
        public int? IdIncapacidad { get; set; }
        public DateOnly? Fecha { get; set; }
    }
}
