using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("presupuesto")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class presupuesto
    {
        public presupuesto()
        {
            partida = new HashSet<partidum>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_presupuesto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? cantidad { get; set; }

        [InverseProperty("id_presupuestoNavigation")]
        public virtual ICollection<partidum> partida { get; set; }
    }
}
