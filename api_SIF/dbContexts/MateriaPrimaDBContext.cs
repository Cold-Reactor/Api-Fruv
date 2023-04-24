using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.MateriaPrima;

namespace api_SIF.dbContexts
{
    public partial class MateriaPrimaDBContext : DbContext
    {
        public MateriaPrimaDBContext()
        {
        }

        public MateriaPrimaDBContext(DbContextOptions<MateriaPrimaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<foliomp> foliomps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=materiaprima;user=root;password=enramfle", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<foliomp>(entity =>
            {
                entity.Property(e => e.disponible).HasDefaultValueSql("'1'");

                entity.Property(e => e.identradadetalle).HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
