using api_SIF.dbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api_SIF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string BodegaConnectionStr = Configuration.GetConnectionString("BodegaConnection");
            services.AddDbContext<MyDBContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(BodegaConnectionStr, ServerVersion.AutoDetect(BodegaConnectionStr))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

            string RHConnectionStr = Configuration.GetConnectionString("RHConnection");

            services.AddDbContext<RHDBContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(RHConnectionStr, ServerVersion.AutoDetect(RHConnectionStr))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

            services.AddDbContext<BodegaDBContext>(
           dbContextOptions => dbContextOptions
           .UseMySql(BodegaConnectionStr, ServerVersion.AutoDetect(BodegaConnectionStr))
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("nuevaPolitica", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
    .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters()); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("nuevaPolitica");
            app.UseAuthorization();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/RH/swagger/v2/swagger.json", "MVCCallWebAPI");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
