using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.Empleados;

namespace api_SIF.dbContexts
{
    public partial class RHDBContext : DbContext
    {
      
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
                entity.HasKey(e => new { e.Id, e.noEmpleado })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.RegistraPermiso).HasDefaultValueSql("'0'");

                entity.Property(e => e.Status).HasDefaultValueSql("'1'");

                entity.Property(e => e.areaid).HasDefaultValueSql("'0'");

                entity.Property(e => e.presencial).HasDefaultValueSql("'1'");

                entity.Property(e => e.renovacion).HasDefaultValueSql("'0'");

                entity.Property(e => e.supervisor).HasDefaultValueSql("'0'");

                entity.Property(e => e.tipoBaja).HasDefaultValueSql("'0'");

                entity.Property(e => e.turnoId).HasDefaultValueSql("'1'");

                entity.Property(e => e.user).HasDefaultValueSql("'1'");
            });

        }

    }
}
