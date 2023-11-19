using System.ComponentModel.DataAnnotations.Schema;

namespace api_SIF.Models
{
    public class PuestoRequest
    {
        public int id_puesto { get; set; }
        
        public string nombre { get; set; }
        public int id_empleadoT { get; set; }
    }
}
