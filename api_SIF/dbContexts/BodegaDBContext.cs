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

        public virtual DbSet<ordencompradetalle> ordencompradetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=bodega;user=root;password=enramfle", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<api_SIF.Models.Bodega.ordencompra> ordencompra { get; set; }
    }
}
