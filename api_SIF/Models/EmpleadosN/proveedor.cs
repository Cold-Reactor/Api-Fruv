using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("proveedor")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class Proveedor
    {
        public Proveedor()
        {
            //cotizacions = new HashSet<cotizacion>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_proveedor { get; set; }
        [Column(TypeName = "tinytext")]
        public string proveedor { get; set; }
        [Column(TypeName = "tinytext")]
        public string calle { get; set; }
        [Column(TypeName = "tinytext")]
        public string ciudad { get; set; }
        [Column(TypeName = "int(11)")]
        [Required]
        public int? id_estado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? codigoPostal { get; set; }
        [Column(TypeName = "int(11)")]
        public int? telefono { get; set; }
        [Column(TypeName = "tinytext")]
        public string contacto { get; set; }
        [Column(TypeName = "tinytext")]
        public string correo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? celular { get; set; }
        [StringLength(45)]
        public string notas { get; set; }

        //[InverseProperty("id_proveedorNavigation")]
        //public virtual ICollection<cotizacion> cotizacions { get; set; }
    }
}
