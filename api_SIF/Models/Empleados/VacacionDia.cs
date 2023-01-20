using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class VacacionDia
    {
        public int Id { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? IdVacacion { get; set; }
    }
}
