using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("vacacionesperiodo")]
    public partial class vacacionesperiodo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_vacacionesP { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte años { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte dias { get; set; }
        [Column(TypeName = "int(11)")]
        public int pago { get; set; }
    }
}
