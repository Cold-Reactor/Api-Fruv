using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("solicitudcompra")]
    [Index("id_partida", Name = "fk_solicitudCompra_partida1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class solicitudcompra
    {
        public solicitudcompra()
        {
            cotizacions = new HashSet<cotizacion>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_solicitudC { get; set; }
        public DateOnly? fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_sucursal { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_departamento { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_solicitante { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_partida { get; set; }
        [StringLength(45)]
        public string descripcion { get; set; }
        [Column(TypeName = "int(1)")]
        public int? status { get; set; }

        [ForeignKey("id_partida")]
        [InverseProperty("solicitudcompras")]
        public virtual partidum id_partidaNavigation { get; set; }
        [InverseProperty("id_solicitudCNavigation")]
        public virtual ICollection<cotizacion> cotizacions { get; set; }
    }
}
