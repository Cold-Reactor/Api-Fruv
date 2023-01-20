using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Incapacidad
    {
        public int Id { get; set; }
        public int? Noempleado { get; set; }
        public DateOnly? FechaDesde { get; set; }
        public DateOnly? FechaHasta { get; set; }
        public int? Permanente { get; set; }
        public int? Motivo { get; set; }
        public string Comentarios { get; set; }
        public int? Dias { get; set; }
        public DateOnly? FechaCreacion { get; set; }
        public sbyte? Cancelado { get; set; }
    }
}
