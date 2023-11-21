using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("cincosbitacora_cincostipo")]
    [Index("id_bitacora", Name = "fk_cincoSbitacora_has_cincoStipo_cincoSbitacora1_idx")]
    [Index("id_cincoStipo", Name = "fk_cincoSbitacora_has_cincoStipo_cincoStipo1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class cincosbitacora_cincostipo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_bitacora { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_cincoStipo { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? valor { get; set; }

        //[ForeignKey("id_bitacora")]
        //[InverseProperty("cincosbitacora_cincostipos")]
        //public virtual cincosbitacora id_bitacoraNavigation { get; set; }
        //[ForeignKey("id_cincoStipo")]
        //[InverseProperty("cincosbitacora_cincostipos")]
        //public virtual cincostipo id_cincoStipoNavigation { get; set; }
    }
}
