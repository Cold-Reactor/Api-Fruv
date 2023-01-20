using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Permiso
    {
        public int Id { get; set; }
        public int? Noempleado { get; set; }
        public DateOnly? FechaCreacion { get; set; }
        public TimeOnly? HoraCreacion { get; set; }
        public int? Supervisor { get; set; }
        public int? Modalidad { get; set; }
        public DateOnly? FechaSolicitadaDesde { get; set; }
        public DateOnly? FechaSolicitadaHasta { get; set; }
        public TimeOnly? HoraSolicitadaDesde { get; set; }
        public TimeOnly? HoraSolicitadaHasta { get; set; }
        public double? Horas { get; set; }
        public string Motivo { get; set; }
        public int? Dias { get; set; }
        public int? Estado { get; set; }
        public int? Autorizo { get; set; }
        public TimeOnly? Horadesde { get; set; }
        public TimeOnly? Horahasta { get; set; }
        public int? Pagado { get; set; }
    }
}
