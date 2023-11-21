using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_area", Name = "fk_partida_area1_idx")]
    [Index("id_departamento", Name = "fk_partida_departamento1_idx")]
    [Index("id_presupuesto", Name = "fk_partida_presupuesto1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class partidum
    {
        public partidum()
        {
            //solicitudcompras = new HashSet<solicitudcompra>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_partida { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_departamento { get; set; }
        [StringLength(45)]
        public string grupo { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_presupuesto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_area { get; set; }

        //[ForeignKey("id_area")]
        //[InverseProperty("partida")]
        //public virtual area id_areaNavigation { get; set; }
        //[ForeignKey("id_departamento")]
        //[InverseProperty("partida")]
        //public virtual departamento id_departamentoNavigation { get; set; }
        //[ForeignKey("id_presupuesto")]
        //[InverseProperty("partida")]
        //public virtual presupuesto id_presupuestoNavigation { get; set; }
        //[InverseProperty("id_partidaNavigation")]
        //public virtual ICollection<solicitudcompra> solicitudcompras { get; set; }
    }
}
