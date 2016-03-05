using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebAPIDemo2.Models;
using System.Web.Routing;
using System.Web.Services.Description;

[assembly: OwinStartup(typeof(WebAPIDemo2.Startup))]

namespace WebAPIDemo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
            ConfigureAuth(app);
        }

        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Add our repository type
            services.AddSingleton<ITodoRepository, TodoRepository>();
        } */
    }
}
