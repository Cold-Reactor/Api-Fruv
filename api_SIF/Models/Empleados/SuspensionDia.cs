using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class SuspensionDia
    {
        public int Id { get; set; }
        public int? IdSuspension { get; set; }
        public DateOnly? Fecha { get; set; }
    }
}
