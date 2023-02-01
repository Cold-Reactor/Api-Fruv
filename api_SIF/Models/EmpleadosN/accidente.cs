using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Index("id_area", Name = "fk_incapacidad_area1_idx")]
    [Index("id_empleado", Name = "fk_incapacidad_empleados1_idx")]
    public partial class accidente
    {
        public accidente()
        {
            id_diagnosticos = new HashSet<diagnostico>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_accidentes { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string causualidad { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fechaCreacion { get; set; }
        public DateOnly fechaAccidente { get; set; }
        public DateOnly fechaRetorno { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong inicia_ST7 { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong cierre_ST2 { get; set; }
        [Required]
        [Column(TypeName = "tinytext")]
        public string atencion { get; set; }
        [Column(TypeName = "int(11)")]
        public int dias { get; set; }
        [Required]
        [StringLength(45)]
        public string descripcion { get; set; }
        [Required]
        [StringLength(45)]
        public string recomendacion { get; set; }

        [ForeignKey("id_area")]
        [InverseProperty("accidentes")]
        public virtual area id_areaNavigation { get; set; }
        [ForeignKey("id_empleado")]
        [InverseProperty("accidentes")]
        public virtual empleado id_empleadoNavigation { get; set; }

        [ForeignKey("id_accidente")]
        [InverseProperty("id_accidentes")]
        public virtual ICollection<diagnostico> id_diagnosticos { get; set; }
    }
}
