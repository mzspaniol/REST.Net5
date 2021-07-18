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
using System;
using System.Collections.Generic;
using Rest.net5.Repository.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Rest.net5.Hypermedia.Filters;
using Rest.net5.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

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

            /* json to xml
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json");
            })
                .AddXmlSerializerFormatters();
            */

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOptions);
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>{
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API's From 0 to Azure with ASP.NET CORE 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful",
                        Contact = new OpenApiContact
                        {
                            Name = "Matheus Spaniol",
                            Url = new Uri("https://github.com/mzspaniol/REST.Net5")
                        }
                    });
            });
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
            
            //Swagger documentation
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API's From 0 to Azure with ASP.NET CORE 5 and Docker - V1");
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
