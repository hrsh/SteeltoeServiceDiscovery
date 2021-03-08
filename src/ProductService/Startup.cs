using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

namespace ProductService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDiscoveryClient(Configuration);
            //services.AddServiceDiscovery(option => option.UseEureka());
            services.AddControllers();

            var connectionString = Configuration
                .GetConnectionString("marten");
            services
                .AddMarten(opts =>
                {
                    opts.Connection(connectionString);
                    opts.AutoCreateSchemaObjects = AutoCreate.All;
                })
                .BuildSessionsWith<CustomSessionFactory>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDiscoveryClient();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
