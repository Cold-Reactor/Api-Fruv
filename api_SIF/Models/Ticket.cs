using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public DateTime? fecharegistro { get; set; }
        public TimeSpan? horaregistro { get; set; }
        public int? reporto { get; set; }
        public int? asignado { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public DateTime? fechasolucion { get; set; }
        public string descripcionsolucion  { get; set; }
        public int? urgente { get; set; }
        public int? importante { get; set; }
        public DateTime? fechacompromiso  { get; set; }
        public string categoria { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
