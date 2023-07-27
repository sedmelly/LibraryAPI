using LibraryApplication.Services;
using LibraryApplication.Services.Base;
using LibraryCore.Entities;
using LibraryCore.Repositories;
using LibraryInfrastructure.Data;
using LibraryInfrastructure.Repositories;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using LibraryProject.Services;


namespace LibraryAPI
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
            services.AddDbContext<LibraryContext>(k =>
            {
                k.UseNpgsql("SERVER=10.0.90.190;Database=postgres;User name=postgres;Password=profen");
            }, ServiceLifetime.Scoped);

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
            services.AddScoped(typeof(IBookService), typeof(BookService));

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
            services.AddScoped(typeof(IAuthorService), typeof(AuthorService));

          
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryProject v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
