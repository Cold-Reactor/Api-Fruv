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

        public virtual DbSet<empleado> empleados { get; set; }

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
            modelBuilder.UseCollation("utf8_spanish2_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<empleado>(entity =>
            {
                entity.HasKey(e => e.id_empleado)
                    .HasName("PRIMARY");

                entity.Property(e => e.externo).HasDefaultValueSql("'0'");

                entity.Property(e => e.presencial).HasDefaultValueSql("'1'");

                entity.Property(e => e.status).HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
