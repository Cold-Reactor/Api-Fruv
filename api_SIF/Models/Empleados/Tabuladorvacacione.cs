using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Tabuladorvacacione
    {
        public int Id { get; set; }
        public int? RangoA { get; set; }
        public int? RangoB { get; set; }
        public int? DiasCorrespondientes { get; set; }
    }
}
