using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace api_SIF.Models.EmpleadosN
{
    public class RequestAmonestacion
    {
       
        public int id_amonestacion { get; set; }
        public int id_empleado { get; set; }
        public DateTime? fecha { get; set; }
        public string causa { get; set; }
        public string comentario { get; set; }
        public int? realizo { get; set; }
        public string firmaAmonestado { get; set; }
        public string nombreSupervisor { get; set; }
        public string nombreAmonestado { get; set; }
    }
}
