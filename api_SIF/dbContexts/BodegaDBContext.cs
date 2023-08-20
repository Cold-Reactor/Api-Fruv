using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_SIF.Models.Bodega;

namespace api_SIF.dbContexts
{
    public partial class BodegaDBContext : DbContext
    {
        public BodegaDBContext(DbContextOptions<BodegaDBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  


        }

        public virtual DbSet<procedencias> procedencia { get; set; }


    }
}
