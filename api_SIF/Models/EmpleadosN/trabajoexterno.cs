using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("trabajoexterno")]
    [Index("id_area", Name = "fk_trabajoExterno_area1_idx")]
    [Index("id_departamento", Name = "fk_trabajoExterno_departamento1_idx")]
    [Index("id_empleado", Name = "fk_trabajo_empleados1_idx")]
    [Index("id_tipo", Name = "fk_trabajo_trabajo_tipo1_idx")]
    public partial class trabajoexterno
    {
        public trabajoexterno()
        {
            hipertensions = new HashSet<hipertension>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_trabajoE { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_solicitante { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_tipo { get; set; }
        [StringLength(45)]
        public string proveedor { get; set; }
        [StringLength(45)]
        public string nombreResponsable { get; set; }
        public DateOnly? fechaRegistro { get; set; }
        public DateOnly? fechaTrabajo { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_sucursal { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_departamento { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_supervisor { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? equipo { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? medidasSeguridad { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? condicionAreaTrabajo { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? rs { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? liberacionSH { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? conformidad { get; set; }
        [StringLength(45)]
        public string comentario { get; set; }
        public DateOnly? fechaCumplimiento { get; set; }
        public DateOnly? fechaCompromiso { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? cancelado { get; set; }

        [ForeignKey("id_area")]
        [InverseProperty("trabajoexternos")]
        public virtual area id_areaNavigation { get; set; }
        [ForeignKey("id_departamento")]
        [InverseProperty("trabajoexternos")]
        public virtual departamento id_departamentoNavigation { get; set; }
        [ForeignKey("id_empleado")]
        [InverseProperty("trabajoexternos")]
        public virtual empleado id_empleadoNavigation { get; set; }
        [ForeignKey("id_tipo")]
        [InverseProperty("trabajoexternos")]
        public virtual trabajotipo id_tipoNavigation { get; set; }
        [InverseProperty("id_trabajoENavigation")]
        public virtual ICollection<hipertension> hipertensions { get; set; }
    }
}
