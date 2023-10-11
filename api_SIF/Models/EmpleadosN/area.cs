using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("area")]
    [Index("id_departamento", Name = "fk_area_departamento1_idx")]
    [Index("id_area", Name = "id", IsUnique = true)]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class area
    {
        public area()
        {
            accidentes = new HashSet<accidente>();
            consulta = new HashSet<consultum>();
            inmobiliarios = new HashSet<inmobiliario>();
            partida = new HashSet<partidum>();
            trabajoexternos = new HashSet<trabajoexterno>();
            trabajointernos = new HashSet<trabajointerno>();
            id_bitacoras = new HashSet<cincosbitacora>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id_area { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_departamento { get; set; }
        [Required]
        [Column("area", TypeName = "tinytext")]
        public string area1 { get; set; }

        [ForeignKey("id_departamento")]
        [InverseProperty("areas")]
        public virtual departamento id_departamentoNavigation { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<accidente> accidentes { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<consultum> consulta { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<inmobiliario> inmobiliarios { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<partidum> partida { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<trabajoexterno> trabajoexternos { get; set; }
        [InverseProperty("id_areaNavigation")]
        public virtual ICollection<trabajointerno> trabajointernos { get; set; }

        [ForeignKey("id_area")]
        [InverseProperty("id_areas")]
        public virtual ICollection<cincosbitacora> id_bitacoras { get; set; }
    }
}
