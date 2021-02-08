using Core.Configuration;
using Core.Services;
using DomainModel;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
            //register DbContext
            services.AddDbContext<SystemContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]));

            //register mapping configuration
            services.AddAutoMapper(mc => mc.AddProfile(new MappingProfile()));

            //register Repository Pattern
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //register Service
            services.AddScoped<ICustomerService, CustomerService>();

            //Configuration Cors
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));

            //Configuration Worker
            services.AddHostedService<Worker>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
