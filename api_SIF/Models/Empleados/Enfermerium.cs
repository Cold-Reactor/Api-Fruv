using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Enfermerium
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Atencion { get; set; }
        public string NoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Departamento { get; set; }
        public string Turno { get; set; }
        public string JefeInmediato { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Incidencia { get; set; }
    }
}
