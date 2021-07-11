using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rest.net5.Model.Context;
using Rest.net5.Business.Implementations;
using Rest.net5.Repository.Implementations;
using Serilog;
using MySqlConnector;
using System;
using System.Collections.Generic;
using Rest.net5.Repository.Generic;

namespace Rest.net5
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      
            services.AddControllers();
            //var connection = Configuration.GetConnectionString("MySQLConnection:MySQLConnectionString");
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(connection);
            }

            // .net < 5
            //services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            // .net >= 5
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            services.AddApiVersioning();
            // Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), (typeof(GenericRepository<>)));

        }

        private void MigrateDataBase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/Migrations", "db/Dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();

            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw ex;
            }
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
