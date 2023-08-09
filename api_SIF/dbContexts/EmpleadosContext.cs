using api_SIF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.dbContexts
{
    public class EmpleadosContext : DbContext
    {

      
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options)
        { }
                 protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Use Fluent API to configure  

                // Map entities to tables  
               

            }
        public DbSet<api_SIF.Models.Empleados.Checadas2> Checadas2 { get; set; }


    }


}
