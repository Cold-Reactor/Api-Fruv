using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Turnodetalle
    {
        public int Id { get; set; }
        public int? Turno { get; set; }
        public int? Dia { get; set; }
        public TimeOnly? HrEntrada { get; set; }
        public TimeOnly? HrSalida { get; set; }
    }
}
