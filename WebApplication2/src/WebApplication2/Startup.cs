using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env,IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
            }
            app.UseStaticFiles();

            app.UseMvc(routes =>
           {
               routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");


           });
            
        }
    }
    public class ConfigSetting
    {
        public string ConnectionString { get; set; }
    }
}
