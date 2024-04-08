using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    public class bitacoraSeguridad
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_bitacoraS { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string descripcion { get; set; }
        [MaxLength(1000)]
        public string imagen { get; set; }
        [Column(TypeName = "int(1)")]
        public int? relevante { get; set; }
        [Column(TypeName = "int(11)")]
        public int registro { get; set; }
    }
}
