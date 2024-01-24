using Application;
using Application.Person.Commands;
using Application.Repository.Interface;
using Infrastucture;
using Infrastucture.Context;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MediatorCleanSolution
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MediatR API",
                    Version = "v1",
                    Description = "Practice MediatR with Clean Architcture",
                });
            });

            var cs = Configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));
            services
                .AddApplication()
                .AddInfrastructure();

            services.AddScoped<IPersonRepository, PersonRepository>();
            var assembly = typeof(CreatePerson).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title V1");
            });

         
        }
    }
}
