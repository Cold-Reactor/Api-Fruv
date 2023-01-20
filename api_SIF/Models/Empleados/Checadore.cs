using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Checadore
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SerialNumber { get; set; }
        public int? Sucursal { get; set; }
    }
}
