using api_SIF.dbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // Configurar autenticación con JWT
            var jwtSettings = Configuration.GetSection("JwtSettings");
            var a = jwtSettings["SecretKey"];
            var b = jwtSettings["Issuer"];
            var c = jwtSettings["Audience"];
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
   .AddJwtBearer(options =>
   {
       options.RequireHttpsMetadata = false;
       options.SaveToken = true;
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateIssuerSigningKey = true,
           ValidateLifetime = true, // Validar la expiración del token
           //ClockSkew = TimeSpan.Zero, // No permitir diferencia de tiempo entre el servidor y el token (opcional)
           ValidIssuer = jwtSettings["Issuer"],
           ValidAudience = jwtSettings["Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(key),
       };
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
