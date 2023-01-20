using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_SIF.Models.Empleados
{
    public partial class Empleado
    {

        [Key]
        public int Id { get; set; }
        public int NoEmpleado { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDeEmpleado { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public string Turno { get; set; }
        public string JefeInmediato { get; set; }
        public string NoImss { get; set; }
        public DateOnly AltaImss { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public DateOnly FechaDeIngreso { get; set; }
        public string Sexo { get; set; }
        public string EdoCivil { get; set; }
        public string Sangre { get; set; }
        public string CalleYNumero { get; set; }
        public string Colonia { get; set; }
        public int? Cp { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencias { get; set; }
        public double? SdSalario { get; set; }
        public string Nomina { get; set; }
        public string Empresa { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Status { get; set; }
        public int? NoHuella { get; set; }
        public string Imagen { get; set; }
        public string ClaveElectoral { get; set; }
        public string Email { get; set; }
        public string GradoDeEstudios { get; set; }
        public string Carrera { get; set; }
        public string Instituto { get; set; }
        public int? Titulo { get; set; }
        public string NoCedula { get; set; }
        public string Firma { get; set; }
        public string NombreContacto { get; set; }
        public string Parentesco { get; set; }
        public string Tipoempleado { get; set; }
        public bool? Presencial { get; set; }
        public bool? Renovacion { get; set; }
        public int? TurnoId { get; set; }
        public int? Supervisor { get; set; }
        public bool? RegistraPermiso { get; set; }
        public DateOnly? FechaBaja { get; set; }
        public bool? User { get; set; }
        public string Password { get; set; }
        public int? Areaid { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? TipoBaja { get; set; }
        public string MotivoBaja { get; set; }
        public DateOnly? FechaUltimaNomina { get; set; }
    }
}
