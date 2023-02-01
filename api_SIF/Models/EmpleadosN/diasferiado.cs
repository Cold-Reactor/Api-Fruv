using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    public partial class diasferiado
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_diasFeriados { get; set; }
        public DateOnly? fechaInicial { get; set; }
        public DateOnly? fechaFinal { get; set; }
        [Column(TypeName = "text")]
        public string motivo { get; set; }
        [StringLength(20)]
        public string texto { get; set; }
    }
}
