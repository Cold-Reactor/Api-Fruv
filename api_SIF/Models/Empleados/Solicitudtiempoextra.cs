using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class Solicitudtiempoextra
    {
        public int Id { get; set; }
        public int? Folio { get; set; }
        public int? Sucursal { get; set; }
        public int? Solicitante { get; set; }
        public DateOnly? FechaSolicitud { get; set; }
        public TimeOnly? HoraSolicitud { get; set; }
        public DateOnly? FechaSolicitada { get; set; }
        public int? Area { get; set; }
        public int? Departamento { get; set; }
        public string Justificacion { get; set; }
        public int? Estado { get; set; }
        public int? Autorizo { get; set; }
        public int? AutorizoGerenteRh { get; set; }
    }
}
