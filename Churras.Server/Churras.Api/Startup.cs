using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Churras.Api.Filters;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.Dtos;
using Churras.Repository;
using Churras.Repository.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Churras.Api
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
            var mvc = services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.Filters.Add(typeof(ValidationErrorFilter));
            });

            mvc.AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<BarbecueDto>()
            );

            mvc.AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", BuildSwaggerInfo());
                c.IncludeXmlComments(GetXmlInfoPath());
            });

            this.BootstrapDependencies(services);
        }

        private void BootstrapDependencies(IServiceCollection services)
        {
            var databaseStrategy = Configuration.GetValue<string>("DBStrategy");

            services.AddDbContext<ChurrasContext>(opt =>
            {
                if (databaseStrategy == "InMemory")
                    opt.UseInMemoryDatabase("churras_db");
                else
                    opt.UseSqlite("Data Source=churras_db");

                System.Console.WriteLine($"DBStrategy: {databaseStrategy}");
            });

            services.AddScoped<IBarbecueRepository, BarbecueRepository>();
        }

        private void RunMigrationsAndSeed(IApplicationBuilder app)
        {
            var databaseStrategy = Configuration.GetValue<string>("DBStrategy");

            using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ChurrasContext>();
                if (databaseStrategy == "SQLite")
                {
                    context.Database.Migrate();
                    context.EnsureSeedData();
                }
                else
                {
                    context.AddTestData();
                }
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            this.RunMigrationsAndSeed(app);

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Churras API")
            );
        }

        private string GetXmlInfoPath()
        {
            string appPath = PlatformServices.Default.Application.ApplicationBasePath;
            return Path.Combine(appPath, "Churras.Api.xml");
        }

        private Info BuildSwaggerInfo()
        {
            return new Info
            {
                Title = "Churras API", Version = "v1", Description = "-", Contact = new Contact { Name = "Bruno Terragno", Url = "http://brunoterragno.com" }
            };
        }
    }
}