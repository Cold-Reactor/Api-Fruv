using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("trabajointerno")]
    [Index("id_area", Name = "fk_trabajoInterno_area1_idx")]
    [Index("id_departamento", Name = "fk_trabajoInterno_departamento1_idx")]
    [Index("id_empleado", Name = "fk_trabajoInterno_empleado1_idx")]
    [Index("id_inmobiliario", Name = "fk_trabajoInterno_inmobiliario1_idx")]
    [Index("id_tipo_trabajo", Name = "fk_trabajoInterno_trabajoTipo1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class trabajointerno
    {
        public trabajointerno()
        {
            //trabajo_refaccions = new HashSet<trabajo_refaccion>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_trabajoI { get; set; }
        public DateOnly? fechaRegistro { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_solicitante { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_sucursal { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_departamento { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_tipo_trabajo { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_inmobiliario { get; set; }
        [StringLength(45)]
        public string descripcion { get; set; }
        [Column(TypeName = "tinytext")]
        public string clasificacion { get; set; }
        [Column(TypeName = "tinytext")]
        public string prioridad { get; set; }
        public DateOnly? fechaCompromiso { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? equipoTrabajo { get; set; }
        public DateOnly? fechaCumplimiento { get; set; }
        [StringLength(45)]
        public string solucion { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? liberacionSH { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_supervisor { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? cancelado { get; set; }

        //[ForeignKey("id_area")]
        //[InverseProperty("trabajointernos")]
        //public virtual area id_areaNavigation { get; set; }
        //[ForeignKey("id_departamento")]
        //[InverseProperty("trabajointernos")]
        //public virtual departamento id_departamentoNavigation { get; set; }
        //[ForeignKey("id_empleado")]
        //[InverseProperty("trabajointernos")]
        //public virtual empleado id_empleadoNavigation { get; set; }
        //[ForeignKey("id_inmobiliario")]
        //[InverseProperty("trabajointernos")]
        //public virtual inmobiliario id_inmobiliarioNavigation { get; set; }
        //[ForeignKey("id_tipo_trabajo")]
        //[InverseProperty("trabajointernos")]
        //public virtual trabajotipo id_tipo_trabajoNavigation { get; set; }
        //[InverseProperty("id_trabajoINavigation")]
        //public virtual ICollection<trabajo_refaccion> trabajo_refaccions { get; set; }
    }
}
