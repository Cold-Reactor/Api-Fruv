using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class User
    {
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
        public string Grupo { get; set; }
    }
}
