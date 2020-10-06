using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WordWideImporters.Services;

namespace WordWideImporters
{
    public class GlobalConfiguration 
    {
        public string connectionString { get; set; }
    }

    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            /// enable MVC routing 
            services.AddMvc(option => option.EnableEndpointRouting = false);

            // accept the header on request
            services.AddMvc(option => option.RespectBrowserAcceptHeader = true);

            var myGlobalConfiguration = new GlobalConfiguration()
            {
                connectionString = Configuration["connectionStrings:tableDbConnectionString"]
            };


            var connectionString = Configuration["connectionStrings:tableDbConnectionString"];

            services.AddDbContext<WordWideImporterAdoContext>(options =>options.UseSqlServer(connectionString));

            services.AddScoped<IWorldWideImporterTables, WordWideImporterTableRepo>();

            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseMvc();
        }
    }
}
