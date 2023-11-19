using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_SIF.Models.EmpleadosN
{
    public class requestSucursales
    {
        public int id_sucursal { get; set; }
       
        public string sucursal { get; set; }

        public string nomenclatura { get; set; }

    }
}
