using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.Facebook;
using Microsoft.AspNet.Authentication.Google;
using Microsoft.AspNet.Authentication.MicrosoftAccount;
using Microsoft.AspNet.Authentication.Twitter;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using Microsoft.Framework.Runtime;
using TheGame.Models;

namespace TheGame
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                configuration.AddUserSecrets();
            }
            configuration.AddEnvironmentVariables();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Warning);

            if (env.IsEnvironment("Development"))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                app.UseErrorHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "YouJustLost",
                    template: "lost/{name}/{from}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
