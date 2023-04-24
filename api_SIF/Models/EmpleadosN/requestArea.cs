using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_SIF.Models.EmpleadosN
{
    public class requestArea
    {
        public int id_area { get; set; }
        public int id_departamento { get; set; }
        public string area { get; set; }
    }
}
