using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class VEmpleado
    {
        public int IdEmpleado { get; set; }
        public int NoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Imss { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencias { get; set; }
        public string Email { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public long? IdCiudad { get; set; }
        public long? IdEstado { get; set; }
        public string Direccion { get; set; }
        public int? Cp { get; set; }
        public string GradoDeEstudios { get; set; }
        public string Carrera { get; set; }
        public string Instituto { get; set; }
        public int? Titulo { get; set; }
        public string IdEmpleadoTipo { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public string Turno { get; set; }
        public string JefeInmediato { get; set; }
        public DateOnly AltaImss { get; set; }
        public DateOnly FechaDeIngreso { get; set; }
        public string Sangre { get; set; }
        public double? SdSalario { get; set; }
        public string Nomina { get; set; }
        public string Empresa { get; set; }
        public int Status { get; set; }
        public int? NoHuella { get; set; }
        public string Imagen { get; set; }
        public string ClaveElectoral { get; set; }
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
