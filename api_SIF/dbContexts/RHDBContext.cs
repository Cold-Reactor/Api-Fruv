using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.Empleados;

namespace api_SIF.dbContexts
{
    public partial class RHDBContext : DbContext
    {
        public RHDBContext()
        {
        }

        public RHDBContext(DbContextOptions<RHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AltaBaja> AltaBajas { get; set; }
        public virtual DbSet<Amonestacion> Amonestacions { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Checada> Checadas { get; set; }
        public virtual DbSet<Checadas2> Checadas2s { get; set; }
        public virtual DbSet<Checadore> Checadores { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Dia> Dias { get; set; }
        public virtual DbSet<Diasferiado> Diasferiados { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Empleadoarchivo> Empleadoarchivos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Encuestaempleado> Encuestaempleados { get; set; }
        public virtual DbSet<Encuestum> Encuesta { get; set; }
        public virtual DbSet<Enfermerium> Enfermeria { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estadopermiso> Estadopermisos { get; set; }
        public virtual DbSet<Estadotiempoextra> Estadotiempoextras { get; set; }
        public virtual DbSet<Falta> Faltas { get; set; }
        public virtual DbSet<Faltaxrh> Faltaxrhs { get; set; }
        public virtual DbSet<Incapacidad> Incapacidads { get; set; }
        public virtual DbSet<IncapacidadDia> IncapacidadDias { get; set; }
        public virtual DbSet<IncapacidadMotivo> IncapacidadMotivos { get; set; }
        public virtual DbSet<Modalidadpermiso> Modalidadpermisos { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Opcione> Opciones { get; set; }
        public virtual DbSet<Opcionespreguntum> Opcionespregunta { get; set; }
        public virtual DbSet<Parentesco> Parentescos { get; set; }
        public virtual DbSet<Pariente> Parientes { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Personaltiempoextra> Personaltiempoextras { get; set; }
        public virtual DbSet<Preguntum> Pregunta { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<Renovacion> Renovacions { get; set; }
        public virtual DbSet<Respuestum> Respuesta { get; set; }
        public virtual DbSet<RolEmpleado> RolEmpleados { get; set; }
        public virtual DbSet<SecurityUggroup> SecurityUggroups { get; set; }
        public virtual DbSet<SecurityUgmember> SecurityUgmembers { get; set; }
        public virtual DbSet<SecurityUgright> SecurityUgrights { get; set; }
        public virtual DbSet<Solicitudtiempoextra> Solicitudtiempoextras { get; set; }
        public virtual DbSet<StatusEmpleado> StatusEmpleados { get; set; }
        public virtual DbSet<Suspension> Suspensions { get; set; }
        public virtual DbSet<SuspensionDia> SuspensionDias { get; set; }
        public virtual DbSet<Tabuladorvacacione> Tabuladorvacaciones { get; set; }
        public virtual DbSet<TipoBaja> TipoBajas { get; set; }
        public virtual DbSet<Tipoarchivo> Tipoarchivos { get; set; }
        public virtual DbSet<Tipoempleado> Tipoempleados { get; set; }
        public virtual DbSet<Tipopreguntum> Tipopregunta { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Turnodetalle> Turnodetalles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VArea> VAreas { get; set; }
        public virtual DbSet<VDepartamento> VDepartamentos { get; set; }
        public virtual DbSet<VEmpleado> VEmpleados { get; set; }
        public virtual DbSet<VEstadocivil> VEstadocivils { get; set; }
        public virtual DbSet<VSexo> VSexos { get; set; }
        public virtual DbSet<Vacacion> Vacacions { get; set; }
        public virtual DbSet<VacacionDia> VacacionDias { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=sistema.fruvemex.com;port=3306;database=empleados;user=jaziel;password=902015jz", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_spanish2_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<AltaBaja>(entity =>
            {
                entity.ToTable("alta_baja");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Alta)
                    .HasColumnType("int(11)")
                    .HasColumnName("alta")
                    .HasDefaultValueSql("'1646735655'");

                entity.Property(e => e.Baja)
                    .HasColumnType("int(11)")
                    .HasColumnName("baja")
                    .HasDefaultValueSql("'1646735399'");

                entity.Property(e => e.NoEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Razon)
                    .HasColumnType("text")
                    .HasColumnName("razon");
            });

            modelBuilder.Entity<Amonestacion>(entity =>
            {
                entity.ToTable("amonestacion");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Causa)
                    .HasColumnType("text")
                    .HasColumnName("causa");

                entity.Property(e => e.Comentario)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Departamento)
                    .HasColumnType("int(11)")
                    .HasColumnName("departamento")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Empleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("empleado");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Firmaamonestado)
                    .HasColumnType("text")
                    .HasColumnName("firmaamonestado");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.Registro)
                    .HasColumnType("int(11)")
                    .HasColumnName("registro");

                entity.Property(e => e.Supervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Area1)
                    .HasColumnType("tinytext")
                    .HasColumnName("area");
            });

            modelBuilder.Entity<Checada>(entity =>
            {
                entity.ToTable("checadas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ent)
                    .HasColumnType("text")
                    .HasColumnName("ent")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Fecha)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("text")
                    .HasColumnName("nombre")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Notrab)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("notrab");

                entity.Property(e => e.Sal)
                    .HasColumnType("text")
                    .HasColumnName("sal")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Checadas2>(entity =>
            {
                entity.ToTable("checadas2");

                entity.HasIndex(e => e.Numeroempleado, "empleado_idx");

                entity.HasIndex(e => e.RazonManual, "razonmanual");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Fechasubida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechasubida")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.Noempleado)
                    .HasMaxLength(45)
                    .HasColumnName("noempleado")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Numeroempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("numeroempleado");

                entity.Property(e => e.RazonManual)
                    .HasMaxLength(150)
                    .HasColumnName("razonManual")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Retardo)
                    .HasColumnType("int(11)")
                    .HasColumnName("retardo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("sucursal");
            });

            modelBuilder.Entity<Checadore>(entity =>
            {
                entity.ToTable("checadores");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(45)
                    .HasColumnName("serialNumber");

                entity.Property(e => e.Sucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("sucursal");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudad");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ciudad1)
                    .HasColumnType("tinytext")
                    .HasColumnName("Ciudad");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamentos");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Departamentos)
                    .HasColumnType("tinytext")
                    .HasColumnName("departamentos");
            });

            modelBuilder.Entity<Dia>(entity =>
            {
                entity.ToTable("dias");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Dia1)
                    .HasMaxLength(45)
                    .HasColumnName("dia");

                entity.Property(e => e.Inicial)
                    .HasMaxLength(45)
                    .HasColumnName("inicial");
            });

            modelBuilder.Entity<Diasferiado>(entity =>
            {
                entity.ToTable("diasferiados");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FechaOriginal).HasColumnName("fechaOriginal");

                entity.Property(e => e.Fechafinal).HasColumnName("fechafinal");

                entity.Property(e => e.Motivo)
                    .HasColumnType("text")
                    .HasColumnName("motivo");

                entity.Property(e => e.Texto)
                    .HasMaxLength(45)
                    .HasColumnName("texto")
                    .HasDefaultValueSql("'Festivo'");

                entity.Property(e => e.Turno)
                    .HasColumnName("turno")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.NoEmpleado })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("empleados");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(50)")
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.AltaImss).HasColumnName("Alta IMSS");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("Apellido materno");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("Apellido_paterno");

                entity.Property(e => e.Areaid)
                    .HasColumnType("int(11)")
                    .HasColumnName("areaid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CalleYNumero)
                    .HasColumnType("tinytext")
                    .HasColumnName("Calle_y_Numero");

                entity.Property(e => e.Carrera).HasColumnType("tinytext");

                entity.Property(e => e.Ciudad).HasColumnType("tinytext");

                entity.Property(e => e.ClaveElectoral)
                    .HasColumnType("tinytext")
                    .HasColumnName("Clave_electoral");

                entity.Property(e => e.Colonia).HasColumnType("tinytext");

                entity.Property(e => e.Cp)
                    .HasColumnType("int(11)")
                    .HasColumnName("CP");

                entity.Property(e => e.Curp)
                    .HasColumnType("tinytext")
                    .HasColumnName("CURP");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.EdoCivil)
                    .HasColumnType("tinytext")
                    .HasColumnName("Edo_civil");

                entity.Property(e => e.Email)
                    .HasColumnType("tinytext")
                    .HasColumnName("email");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.Estado).HasColumnType("tinytext");

                entity.Property(e => e.FechaBaja).HasColumnName("fecha_baja");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaDeIngreso).HasColumnName("Fecha_de_Ingreso");

                entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.FechaUltimaNomina).HasColumnName("fechaUltimaNomina");

