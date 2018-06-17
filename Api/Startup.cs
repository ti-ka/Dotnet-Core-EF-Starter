using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Context;
using Services;

namespace Api
{
    public class Startup
    {
        #region Build Configuration
        private IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        #endregion
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services
            // When I ask for IUserService give me UserService
            services.AddTransient<IUserService, UserService>();
            
            // Singleton: 1 for Application Lifecycle
            // Scoped: 1 for 1 Http Request
            // Transient: Give me a fresh one everytime
            
            services.AddMvc();
            
            // Setup CORS:
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("wildcard", corsBuilder.Build());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("wildcard");
            app.UseMvcWithDefaultRoute();
        }
    }
}
