using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Models
{
    public class EstadoTicket
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
    }
}
