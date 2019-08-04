using System.Fabric;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayNinja
{
    public class Startup
    {
        private readonly StatelessServiceContext _serviceContext;

        public Startup(IConfiguration configuration, StatelessServiceContext serviceContext)
        {
            Configuration = configuration;
            _serviceContext = serviceContext;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //var appName = _serviceContext.CodePackageActivationContext.ApplicationName;
            //app.RunHttpServiceGateway("/hidden", $"{appName}/HiddenNinja");
            //app.RunHttpServiceGateway("/hidden/api", $"{appName}/HiddenNinja/api/hidden");

            app.Run(async handler =>
            {
                handler.Response.StatusCode = 200;
                await handler.Response.WriteAsync($"Healthy <br><br> --- <br> Best <br> <i><small>{nameof(GatewayNinja)}</small></i>");
            });
        }
    }
}
