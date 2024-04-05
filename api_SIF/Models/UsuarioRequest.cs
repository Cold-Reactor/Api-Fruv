namespace api_SIF.Models
{
    public class UsuarioRequest
    {
        public string username { get; set; }
        public int? id_sucursal { get; set; }
        public int? no_empleado { get; set; }
        public int? id_empleado { get; set; }
        public  bool? master { get; set; }
        public string nombre { get; set; }
        public int? god { get; set; }

        public int? departamento { get; set; }
    }
}
