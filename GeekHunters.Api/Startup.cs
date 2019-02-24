using AutoMapper;
using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using GeekHunters.Services;
using GeekHunters.Services.Interfaces;
using GeekHunters.Repositories;
using GeekHunters.Repositories.Interfaces;

namespace GeekHunters.Api
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
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            string path = (new FileInfo(Environment.CurrentDirectory)).Directory.FullName;
            string connectionstring = string.Format(Configuration.GetConnectionString("DefaultConnection"), path);

            services.AddDbContext<GeekHuntersContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlite(connectionstring));
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GeekHunters.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekHunters.API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
