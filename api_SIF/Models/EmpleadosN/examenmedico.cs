using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("examenmedico")]
    [Index("id_empleado", Name = "fk_examen_medico_empleados1_idx")]
    [MySqlCollation("utf8_spanish2_ci")]
    public partial class examenmedico
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_examen { get; set; }
        public DateOnly fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [StringLength(50)]
        public string enfermedadInfancia { get; set; }
        [StringLength(45)]
        public string enfermedadActual { get; set; }
        [Column(TypeName = "tinytext")]
        public string tx { get; set; }
        [StringLength(45)]
        public string enfermedadPadres { get; set; }
        [StringLength(45)]
        public string cirugias { get; set; }
        [Column(TypeName = "tinytext")]
        public string fx { get; set; }
        [Column(TypeName = "tinytext")]
        public string ta { get; set; }
        [Column(TypeName = "tinytext")]
        public string fc { get; set; }
        [Column(TypeName = "tinytext")]
        public string fr { get; set; }
        [Column(TypeName = "tinytext")]
        public string temperatura { get; set; }
        [Column(TypeName = "tinytext")]
        public string peso { get; set; }
        [Column(TypeName = "tinytext")]
        public string talla { get; set; }
        [Column(TypeName = "tinytext")]
        public string tabaquismo { get; set; }
        [Column(TypeName = "tinytext")]
        public string alcoholismo { get; set; }
        [Column(TypeName = "tinytext")]
        public string drogadiccion { get; set; }
        [Column(TypeName = "tinytext")]
        public string tatuajes { get; set; }
        [Column(TypeName = "tinytext")]
        public string pediculosis { get; set; }
        [Column(TypeName = "tinytext")]
        public string hta { get; set; }
        [Column(TypeName = "tinytext")]
        public string deabetes { get; set; }
        [Column(TypeName = "tinytext")]
        public string asma { get; set; }
        [Column(TypeName = "tinytext")]
        public string alergias { get; set; }
        [Column(TypeName = "tinytext")]
        public string varices { get; set; }
        [Column(TypeName = "tinytext")]
        public string enfermedadCardiaca { get; set; }
        [Column(TypeName = "tinytext")]
        public string colesterol { get; set; }
        [Column(TypeName = "tinytext")]
        public string trigliceridos { get; set; }
        [Column(TypeName = "tinytext")]
        public string enfermedadPulmonar { get; set; }
        [Column(TypeName = "tinytext")]
        public string epilepsia { get; set; }
        [Column(TypeName = "tinytext")]
        public string ansiedad { get; set; }
        [Column("enfermedad renal", TypeName = "tinytext")]
        public string enfermedad_renal { get; set; }
        [Column(TypeName = "tinytext")]
        public string lumbalgia { get; set; }
        [Column(TypeName = "tinytext")]
        public string hernia { get; set; }
        [Column(TypeName = "tinytext")]
        public string hepatitis { get; set; }
        [Column(TypeName = "tinytext")]
        public string gastritis { get; set; }
        [Column(TypeName = "tinytext")]
        public string dermatitis { get; set; }
        [Column(TypeName = "tinytext")]
        public string depresion { get; set; }
        [Column(TypeName = "tinytext")]
        public string cancer { get; set; }
        [Column(TypeName = "tinytext")]
        public string problemasAuditivos { get; set; }
        [Column(TypeName = "tinytext")]
        public string problemasVisuales { get; set; }
        [StringLength(45)]
        public string medicamentos { get; set; }
        [Column(TypeName = "tinytext")]
        public string tipoSangre { get; set; }
        [Column(TypeName = "tinytext")]
        public string ivs { get; set; }
        [StringLength(45)]
        public string metodoAnticonceptivo { get; set; }
        [Column(TypeName = "tinytext")]
        public string gestas { get; set; }
        [Column(TypeName = "tinytext")]
        public string partos { get; set; }
        [Column(TypeName = "tinytext")]
        public string abortos { get; set; }
        [Column(TypeName = "tinytext")]
        public string cesareas { get; set; }
        [Column(TypeName = "tinytext")]
        public string fur { get; set; }
        [Column(TypeName = "tinytext")]
        public string papanicolao { get; set; }
        [Column(TypeName = "tinytext")]
        public string mamografia { get; set; }
        [Column(TypeName = "tinytext")]
        public string od { get; set; }
        [Column(TypeName = "tinytext")]
        public string izq { get; set; }
        [Column(TypeName = "tinytext")]
        public string astigmatismo { get; set; }
        [Column(TypeName = "tinytext")]
        public string miopia { get; set; }
        [Column(TypeName = "tinytext")]
        public string daltonismo { get; set; }
        [Column(TypeName = "tinytext")]
        public string tablaOptometricaJaeger { get; set; }
        [Column(TypeName = "tinytext")]
        public string antidoping { get; set; }
        [Column(TypeName = "tinytext")]
        public string alcoholemia { get; set; }
        [Column(TypeName = "tinytext")]
        public string pie { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? covid { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? hospitalizacionCovid { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? dias { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? secuelas { get; set; }
        [StringLength(45)]
        public string cuales { get; set; }
        [StringLength(45)]
        public string vacunaCovid { get; set; }
        [StringLength(45)]
        public string espalda { get; set; }
        [StringLength(45)]
        public string extremidadesSup { get; set; }
        [StringLength(45)]
        public string extremidadesInf { get; set; }
        [StringLength(45)]
        public string observaciones { get; set; }
        [StringLength(45)]
        public string firmaRH { get; set; }

        [ForeignKey("id_empleado")]
        [InverseProperty("examenmedicos")]
        public virtual empleado id_empleadoNavigation { get; set; }
    }
}
