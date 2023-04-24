using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_SIF.Models.EmpleadosN
{
    public class requestDepartamento
    {
        public int id_departamento { get; set; }
       
       public string departamento { get; set; }
    }
}
