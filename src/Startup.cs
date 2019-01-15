using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotnetCoreWorker.Jobs;
using DotnetCoreWorker.Repositories;
using DotnetCoreWorker.Widgets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotnetCoreWorker
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ICountRepository, CountRepository>();

            services.AddTransient<WidgetOne>(s => 
                new WidgetOne(s.GetService<ILogger<WidgetOne>>(), "Widget one stuff"));

            services.AddTransient<WidgetTwo>(s =>
                new WidgetTwo(s.GetService<ILogger<WidgetTwo>>(), "Widget two stuff"));

            services.AddTransient(s =>
            {
                var flip = new Random().Next() % 2 == 0;

                if (flip)
                {
                    return (IWidget)s.GetService<WidgetOne>();
                }

                return (IWidget)s.GetService<WidgetTwo>();
            });

            //services.AddTransient<IWidgetFactory, WidgetFactory>();

            services.AddHostedService<DecrementJob>();
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
            app.UseMvc();
        }
    }
}
