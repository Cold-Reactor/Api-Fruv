using api_SIF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.dbContexts
{
    public class MyDBContext : DbContext
    {

      
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { }
                 protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Use Fluent API to configure  

                // Map entities to tables  
               

            }
               
    }

    
}
