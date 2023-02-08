using System;
using System.Collections.Generic;

namespace api_SIF.Models.EmpleadosN
{
    public class requestChecadaCheck
    {
        public DateOnly fecha { get; set; }
        public int extra { get; set; }
        public int id_empleado { get; set; }

        public string ausentismo { get; set; }
        public List<requestCheck> checks{ get; set; }
    }
}
