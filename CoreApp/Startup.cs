using CoreApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreApp.Services;
using CoreApp.Middlewares;
using FluentValidation.AspNetCore;
namespace CoreApp
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
            //Registerd the DbContext as Scoped in Default DI
            services.AddDbContext<ApplicationDbContext>((Options)=> {
                Options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbConnection"));
                });
            services.AddTransient<IService<Course, int>, CourseService>();
            services.AddTransient<IService<Student, int>, StudentServices>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ModelStateFilter());
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.CustomExceptionHandlerMiddleware();
            app.UseMvc();

            
        }
    }
}
