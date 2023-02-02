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
