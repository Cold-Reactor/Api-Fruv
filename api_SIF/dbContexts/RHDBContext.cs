using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.EmpleadosN;

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

        public virtual DbSet<__efmigrationshistory> __efmigrationshistories { get; set; }
        public virtual DbSet<accidente> accidentes { get; set; }
        public virtual DbSet<accidente_diagnostico> accidente_diagnosticos { get; set; }
        public virtual DbSet<accidentediagnostico> accidentediagnosticos { get; set; }
        public virtual DbSet<amonestacion> amonestacions { get; set; }
        public virtual DbSet<analisistipo> analisistipos { get; set; }
        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<checada> checadas { get; set; }
        public virtual DbSet<checador> checadors { get; set; }
        public virtual DbSet<cincosbitacora> cincosbitacoras { get; set; }
        public virtual DbSet<cincosbitacora_cincostipo> cincosbitacora_cincostipos { get; set; }
        public virtual DbSet<cincostipo> cincostipos { get; set; }
        public virtual DbSet<ciudad> ciudads { get; set; }
        public virtual DbSet<consulta_medicamento> consulta_medicamentos { get; set; }
        public virtual DbSet<consultum> consulta { get; set; }
        public virtual DbSet<cotizacion> cotizacions { get; set; }
        public virtual DbSet<crud> cruds { get; set; }
        public virtual DbSet<departamento> departamentos { get; set; }
        public virtual DbSet<diagnostico> diagnosticos { get; set; }
        public virtual DbSet<diasferiado> diasferiados { get; set; }
        public virtual DbSet<empleado> empleados { get; set; }
        public virtual DbSet<empleado_tiempoextra> empleado_tiempoextras { get; set; }
        public virtual DbSet<empleadoarchivo> empleadoarchivos { get; set; }
        public virtual DbSet<empleadohistorial> empleadohistorials { get; set; }
        public virtual DbSet<empleadotipo> empleadotipos { get; set; }
        public virtual DbSet<empleadotipoarchivo> empleadotipoarchivos { get; set; }
        public virtual DbSet<empresa> empresas { get; set; }
        public virtual DbSet<estado> estados { get; set; }
        public virtual DbSet<examenmedico> examenmedicos { get; set; }
        public virtual DbSet<examenmedicot> examenmedicots { get; set; }
        public virtual DbSet<falta> faltas { get; set; }
        public virtual DbSet<formato> formatos { get; set; }
        public virtual DbSet<hipertension> hipertensions { get; set; }
        public virtual DbSet<historialanalisismedico> historialanalisismedicos { get; set; }
        public virtual DbSet<hora> horas { get; set; }
        public virtual DbSet<incapacidad> incapacidads { get; set; }
        public virtual DbSet<inmobiliario> inmobiliarios { get; set; }
        public virtual DbSet<iva> ivas { get; set; }
        public virtual DbSet<medicamento> medicamentos { get; set; }
        public virtual DbSet<medicamentotipo> medicamentotipos { get; set; }
        public virtual DbSet<nomina> nominas { get; set; }
        public virtual DbSet<ordencompra> ordencompras { get; set; }
        public virtual DbSet<pariente> parientes { get; set; }
        public virtual DbSet<partidum> partida { get; set; }
        public virtual DbSet<permiso> permisos { get; set; }
        public virtual DbSet<permisomodalidad> permisomodalidads { get; set; }
        public virtual DbSet<presupuesto> presupuestos { get; set; }
        public virtual DbSet<proveedor> proveedors { get; set; }
        public virtual DbSet<puesto> puestos { get; set; }
        public virtual DbSet<refaccion> refaccions { get; set; }
        public virtual DbSet<renovacion> renovacions { get; set; }
        public virtual DbSet<solicitudcompra> solicitudcompras { get; set; }
        public virtual DbSet<submodulo> submodulos { get; set; }
        public virtual DbSet<sucursale> sucursales { get; set; }
        public virtual DbSet<suspension> suspensions { get; set; }
        public virtual DbSet<tiempoextra> tiempoextras { get; set; }
        public virtual DbSet<tiempoextraestado> tiempoextraestados { get; set; }
        public virtual DbSet<tipobaja> tipobajas { get; set; }
        public virtual DbSet<trabajo_refaccion> trabajo_refaccions { get; set; }
        public virtual DbSet<trabajoexterno> trabajoexternos { get; set; }
        public virtual DbSet<trabajointerno> trabajointernos { get; set; }
        public virtual DbSet<trabajotipo> trabajotipos { get; set; }
        public virtual DbSet<turno> turnos { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<usuario_empleadorol> usuario_empleadorols { get; set; }
        public virtual DbSet<usuariorol> usuariorols { get; set; }
        public virtual DbSet<vacacione> vacaciones { get; set; }
        public virtual DbSet<vacacionesperiodo> vacacionesperiodos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=sistema.fruvemex.com;port=3306;database=empleadosN;user=jaziel;password=902015jz", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<__efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<accidente>(entity =>
            {
                entity.HasKey(e => e.id_accidentes)
                    .HasName("PRIMARY");

                entity.Property(e => e.cierre_ST2).HasDefaultValueSql("b'0'");

                entity.Property(e => e.inicia_ST7).HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.accidentes)
                    .HasForeignKey(d => d.id_area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_incapacidad_area1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.accidentes)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_incapacidad_empleados1");
            });

            modelBuilder.Entity<accidente_diagnostico>(entity =>
            {
                entity.HasOne(d => d.id_accidenteNavigation)
                    .WithMany(p => p.accidente_diagnosticos)
                    .HasForeignKey(d => d.id_accidente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_incapacidad_has_diagnostico_incapacidad1");

                entity.HasOne(d => d.id_diagnosticoNavigation)
                    .WithMany(p => p.accidente_diagnosticos)
                    .HasForeignKey(d => d.id_diagnostico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_incapacidad_has_diagnostico_diagnostico1");
            });

            modelBuilder.Entity<accidentediagnostico>(entity =>
            {
                entity.HasKey(e => new { e.id_accidente, e.id_diagnostico })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<amonestacion>(entity =>
            {
                entity.HasKey(e => e.id_amonestacion)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.amonestacions)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_amonestacion_empleado1");
            });

            modelBuilder.Entity<analisistipo>(entity =>
            {
                entity.HasKey(e => e.id_analisisT)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<area>(entity =>
            {
                entity.HasKey(e => e.id_area)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_departamentoNavigation)
                    .WithMany(p => p.areas)
                    .HasForeignKey(d => d.id_departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_area_departamento1");

                entity.HasMany(d => d.id_bitacoras)
                    .WithMany(p => p.id_areas)
                    .UsingEntity<Dictionary<string, object>>(
                        "area_cincosbitacora",
                        l => l.HasOne<cincosbitacora>().WithMany().HasForeignKey("id_bitacora").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_area_has_cincoSbitacora_cincoSbitacora1"),
                        r => r.HasOne<area>().WithMany().HasForeignKey("id_area").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_area_has_cincoSbitacora_area1"),
                        j =>
                        {
                            j.HasKey("id_area", "id_bitacora").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("area_cincosbitacora").UseCollation("utf8_spanish2_ci");

                            j.HasIndex(new[] { "id_area" }, "fk_area_has_cincoSbitacora_area1_idx");

                            j.HasIndex(new[] { "id_bitacora" }, "fk_area_has_cincoSbitacora_cincoSbitacora1_idx");

                            j.IndexerProperty<int>("id_area").HasColumnType("int(11)");

                            j.IndexerProperty<int>("id_bitacora").HasColumnType("int(11)");
                        });
            });

            modelBuilder.Entity<checada>(entity =>
            {
                entity.HasKey(e => e.id_checada)
                    .HasName("PRIMARY");

                entity.Property(e => e.fechaHoraSubida).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.id_checadorNavigation)
                    .WithMany(p => p.checada)
                    .HasForeignKey(d => d.id_checador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_checadas_checador1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.checada)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleado");
            });

            modelBuilder.Entity<checador>(entity =>
            {
                entity.HasKey(e => e.id_checador)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<cincosbitacora>(entity =>
            {
                entity.HasKey(e => e.id_bitacora)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<cincosbitacora_cincostipo>(entity =>
            {
                entity.HasKey(e => new { e.id_bitacora, e.id_cincoStipo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.valor).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.id_bitacoraNavigation)
                    .WithMany(p => p.cincosbitacora_cincostipos)
                    .HasForeignKey(d => d.id_bitacora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cincoSbitacora_has_cincoStipo_cincoSbitacora1");

                entity.HasOne(d => d.id_cincoStipoNavigation)
                    .WithMany(p => p.cincosbitacora_cincostipos)
                    .HasForeignKey(d => d.id_cincoStipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cincoSbitacora_has_cincoStipo_cincoStipo1");
            });

            modelBuilder.Entity<cincostipo>(entity =>
            {
                entity.HasKey(e => e.id_cincoStipo)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<ciudad>(entity =>
            {
                entity.HasKey(e => e.id_ciudad)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<consulta_medicamento>(entity =>
            {
                entity.HasKey(e => new { e.id_consulta, e.id_medicamento })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasOne(d => d.id_consultaNavigation)
                    .WithMany(p => p.consulta_medicamentos)
                    .HasForeignKey(d => d.id_consulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consulta_has_medicamentos_consulta1");

                entity.HasOne(d => d.id_medicamentoNavigation)
                    .WithMany(p => p.consulta_medicamentos)
                    .HasForeignKey(d => d.id_medicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consulta_has_medicamentos_medicamentos1");
            });

            modelBuilder.Entity<consultum>(entity =>
            {
                entity.HasKey(e => e.id_consulta)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.id_area)
                    .HasConstraintName("fk_consultorio_area1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.id_empleado)
                    .HasConstraintName("fk_consultorio_empleados1");

                entity.HasMany(d => d.id_diagnosticos)
                    .WithMany(p => p.id_consulta)
                    .UsingEntity<Dictionary<string, object>>(
                        "consultas_diagnostico",
                        l => l.HasOne<diagnostico>().WithMany().HasForeignKey("id_diagnostico").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_consultorio_has_diagnostico_diagnostico1"),
                        r => r.HasOne<consultum>().WithMany().HasForeignKey("id_consulta").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_consultorio_has_diagnostico_consultorio1"),
                        j =>
                        {
                            j.HasKey("id_consulta", "id_diagnostico").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("consultas_diagnosticos").UseCollation("utf8_spanish2_ci");

                            j.HasIndex(new[] { "id_consulta" }, "fk_consultorio_has_diagnostico_consultorio1_idx");

                            j.HasIndex(new[] { "id_diagnostico" }, "fk_consultorio_has_diagnostico_diagnostico1_idx");

                            j.IndexerProperty<int>("id_consulta").HasColumnType("int(11)");

                            j.IndexerProperty<int>("id_diagnostico").HasColumnType("int(11)");
                        });
            });

            modelBuilder.Entity<cotizacion>(entity =>
            {
                entity.HasKey(e => e.id_cotizacion)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_ivaNavigation)
                    .WithMany(p => p.cotizacions)
                    .HasForeignKey(d => d.id_iva)
                    .HasConstraintName("fk_cotizacion_iva1");

                entity.HasOne(d => d.id_proveedorNavigation)
                    .WithMany(p => p.cotizacions)
                    .HasForeignKey(d => d.id_proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cotizacion_proveedor1");

                entity.HasOne(d => d.id_solicitudCNavigation)
                    .WithMany(p => p.cotizacions)
                    .HasForeignKey(d => d.id_solicitudC)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cotizacion_solicitudCompra1");
            });

            modelBuilder.Entity<crud>(entity =>
            {
                entity.HasKey(e => e.id_crud)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<departamento>(entity =>
            {
                entity.HasKey(e => e.id_departamento)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<diagnostico>(entity =>
            {
                entity.HasKey(e => e.id_diagnostico)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<diasferiado>(entity =>
            {
                entity.HasKey(e => e.id_diasFeriados)
                    .HasName("PRIMARY");

                entity.Property(e => e.texto).HasDefaultValueSql("'Festivo'");
            });

            modelBuilder.Entity<empleado>(entity =>
            {
                entity.HasKey(e => e.id_empleado)
                    .HasName("PRIMARY");

                entity.Property(e => e.bonoProd).HasDefaultValueSql("'0'");

                entity.Property(e => e.externo).HasDefaultValueSql("'0'");

                entity.Property(e => e.presencial).HasDefaultValueSql("'1'");

                entity.Property(e => e.status).HasDefaultValueSql("'1'");

                entity.Property(e => e.titulo).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<empleado_tiempoextra>(entity =>
            {
                entity.HasKey(e => new { e.id_tiempoExtra, e.id_empleado })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<empleadoarchivo>(entity =>
            {
                entity.HasKey(e => e.id_empleadoArchivo)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoArchivoTNavigation)
                    .WithMany(p => p.empleadoarchivos)
                    .HasForeignKey(d => d.id_empleadoArchivoT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleadoArchivo_empleadoTipoArchivo1");
            });

            modelBuilder.Entity<empleadohistorial>(entity =>
            {
                entity.HasKey(e => e.id_empleadoHistorial)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.empleadohistorials)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleado_status_empleados1");

                entity.HasOne(d => d.id_tipoBajaNavigation)
                    .WithMany(p => p.empleadohistorials)
                    .HasForeignKey(d => d.id_tipoBaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleado_historial_tipo_baja1");
            });

            modelBuilder.Entity<empleadotipo>(entity =>
            {
                entity.HasKey(e => e.id_empleadoT)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<empleadotipoarchivo>(entity =>
            {
                entity.HasKey(e => e.id_empleadoArchivoT)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<empresa>(entity =>
            {
                entity.HasKey(e => e.id_empresa)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<estado>(entity =>
            {
                entity.HasKey(e => e.id_estado)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<examenmedico>(entity =>
            {
                entity.HasKey(e => e.id_examenMedico)
                    .HasName("PRIMARY");

                entity.Property(e => e.id_examenMedico).ValueGeneratedNever();

                entity.Property(e => e.accidentes).HasDefaultValueSql("'0'");

                entity.Property(e => e.adicciones).HasDefaultValueSql("'0'");

                entity.Property(e => e.agudezaVisual).HasDefaultValueSql("'0'");

                entity.Property(e => e.alcoholismo).HasDefaultValueSql("'0'");

                entity.Property(e => e.alergias).HasDefaultValueSql("'0'");

                entity.Property(e => e.alergiasActual).HasDefaultValueSql("'0'");

                entity.Property(e => e.alteracionesNerviosas).HasDefaultValueSql("'0'");

                entity.Property(e => e.antidoping).HasDefaultValueSql("'0'");

                entity.Property(e => e.apto).HasDefaultValueSql("'0'");

                entity.Property(e => e.aptoExposicionQuimicos).HasDefaultValueSql("'0'");

                entity.Property(e => e.aptoExposicionRuido).HasDefaultValueSql("'0'");

                entity.Property(e => e.aptoManipulacionCarga).HasDefaultValueSql("'0'");

                entity.Property(e => e.aptoTrabajosAltura).HasDefaultValueSql("'0'");

                entity.Property(e => e.artralgias).HasDefaultValueSql("'0'");

                entity.Property(e => e.asmaB).HasDefaultValueSql("'0'");

                entity.Property(e => e.cardiopat).HasDefaultValueSql("'0'");

                entity.Property(e => e.cirugias).HasDefaultValueSql("'0'");

                entity.Property(e => e.covid).HasDefaultValueSql("'0'");

                entity.Property(e => e.dermatosis).HasDefaultValueSql("'0'");

                entity.Property(e => e.diabetes).HasDefaultValueSql("'0'");

                entity.Property(e => e.dismenorrea).HasDefaultValueSql("'0'");

                entity.Property(e => e.embarazo).HasDefaultValueSql("'0'");

                entity.Property(e => e.epilepsia).HasDefaultValueSql("'0'");

                entity.Property(e => e.esguinceCronico).HasDefaultValueSql("'0'");

                entity.Property(e => e.fractura).HasDefaultValueSql("'0'");

                entity.Property(e => e.gastritis).HasDefaultValueSql("'0'");

                entity.Property(e => e.habilidades).HasDefaultValueSql("'0'");

                entity.Property(e => e.hepatitis).HasDefaultValueSql("'0'");

                entity.Property(e => e.hernia).HasDefaultValueSql("'0'");

                entity.Property(e => e.hipoacustico).HasDefaultValueSql("'0'");

                entity.Property(e => e.hombroDoloroso).HasDefaultValueSql("'0'");

                entity.Property(e => e.lumbalgias).HasDefaultValueSql("'0'");

                entity.Property(e => e.migranas).HasDefaultValueSql("'0'");

                entity.Property(e => e.nasofaringe).HasDefaultValueSql("'0'");

                entity.Property(e => e.nuevasTecnologias).HasDefaultValueSql("'0'");

                entity.Property(e => e.ocuparVacante).HasDefaultValueSql("'0'");

                entity.Property(e => e.otalgias).HasDefaultValueSql("'0'");

                entity.Property(e => e.papanicolaou).HasDefaultValueSql("'0'");

                entity.Property(e => e.porAccidente).HasDefaultValueSql("'0'");

                entity.Property(e => e.prevenirRiesgo).HasDefaultValueSql("'0'");

                entity.Property(e => e.problemasRenales).HasDefaultValueSql("'0'");

                entity.Property(e => e.pruebaDiabetes).HasDefaultValueSql("'0'");

                entity.Property(e => e.recuperacionQuimio).HasDefaultValueSql("'0'");

                entity.Property(e => e.restricciones).HasDefaultValueSql("'0'");

                entity.Property(e => e.sanoApto).HasDefaultValueSql("'0'");

                entity.Property(e => e.tosCronica).HasDefaultValueSql("'0'");

                entity.Property(e => e.usaLentes).HasDefaultValueSql("'0'");

                entity.Property(e => e.varices).HasDefaultValueSql("'0'");

                entity.Property(e => e.vistaOido).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.examenmedicos)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examen_medico_empleados1");

                entity.HasOne(d => d.id_examenMedicoTNavigation)
                    .WithMany(p => p.examenmedicos)
                    .HasForeignKey(d => d.id_examenMedicoT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examenMedico_examenMedicoT1");
            });

            modelBuilder.Entity<examenmedicot>(entity =>
            {
                entity.HasKey(e => e.id_examenMedicoT)
                    .HasName("PRIMARY");

                entity.Property(e => e.id_examenMedicoT).ValueGeneratedNever();

                entity.Property(e => e.utilizable).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<falta>(entity =>
            {
                entity.HasKey(e => e.id_falta)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.falta)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_faltas_empleado1");
            });

            modelBuilder.Entity<formato>(entity =>
            {
                entity.HasKey(e => e.id_formato)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_departamentoNavigation)
                    .WithMany(p => p.formatos)
                    .HasForeignKey(d => d.id_departamento)
                    .HasConstraintName("fk_formato_departamento1");
            });

            modelBuilder.Entity<hipertension>(entity =>
            {
                entity.HasKey(e => e.id_hiperT)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_trabajoENavigation)
                    .WithMany(p => p.hipertensions)
                    .HasForeignKey(d => d.id_trabajoE)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hiperTension_trabajoExterno1");
            });

            modelBuilder.Entity<historialanalisismedico>(entity =>
            {
                entity.HasKey(e => e.id_historialA)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_analisisTNavigation)
                    .WithMany(p => p.historialanalisismedicos)
                    .HasForeignKey(d => d.id_analisisT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_historialAnalisis_analisisTipo1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.historialanalisismedicos)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_historialAnalisis_empleado1");
            });

            modelBuilder.Entity<hora>(entity =>
            {
                entity.HasKey(e => e.id_hora)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<incapacidad>(entity =>
            {
                entity.HasKey(e => e.id_incapacidad)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.incapacidads)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_incapacidad_empleado1");
            });

            modelBuilder.Entity<inmobiliario>(entity =>
            {
                entity.HasKey(e => e.id_inmobiliario)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.inmobiliarios)
                    .HasForeignKey(d => d.id_area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inmobiliario_area1");
            });

            modelBuilder.Entity<iva>(entity =>
            {
                entity.HasKey(e => e.id_iva)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<medicamento>(entity =>
            {
                entity.HasKey(e => e.id_medicamento)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_medicamentoTNavigation)
                    .WithMany(p => p.medicamentos)
                    .HasForeignKey(d => d.id_medicamentoT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_medicamentos_medicamentoTipo1");
            });

            modelBuilder.Entity<medicamentotipo>(entity =>
            {
                entity.HasKey(e => e.id_medicamentoT)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<nomina>(entity =>
            {
                entity.HasKey(e => e.id_nomina)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<ordencompra>(entity =>
            {
                entity.HasKey(e => e.id_ordenC)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_cotizacionNavigation)
                    .WithMany(p => p.ordencompras)
                    .HasForeignKey(d => d.id_cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordenCompra_cotizacion1");
            });

            modelBuilder.Entity<pariente>(entity =>
            {
                entity.HasKey(e => e.id_pariente)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.parientes)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pariente_empleado1");
            });

            modelBuilder.Entity<partidum>(entity =>
            {
                entity.HasKey(e => e.id_partida)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.partida)
                    .HasForeignKey(d => d.id_area)
                    .HasConstraintName("fk_partida_area1");

                entity.HasOne(d => d.id_departamentoNavigation)
                    .WithMany(p => p.partida)
                    .HasForeignKey(d => d.id_departamento)
                    .HasConstraintName("fk_partida_departamento1");

                entity.HasOne(d => d.id_presupuestoNavigation)
                    .WithMany(p => p.partida)
                    .HasForeignKey(d => d.id_presupuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_partida_presupuesto1");
            });

            modelBuilder.Entity<permiso>(entity =>
            {
                entity.HasKey(e => e.id_permiso)
                    .HasName("PRIMARY");

                entity.Property(e => e.pagado).HasDefaultValueSql("b'0'");

                entity.Property(e => e.status).HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.permisos)
                    .HasForeignKey(d => d.id_empleado)
                    .HasConstraintName("fk_permiso_empleados1");

                entity.HasOne(d => d.id_modalidadNavigation)
                    .WithMany(p => p.permisos)
                    .HasForeignKey(d => d.id_modalidad)
                    .HasConstraintName("fk_permiso_permisoModalidad1");
            });

            modelBuilder.Entity<permisomodalidad>(entity =>
            {
                entity.HasKey(e => e.id_modalidad)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<presupuesto>(entity =>
            {
                entity.HasKey(e => e.id_presupuesto)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<proveedor>(entity =>
            {
                entity.HasKey(e => e.id_proveedor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<puesto>(entity =>
            {
                entity.HasKey(e => e.id_puesto)
                    .HasName("PRIMARY");

                //entity.HasOne(d => d.id_empleadoTNavigation)
                //    .WithMany(p => p.puestos)
                //    .HasForeignKey(d => d.id_empleadoT)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_puesto_empleadoT");
            });

            modelBuilder.Entity<refaccion>(entity =>
            {
                entity.HasKey(e => e.id_refaccion)
                    .HasName("PRIMARY");

                entity.Property(e => e.cantidad).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<renovacion>(entity =>
            {
                entity.HasKey(e => e.id_renovacion)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.renovacions)
                    .HasForeignKey(d => d.id_empleado)
                    .HasConstraintName("fk_renovacion_empleado1");
            });

            modelBuilder.Entity<solicitudcompra>(entity =>
            {
                entity.HasKey(e => e.id_solicitudC)
                    .HasName("PRIMARY");

                entity.Property(e => e.status).HasDefaultValueSql("'1'");

                entity.HasOne(d => d.id_partidaNavigation)
                    .WithMany(p => p.solicitudcompras)
                    .HasForeignKey(d => d.id_partida)
                    .HasConstraintName("fk_solicitudCompra_partida1");
            });

            modelBuilder.Entity<submodulo>(entity =>
            {
                entity.HasKey(e => e.id_subM)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_rolNavigation)
                    .WithMany(p => p.submodulos)
                    .HasForeignKey(d => d.id_rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subModulos_empleadoRol1");
            });

            modelBuilder.Entity<sucursale>(entity =>
            {
                entity.HasKey(e => e.id_sucursal)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<suspension>(entity =>
            {
                entity.HasKey(e => e.id_suspension)
                    .HasName("PRIMARY");

                entity.Property(e => e.dias).HasDefaultValueSql("'0'");

                entity.Property(e => e.status).HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.suspensions)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_suspension_empleado1");
            });

            modelBuilder.Entity<tiempoextra>(entity =>
            {
                entity.HasKey(e => e.id_tiempoExtra)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<tiempoextraestado>(entity =>
            {
                entity.HasKey(e => e.id_estado)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<tipobaja>(entity =>
            {
                entity.HasKey(e => e.id_tipoBaja)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<trabajo_refaccion>(entity =>
            {
                entity.HasKey(e => e.id_trabajoRefaccion)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.id_refaccionNavigation)
                    .WithMany(p => p.trabajo_refaccions)
                    .HasForeignKey(d => d.id_refaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_refaccion_has_trabajoInterno_refaccion1");

                entity.HasOne(d => d.id_trabajoINavigation)
                    .WithMany(p => p.trabajo_refaccions)
                    .HasForeignKey(d => d.id_trabajoI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_refaccion_has_trabajoInterno_trabajoInterno1");
            });

            modelBuilder.Entity<trabajoexterno>(entity =>
            {
                entity.HasKey(e => e.id_trabajoE)
                    .HasName("PRIMARY");

                entity.Property(e => e.cancelado).HasDefaultValueSql("b'0'");

                entity.Property(e => e.condicionAreaTrabajo).HasDefaultValueSql("b'0'");

                entity.Property(e => e.conformidad).HasDefaultValueSql("b'0'");

                entity.Property(e => e.equipo).HasDefaultValueSql("b'0'");

                entity.Property(e => e.liberacionSH).HasDefaultValueSql("b'0'");

                entity.Property(e => e.medidasSeguridad).HasDefaultValueSql("b'0'");

                entity.Property(e => e.rs).HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.trabajoexternos)
                    .HasForeignKey(d => d.id_area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoExterno_area1");

                entity.HasOne(d => d.id_departamentoNavigation)
                    .WithMany(p => p.trabajoexternos)
                    .HasForeignKey(d => d.id_departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoExterno_departamento1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.trabajoexternos)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajo_empleados1");

                entity.HasOne(d => d.id_tipoNavigation)
                    .WithMany(p => p.trabajoexternos)
                    .HasForeignKey(d => d.id_tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajo_trabajo_tipo1");
            });

            modelBuilder.Entity<trabajointerno>(entity =>
            {
                entity.HasKey(e => e.id_trabajoI)
                    .HasName("PRIMARY");

                entity.Property(e => e.cancelado).HasDefaultValueSql("b'0'");

                entity.Property(e => e.equipoTrabajo).HasDefaultValueSql("b'0'");

                entity.Property(e => e.liberacionSH).HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.id_areaNavigation)
                    .WithMany(p => p.trabajointernos)
                    .HasForeignKey(d => d.id_area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoInterno_area1");

                entity.HasOne(d => d.id_departamentoNavigation)
                    .WithMany(p => p.trabajointernos)
                    .HasForeignKey(d => d.id_departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoInterno_departamento1");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.trabajointernos)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoInterno_empleado1");

                entity.HasOne(d => d.id_inmobiliarioNavigation)
                    .WithMany(p => p.trabajointernos)
                    .HasForeignKey(d => d.id_inmobiliario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoInterno_inmobiliario1");

                entity.HasOne(d => d.id_tipo_trabajoNavigation)
                    .WithMany(p => p.trabajointernos)
                    .HasForeignKey(d => d.id_tipo_trabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajoInterno_trabajoTipo1");
            });

            modelBuilder.Entity<trabajotipo>(entity =>
            {
                entity.HasKey(e => e.id_trabajoT)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<turno>(entity =>
            {
                entity.HasKey(e => e.id_turno)
                    .HasName("PRIMARY");

                entity.Property(e => e.comida).HasDefaultValueSql("'00:00:00'");

                entity.Property(e => e.descanso).HasDefaultValueSql("'domingo'");

                entity.Property(e => e.disponible).HasDefaultValueSql("'1'");

                entity.Property(e => e.entradaF).HasDefaultValueSql("'00:00:00'");

                entity.Property(e => e.id_sucursal).HasDefaultValueSql("'9'");

                entity.Property(e => e.salidaF).HasDefaultValueSql("'00:00:00'");

                entity.HasOne(d => d.id_sucursalNavigation)
                    .WithMany(p => p.turnos)
                    .HasForeignKey(d => d.id_sucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sucursal");
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(e => e.id_usuario)
                    .HasName("PRIMARY");

                entity.Property(e => e.compras).HasDefaultValueSql("b'0'");

                entity.Property(e => e.god).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_empleado1");
            });

            modelBuilder.Entity<usuario_empleadorol>(entity =>
            {
                entity.HasKey(e => e.id_usuario)
                    .HasName("PRIMARY");

                entity.Property(e => e.id_usuario).ValueGeneratedNever();

                entity.Property(e => e.master).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.id_crudNavigation)
                    .WithMany(p => p.usuario_empleadorols)
                    .HasForeignKey(d => d.id_crud)
                    .HasConstraintName("fk_usuario_has_empleadoRol_crud1");

                entity.HasOne(d => d.id_rolNavigation)
                    .WithMany(p => p.usuario_empleadorols)
                    .HasForeignKey(d => d.id_rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_has_empleadoRol_empleadoRol1");

                entity.HasOne(d => d.id_sucursalNavigation)
                    .WithMany(p => p.usuario_empleadorols)
                    .HasForeignKey(d => d.id_sucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_has_empleadoRol_sucursal1");

                entity.HasOne(d => d.id_usuarioNavigation)
                    .WithOne(p => p.usuario_empleadorol)
                    .HasForeignKey<usuario_empleadorol>(d => d.id_usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_has_empleadoRol_usuario1");
            });

            modelBuilder.Entity<usuariorol>(entity =>
            {
                entity.HasKey(e => e.id_rol)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<vacacione>(entity =>
            {
                entity.HasKey(e => e.id_vacaciones)
                    .HasName("PRIMARY");

                entity.Property(e => e.cantidadPago).HasDefaultValueSql("'0'");

                entity.Property(e => e.dias).HasDefaultValueSql("'0'");

                entity.Property(e => e.gozado).HasDefaultValueSql("b'0'");

                entity.Property(e => e.pagado).HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.id_empleadoNavigation)
                    .WithMany(p => p.vacaciones)
                    .HasForeignKey(d => d.id_empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vacaciones_empleados1");
            });

            modelBuilder.Entity<vacacionesperiodo>(entity =>
            {
                entity.HasKey(e => e.id_vacacionesP)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
