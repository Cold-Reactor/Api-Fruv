using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.Bodega;
using api_SIF.Models.Empleados;

namespace api_SIF.dbContexts
{
    public partial class BodegaDBContext : DbContext
    {
        public BodegaDBContext()
        {
        }

        public BodegaDBContext(DbContextOptions<BodegaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ordencompradetalle> ordencompradetalles { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ordencompradetalle>(entity =>
            {
                entity.Property(e => e.marca).HasDefaultValueSql("'0'");

                entity.Property(e => e.modelo).HasDefaultValueSql("''");

                entity.Property(e => e.noparte).HasDefaultValueSql("'0'");

                entity.Property(e => e.recibido).HasDefaultValueSql("'0'");

                entity.Property(e => e.vehiculo).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ordencompra>(entity =>
            {
                entity.Property(i => i.usuario).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<api_SIF.Models.Bodega.ordencompra> ordencompra { get; set; }

        public DbSet<api_SIF.Models.Empleados.Checadas2> Checadas2 { get; set; }

        public DbSet<api_SIF.Models.Empleados.Empleado> Empleado { get; set; }
    }
}
