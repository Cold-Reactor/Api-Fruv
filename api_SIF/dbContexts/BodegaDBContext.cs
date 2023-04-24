using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.Bodega;

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

        public virtual DbSet<ordencompra> ordencompras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=bodega;user=root;password=enramfle", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ordencompra>(entity =>
            {
                entity.Property(e => e.autorizado).HasDefaultValueSql("'0'");

                entity.Property(e => e.autorizadoSupervisor).HasDefaultValueSql("'0'");

                entity.Property(e => e.cancelado).HasDefaultValueSql("'0'");

                entity.Property(e => e.cotizado).HasDefaultValueSql("'0'");

                entity.Property(e => e.cuenta).HasDefaultValueSql("'0'");

                entity.Property(e => e.encamino).HasDefaultValueSql("'0'");

                entity.Property(e => e.estado).HasDefaultValueSql("'0'");

                entity.Property(e => e.id_departamento).HasDefaultValueSql("'0'");

                entity.Property(e => e.impreso).HasDefaultValueSql("'0'");

                entity.Property(e => e.padre).HasDefaultValueSql("'0'");

                entity.Property(e => e.subcuenta).HasDefaultValueSql("'0'");

                entity.Property(e => e.tipocambio).HasDefaultValueSql("'0'");

                entity.Property(e => e.tipodepago).HasDefaultValueSql("'0'");

                entity.Property(e => e.userNOAutorizo).HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
