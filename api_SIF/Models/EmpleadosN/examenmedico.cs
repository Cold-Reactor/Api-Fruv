using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("examenmedico")]
    [Index("id_examenMedicoT", Name = "fk_examenMedico_examenMedicoT1_idx")]
    [Index("id_empleado", Name = "fk_examen_medico_empleados1_idx")]
    public partial class examenmedico
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id_examenMedico { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_examenMedicoT { get; set; }
        public DateOnly fecha { get; set; }
        [Column(TypeName = "int(11)")]
        public int id_empleado { get; set; }
        [Column(TypeName = "int(11)")]
        public int? id_responsable { get; set; }
        [Column(TypeName = "text")]
        public string empresa { get; set; }
        [Column(TypeName = "text")]
        public string puesto { get; set; }
        [Column(TypeName = "text")]
        public string antiguedad { get; set; }
        [Column(TypeName = "text")]
        public string EPP { get; set; }
        [Column(TypeName = "int(1)")]
        public int? accidentes { get; set; }
        [Column(TypeName = "text")]
        public string textAccidente { get; set; }
        [Column(TypeName = "int(1)")]
        public int? alergias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? cirugias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? migranas { get; set; }
        [Column(TypeName = "int(1)")]
        public int? hepatitis { get; set; }
        [Column(TypeName = "int(1)")]
        public int? problemasRenales { get; set; }
        [Column(TypeName = "int(1)")]
        public int? covid { get; set; }
        [Column(TypeName = "int(1)")]
        public int? dermatosis { get; set; }
        [Column(TypeName = "int(1)")]
        public int? diabetes { get; set; }
        [Column(TypeName = "int(1)")]
        public int? hta { get; set; }
        [Column(TypeName = "int(1)")]
        public int? gastritis { get; set; }
        [Column(TypeName = "int(1)")]
        public int? varices { get; set; }
        [Column(TypeName = "text")]
        public string enfermedadInfancia { get; set; }
        [Column(TypeName = "int(1)")]
        public int? hernia { get; set; }
        [Column(TypeName = "int(1)")]
        public int? asmaB { get; set; }
        [Column(TypeName = "int(1)")]
        public int? fractura { get; set; }
        [Column(TypeName = "int(1)")]
        public int? epilepsia { get; set; }
        [Column(TypeName = "int(1)")]
        public int? recuperacionQuimio { get; set; }
        [Column(TypeName = "int(1)")]
        public int? alteracionesNerviosas { get; set; }
        [Column(TypeName = "text")]
        public string otrosAntecedentesP { get; set; }
        [Column(TypeName = "text")]
        public string antecedenteHereditario { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? TA { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? FC { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? FR { get; set; }
        [Column(TypeName = "int(1)")]
        public int? otalgias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? dificultadRespirar { get; set; }
        [Column(TypeName = "int(1)")]
        public int? hipoacustico { get; set; }
        [Column(TypeName = "int(1)")]
        public int? sibilancias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? nasofaringe { get; set; }
        [Column(TypeName = "int(1)")]
        public int? tosCronica { get; set; }
        [Column(TypeName = "int(1)")]
        public int? lumbalgias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? artralgias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? hombroDoloroso { get; set; }
        [Column(TypeName = "int(1)")]
        public int? esguinceCronico { get; set; }
        [Column(TypeName = "tinytext")]
        public string OD { get; set; }
        [Column(TypeName = "tinytext")]
        public string OI { get; set; }
        [Column(TypeName = "int(1)")]
        public int? usaLentes { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? peso { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public sbyte? estatura { get; set; }
        public DateOnly? fur { get; set; }
        public DateOnly? fup { get; set; }
        [Column(TypeName = "int(1)")]
        public int? papanicolaou { get; set; }
        [Column(TypeName = "int(1)")]
        public int? dismenorrea { get; set; }
        [Column(TypeName = "int(1)")]
        public int? metodoAnticonceptivo { get; set; }
        [Column(TypeName = "int(1)")]
        public int? antidoping { get; set; }
        [Column(TypeName = "int(1)")]
        public int? embarazo { get; set; }
        [Column(TypeName = "text")]
        public string observacionesGineco { get; set; }
        [Column(TypeName = "int(1)")]
        public int? tabaquismo { get; set; }
        [Column(TypeName = "int(1)")]
        public int? alcoholismo { get; set; }
        [Column(TypeName = "int(1)")]
        public int? adicciones { get; set; }
        [Column(TypeName = "text")]
        public string observacionesAdiccion { get; set; }
        [Column(TypeName = "int(1)")]
        public int? aptoExposicionRuido { get; set; }
        [Column(TypeName = "int(1)")]
        public int? aptoExposicionQuimicos { get; set; }
        [Column(TypeName = "int(1)")]
        public int? aptoManipulacionCarga { get; set; }
        [Column(TypeName = "int(1)")]
        public int? aptoTrabajosAltura { get; set; }
        [Column(TypeName = "int(1)")]
        public int? apto { get; set; }
        [Column(TypeName = "text")]
        public string agenteExpuesto { get; set; }
        [Column(TypeName = "text")]
        public string factorPatologico { get; set; }
        [Column(TypeName = "int(1)")]
        public int? agudezaVisual { get; set; }
        [Column(TypeName = "int(1)")]
        public int? sanoApto { get; set; }
        [Column(TypeName = "int(1)")]
        public int? restricciones { get; set; }
        [Column(TypeName = "int(1)")]
        public int? habilidades { get; set; }
        [Column(TypeName = "int(1)")]
        public int? nuevasTecnologias { get; set; }
        [Column(TypeName = "int(1)")]
        public int? ocuparVacante { get; set; }
        [Column(TypeName = "int(1)")]
        public int? prevenirRiesgo { get; set; }
        [Column(TypeName = "int(1)")]
        public int? porAccidente { get; set; }
        [Column(TypeName = "text")]
        public string queSucedio { get; set; }
        [Column(TypeName = "text")]
        public string areaActual { get; set; }
        [Column(TypeName = "int(1)")]
        public int? alergiasActual { get; set; }
        [Column(TypeName = "int(1)")]
        public int? cardiopat { get; set; }
        [Column(TypeName = "int(1)")]
        public int? pruebaDiabetes { get; set; }
        public DateOnly? fechaInicioIncapacidad { get; set; }
        public DateOnly? fechaTerminoIncapacidad { get; set; }
        [Column(TypeName = "tinytext")]
        public string causa { get; set; }
        [Column(TypeName = "text")]
        public string causaText { get; set; }
        [Column(TypeName = "text")]
        public string descripcionLesion { get; set; }
        [Column(TypeName = "tinytext")]
        public string gradoLesion { get; set; }
        [Column(TypeName = "tinytext")]
        public string incapacidad { get; set; }
        [Column(TypeName = "int(11)")]
        public int? temperatura { get; set; }
        [Column(TypeName = "int(1)")]
        public int? vistaOido { get; set; }
        [Column(TypeName = "tinytext")]
        public string seEncuentra { get; set; }
        [Column(TypeName = "text")]
        public string indicaciones { get; set; }

        //[ForeignKey("id_empleado")]
        //[InverseProperty("examenmedicos")]
        //public virtual empleado id_empleadoNavigation { get; set; }
        //[ForeignKey("id_examenMedicoT")]
        //[InverseProperty("examenmedicos")]
        //public virtual examenmedicot id_examenMedicoTNavigation { get; set; }
    }
}
