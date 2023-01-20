using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Pariente
    {
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public int? RelacionNoEmpleado { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Puesto { get; set; }
        public string Area { get; set; }
        public string Parentesco { get; set; }
    }
}