                entity.Property(e => e.Firma)
                    .HasColumnType("text")
                    .HasColumnName("firma");

                entity.Property(e => e.GradoDeEstudios)
                    .HasColumnType("tinytext")
                    .HasColumnName("grado_de_estudios");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(300)
                    .HasColumnName("imagen");

                entity.Property(e => e.Instituto).HasColumnType("tinytext");

                entity.Property(e => e.JefeInmediato)
                    .HasColumnType("tinytext")
                    .HasColumnName("Jefe Inmediato");

                entity.Property(e => e.MotivoBaja)
                    .HasMaxLength(45)
                    .HasColumnName("motivoBaja");

                entity.Property(e => e.NoCedula).HasColumnType("tinytext");

                entity.Property(e => e.NoHuella)
                    .HasColumnType("int(11)")
                    .HasColumnName("noHuella");

                entity.Property(e => e.NoImss)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("No IMSS");

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(100)
                    .HasColumnName("nombreContacto");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.Nomina).HasColumnType("tinytext");

                entity.Property(e => e.Parentesco)
                    .HasMaxLength(45)
                    .HasColumnName("parentesco");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Presencial)
                    .HasColumnName("presencial")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.RegistraPermiso).HasDefaultValueSql("'0'");

                entity.Property(e => e.Renovacion)
                    .HasColumnName("renovacion")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rfc)
                    .HasColumnType("tinytext")
                    .HasColumnName("RFC");

                entity.Property(e => e.Sangre)
                    .HasColumnType("tinytext")
                    .HasColumnName("sangre");

                entity.Property(e => e.SdSalario).HasColumnName("SD_salario");

                entity.Property(e => e.Sexo).HasColumnType("tinytext");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Supervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Telefono).HasColumnType("tinytext");

                entity.Property(e => e.TelefonoEmergencias)
                    .HasColumnType("tinytext")
                    .HasColumnName("Telefono_emergencias");

                entity.Property(e => e.TipoBaja)
                    .HasColumnType("int(1)")
                    .HasColumnName("tipoBaja")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoDeEmpleado)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("Tipo _de_empleado");

                entity.Property(e => e.Tipoempleado)
                    .HasColumnType("tinytext")
                    .HasColumnName("tipoempleado");

                entity.Property(e => e.Titulo).HasColumnType("int(11)");

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.TurnoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turnoId")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Empleadoarchivo>(entity =>
            {
                entity.ToTable("empleadoarchivo");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");

                entity.Property(e => e.Ruta)
                    .HasColumnType("text")
                    .HasColumnName("ruta");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresas");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Empresas)
                    .HasColumnType("tinytext")
                    .HasColumnName("empresas");
            });

            modelBuilder.Entity<Encuestaempleado>(entity =>
            {
                entity.ToTable("encuestaempleado");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("int(11)")
                    .HasColumnName("area");

                entity.Property(e => e.Encuesta)
                    .HasColumnType("int(11)")
                    .HasColumnName("encuesta");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.HoraFinal)
                    .HasColumnType("time")
                    .HasColumnName("horaFinal");

                entity.Property(e => e.HoraInicio)
                    .HasColumnType("time")
                    .HasColumnName("horaInicio");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");
            });

            modelBuilder.Entity<Encuestum>(entity =>
            {
                entity.ToTable("encuesta");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Creador)
                    .HasColumnType("int(11)")
                    .HasColumnName("creador");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Enfermerium>(entity =>
            {
                entity.ToTable("enfermeria");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Apellidom)
                    .HasColumnType("tinytext")
                    .HasColumnName("apellidom");

                entity.Property(e => e.Apellidop)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("apellidop");

                entity.Property(e => e.Atencion)
                    .HasColumnType("time")
                    .HasColumnName("atencion");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("departamento");

                entity.Property(e => e.Diagnostico)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Incidencia)
                    .HasColumnType("tinytext")
                    .HasColumnName("incidencia");

                entity.Property(e => e.JefeInmediato)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("jefe inmediato");

                entity.Property(e => e.NoEmpleado)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.Tratamiento)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("turno");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Estado1)
                    .HasColumnType("tinytext")
                    .HasColumnName("Estado");
            });

            modelBuilder.Entity<Estadopermiso>(entity =>
            {
                entity.ToTable("estadopermiso");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estadotiempoextra>(entity =>
            {
                entity.ToTable("estadotiempoextra");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .HasColumnName("color");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Falta>(entity =>
            {
                entity.ToTable("faltas");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Falta1).HasColumnName("falta");

                entity.Property(e => e.Justificada)
                    .HasColumnType("int(11)")
                    .HasColumnName("justificada");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("No.Empleado");

                entity.Property(e => e.Permiso).HasColumnType("int(11)");

                entity.Property(e => e.Suspencion).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Faltaxrh>(entity =>
            {
                entity.ToTable("faltaxrh");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");

                entity.Property(e => e.NoempleadoRegistro)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleadoRegistro");
            });

            modelBuilder.Entity<Incapacidad>(entity =>
            {
                entity.ToTable("incapacidad");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cancelado)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("cancelado")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Comentarios)
                    .HasColumnType("text")
                    .HasColumnName("comentarios");

                entity.Property(e => e.Dias)
                    .HasColumnType("int(11)")
                    .HasColumnName("dias");

                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaDesde).HasColumnName("fecha_desde");

                entity.Property(e => e.FechaHasta).HasColumnName("fecha_hasta");

                entity.Property(e => e.Motivo)
                    .HasColumnType("int(11)")
                    .HasColumnName("motivo");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");

                entity.Property(e => e.Permanente)
                    .HasColumnType("int(11)")
                    .HasColumnName("permanente")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<IncapacidadDia>(entity =>
            {
                entity.ToTable("incapacidad_dias");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdIncapacidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_incapacidad");
            });

            modelBuilder.Entity<IncapacidadMotivo>(entity =>
            {
                entity.ToTable("incapacidad_motivo");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Modalidadpermiso>(entity =>
            {
                entity.ToTable("modalidadpermiso");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.ToTable("nomina");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nomina1)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("Nomina");
            });

            modelBuilder.Entity<Opcione>(entity =>
            {
                entity.ToTable("opciones");

                entity.UseCollation("utf8_spanish_ci");

                entity.HasIndex(e => e.Descripcion, "descripcion_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(65)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(45)
                    .HasColumnName("imagen");
            });

            modelBuilder.Entity<Opcionespreguntum>(entity =>
            {
                entity.ToTable("opcionespregunta");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Opcion)
                    .HasColumnType("int(11)")
                    .HasColumnName("opcion");

                entity.Property(e => e.Pregunta)
                    .HasColumnType("int(11)")
                    .HasColumnName("pregunta");
            });

            modelBuilder.Entity<Parentesco>(entity =>
            {
                entity.HasKey(e => e.NoEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("parentesco");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Parentesco1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("parentesco");
            });

            modelBuilder.Entity<Pariente>(entity =>
            {
                entity.ToTable("parientes");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("apellido_materno");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("apellido_paterno");

                entity.Property(e => e.Area)
                    .HasColumnType("tinytext")
                    .HasColumnName("area");

                entity.Property(e => e.NoEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.Parentesco).HasColumnType("tinytext");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.RelacionNoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("relacion_no_empleado");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("permiso");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Autorizo)
                    .HasColumnType("int(11)")
                    .HasColumnName("autorizo");

                entity.Property(e => e.Dias)
                    .HasColumnType("int(11)")
                    .HasColumnName("dias");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaSolicitadaDesde).HasColumnName("fechaSolicitadaDesde");

                entity.Property(e => e.FechaSolicitadaHasta).HasColumnName("fechaSolicitadaHasta");

                entity.Property(e => e.HoraCreacion)
                    .HasColumnType("time")
                    .HasColumnName("horaCreacion");

                entity.Property(e => e.HoraSolicitadaDesde)
                    .HasColumnType("time")
                    .HasColumnName("horaSolicitadaDesde");

                entity.Property(e => e.HoraSolicitadaHasta)
                    .HasColumnType("time")
                    .HasColumnName("horaSolicitadaHasta");

                entity.Property(e => e.Horadesde)
                    .HasColumnType("time")
                    .HasColumnName("horadesde");

                entity.Property(e => e.Horahasta)
                    .HasColumnType("time")
                    .HasColumnName("horahasta");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.Modalidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("modalidad");

                entity.Property(e => e.Motivo)
                    .HasColumnType("text")
                    .HasColumnName("motivo");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");

                entity.Property(e => e.Pagado)
                    .HasColumnType("int(11)")
                    .HasColumnName("pagado")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Supervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor");
            });

            modelBuilder.Entity<Personaltiempoextra>(entity =>
            {
                entity.ToTable("personaltiempoextra");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actividad)
                    .HasColumnType("text")
                    .HasColumnName("actividad");

                entity.Property(e => e.Autorizado)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("autorizado");

                entity.Property(e => e.Desde)
                    .HasColumnType("time")
                    .HasColumnName("desde");

                entity.Property(e => e.Hasta)
                    .HasColumnType("time")
                    .HasColumnName("hasta");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.IdSolicitud)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSolicitud");

                entity.Property(e => e.Idactividad)
                    .HasColumnType("int(11)")
                    .HasColumnName("idactividad")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.Pago)
                    .HasColumnName("pago")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TiempoTrabajado).HasColumnName("tiempoTrabajado");
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.ToTable("pregunta");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Adicional)
                    .HasMaxLength(45)
                    .HasColumnName("adicional");

                entity.Property(e => e.DescripcionPregunta)
                    .HasColumnType("text")
                    .HasColumnName("descripcionPregunta");

                entity.Property(e => e.Idencuesta)
                    .HasColumnType("int(11)")
                    .HasColumnName("idencuesta");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.ToTable("puestos");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Puesto1)
                    .HasColumnType("tinytext")
                    .HasColumnName("Puesto");
            });

            modelBuilder.Entity<Renovacion>(entity =>
            {
                entity.ToTable("renovacion");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Noempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noempleado");
            });

            modelBuilder.Entity<Respuestum>(entity =>
            {
                entity.ToTable("respuesta");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EncuestaEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("encuestaEmpleado");

                entity.Property(e => e.Pregunta)
                    .HasColumnType("int(11)")
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .HasColumnType("int(11)")
                    .HasColumnName("respuesta");

                entity.Property(e => e.RespuestaDirecta)
                    .HasColumnType("int(11)")
                    .HasColumnName("respuestaDirecta")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Texto)
                    .HasColumnType("text")
                    .HasColumnName("texto")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RolEmpleado>(entity =>
            {
                entity.ToTable("rol_empleado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<SecurityUggroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PRIMARY");

                entity.ToTable("security_uggroups");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GroupID");

                entity.Property(e => e.Label).HasMaxLength(300);
            });

            modelBuilder.Entity<SecurityUgmember>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.GroupId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 50, 0 });

                entity.ToTable("security_ugmembers");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.UserName).HasMaxLength(300);

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GroupID");
            });

            modelBuilder.Entity<SecurityUgright>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.GroupId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 50, 0 });

                entity.ToTable("security_ugrights");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.TableName).HasMaxLength(300);

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GroupID");

                entity.Property(e => e.AccessMask).HasMaxLength(10);
            });

            modelBuilder.Entity<Solicitudtiempoextra>(entity =>
            {
                entity.ToTable("solicitudtiempoextra");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("int(11)")
                    .HasColumnName("area");

                entity.Property(e => e.Autorizo)
                    .HasColumnType("int(11)")
                    .HasColumnName("autorizo");

                entity.Property(e => e.AutorizoGerenteRh)
                    .HasColumnType("int(11)")
                    .HasColumnName("autorizoGerenteRH");

                entity.Property(e => e.Departamento)
                    .HasColumnType("int(11)")
                    .HasColumnName("departamento");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaSolicitada).HasColumnName("fechaSolicitada");

                entity.Property(e => e.FechaSolicitud).HasColumnName("fechaSolicitud");

                entity.Property(e => e.Folio)
                    .HasColumnType("int(11)")
                    .HasColumnName("folio");

                entity.Property(e => e.HoraSolicitud)
                    .HasColumnType("time")
                    .HasColumnName("horaSolicitud");

                entity.Property(e => e.Justificacion)
                    .HasColumnType("text")
                    .HasColumnName("justificacion");

                entity.Property(e => e.Solicitante)
                    .HasColumnType("int(11)")
                    .HasColumnName("solicitante");

                entity.Property(e => e.Sucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("sucursal");
            });

            modelBuilder.Entity<StatusEmpleado>(entity =>
            {
                entity.ToTable("status_empleado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Suspension>(entity =>
            {
                entity.ToTable("suspension");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Causa)
                    .HasColumnType("text")
                    .HasColumnName("causa");

                entity.Property(e => e.Departamento)
                    .HasColumnType("int(11)")
                    .HasColumnName("departamento")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Dias)
                    .HasColumnType("int(11)")
                    .HasColumnName("dias")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Empleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("empleado");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.FirmaRecursosHumanos)
                    .HasColumnType("text")
                    .HasColumnName("firmaRecursosHumanos");

                entity.Property(e => e.FirmaSupervisor)
                    .HasColumnType("text")
                    .HasColumnName("firmaSupervisor");

                entity.Property(e => e.Firmaamonestado)
                    .HasColumnType("text")
                    .HasColumnName("firmaamonestado");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.Registro)
                    .HasColumnType("int(11)")
                    .HasColumnName("registro");

                entity.Property(e => e.Supervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor");
            });

            modelBuilder.Entity<SuspensionDia>(entity =>
            {
                entity.ToTable("suspension_dias");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdSuspension)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_suspension")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Tabuladorvacacione>(entity =>
            {
                entity.ToTable("tabuladorvacaciones");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DiasCorrespondientes)
                    .HasColumnType("int(11)")
                    .HasColumnName("diasCorrespondientes");

                entity.Property(e => e.RangoA)
                    .HasColumnType("int(11)")
                    .HasColumnName("rangoA");

                entity.Property(e => e.RangoB)
                    .HasColumnType("int(11)")
                    .HasColumnName("rangoB");
            });

            modelBuilder.Entity<TipoBaja>(entity =>
            {
                entity.ToTable("tipo_baja");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Iniciales)
                    .HasMaxLength(45)
                    .HasColumnName("iniciales");
            });

            modelBuilder.Entity<Tipoarchivo>(entity =>
            {
                entity.ToTable("tipoarchivos");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tipoempleado>(entity =>
            {
                entity.ToTable("tipoempleado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Tipopreguntum>(entity =>
            {
                entity.ToTable("tipopregunta");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("turno");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Disponible)
                    .HasColumnName("disponible")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Turno1)
                    .HasColumnType("tinytext")
                    .HasColumnName("Turno");
            });

            modelBuilder.Entity<Turnodetalle>(entity =>
            {
                entity.ToTable("turnodetalle");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Dia)
                    .HasColumnType("int(11)")
                    .HasColumnName("dia");

                entity.Property(e => e.HrEntrada)
                    .HasColumnType("time")
                    .HasColumnName("hrEntrada");

                entity.Property(e => e.HrSalida)
                    .HasColumnType("time")
                    .HasColumnName("hrSalida");

                entity.Property(e => e.Turno)
                    .HasColumnType("int(11)")
                    .HasColumnName("turno");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Grupo).HasColumnType("tinytext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.Password)
                    .HasColumnType("int(11)")
                    .HasColumnName("password");
            });

            modelBuilder.Entity<VArea>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_area");

                entity.Property(e => e.Area)
                    .HasColumnType("tinytext")
                    .HasColumnName("area")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.IdArea)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_area");
            });

            modelBuilder.Entity<VDepartamento>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_departamento");

                entity.Property(e => e.Departamento)
                    .HasColumnType("tinytext")
                    .HasColumnName("departamento")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.IdDepartamento)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_departamento");
            });

            modelBuilder.Entity<VEmpleado>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_empleado");

                entity.Property(e => e.AltaImss).HasColumnName("Alta IMSS");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("apellido_materno")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("apellido_paterno")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Areaid)
                    .HasColumnType("int(11)")
                    .HasColumnName("areaid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Carrera)
                    .HasColumnType("tinytext")
                    .HasColumnName("carrera")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.ClaveElectoral)
                    .HasColumnType("tinytext")
                    .HasColumnName("Clave_electoral")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Cp)
                    .HasColumnType("int(11)")
                    .HasColumnName("CP");

                entity.Property(e => e.Curp)
                    .HasColumnType("tinytext")
                    .HasColumnName("CURP")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(511)
                    .HasColumnName("direccion")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Email)
                    .HasColumnType("tinytext")
                    .HasColumnName("email")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.EstadoCivil)
                    .HasColumnType("tinytext")
                    .HasColumnName("estado_civil")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.FechaBaja).HasColumnName("fecha_baja");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDeIngreso).HasColumnName("Fecha_de_Ingreso");

                entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");

                entity.Property(e => e.FechaUltimaNomina).HasColumnName("fechaUltimaNomina");

                entity.Property(e => e.Firma)
                    .HasColumnType("text")
                    .HasColumnName("firma")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.GradoDeEstudios)
                    .HasColumnType("tinytext")
                    .HasColumnName("grado_de_estudios")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.IdCiudad)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("id_ciudad");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_empleado");

                entity.Property(e => e.IdEmpleadoTipo)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("id_empleado_tipo")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.IdEstado)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("id_estado");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(300)
                    .HasColumnName("imagen")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Imss)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("IMSS")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Instituto)
                    .HasColumnType("tinytext")
                    .HasColumnName("instituto")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.JefeInmediato)
                    .HasColumnType("tinytext")
                    .HasColumnName("Jefe Inmediato")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.MotivoBaja)
                    .HasMaxLength(45)
                    .HasColumnName("motivoBaja")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.NoCedula)
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(50)")
                    .HasColumnName("no_Empleado");

                entity.Property(e => e.NoHuella)
                    .HasColumnType("int(11)")
                    .HasColumnName("noHuella");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("nombre")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(100)
                    .HasColumnName("nombreContacto")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nomina)
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Parentesco)
                    .HasMaxLength(45)
                    .HasColumnName("parentesco")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Presencial)
                    .HasColumnName("presencial")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.RegistraPermiso).HasDefaultValueSql("'0'");

                entity.Property(e => e.Renovacion)
                    .HasColumnName("renovacion")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rfc)
                    .HasColumnType("tinytext")
                    .HasColumnName("RFC")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Sangre)
                    .HasColumnType("tinytext")
                    .HasColumnName("sangre")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.SdSalario).HasColumnName("SD_salario");

                entity.Property(e => e.Sexo)
                    .HasColumnType("tinytext")
                    .HasColumnName("sexo")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Supervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Telefono)
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.TelefonoEmergencias)
                    .HasColumnType("tinytext")
                    .HasColumnName("Telefono_emergencias")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.TipoBaja)
                    .HasColumnType("int(1)")
                    .HasColumnName("tipoBaja")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Tipoempleado)
                    .HasColumnType("tinytext")
                    .HasColumnName("tipoempleado")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Titulo)
                    .HasColumnType("int(11)")
                    .HasColumnName("titulo");

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.TurnoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turnoId")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<VEstadocivil>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_estadocivil");

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.EstadoCivilId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("EstadoCivilID");

                entity.Property(e => e.Genero).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<VSexo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_sexo");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.SexoId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("SexoID");
            });

            modelBuilder.Entity<Vacacion>(entity =>
            {
                entity.ToTable("vacacion");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Diascorrespondientes)
                    .HasColumnType("int(11)")
                    .HasColumnName("diascorrespondientes")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaRegreso).HasColumnName("fechaRegreso");

                entity.Property(e => e.Gozado)
                    .HasColumnName("gozado")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IdSupervisor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSupervisor");

                entity.Property(e => e.NoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("noEmpleado");

                entity.Property(e => e.Pagado)
                    .HasColumnName("pagado")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Periodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TotalDias)
                    .HasMaxLength(45)
                    .HasColumnName("totalDias");

                entity.Property(e => e.UserRegistroId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userRegistroId");
            });

            modelBuilder.Entity<VacacionDia>(entity =>
            {
                entity.ToTable("vacacion_dias");

                entity.UseCollation("utf8_spanish_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdVacacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vacacion");
            });

            modelBuilder.Entity<Vacacione>(entity =>
            {
                entity.ToTable("vacaciones");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Entra)
                    .HasColumnType("int(11)")
                    .HasColumnName("entra");

                entity.Property(e => e.NoEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Pagadas)
                    .HasColumnType("int(11)")
                    .HasColumnName("pagadas");

                entity.Property(e => e.Sale)
                    .HasColumnType("int(11)")
                    .HasColumnName("sale");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
