using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePOC.DataLayer.InfraStructure;
using CorePOC.DataLayer.Repositories;
using CorePOC.DataLayer.Services;
using CorePOC.DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CorePOC
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
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IService, Service>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            services.AddTransient<IAuthFactory,AuthFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
