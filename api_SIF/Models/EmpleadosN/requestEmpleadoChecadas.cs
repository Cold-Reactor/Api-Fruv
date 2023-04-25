using System.Collections.Generic;

namespace api_SIF.Models.EmpleadosN
{
    public class requestEmpleadoChecadas
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public int noEmpleado { get; set; }
        public int? sucursal { get; set; }

        public string turno { get; set; }
        public int? id_area { get; set; }

        public string area { get; set; }
        public int presencial { get; set; }
        public List<requestChecadaCheck> checadas { get; set; }
    }
}
