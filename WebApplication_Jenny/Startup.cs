using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using NSwag.AspNet.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApplication_Jenny.Startup))]

namespace WebApplication_Jenny
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.UseSwaggerUi3(typeof(Startup).Assembly, settings =>
            {
                //針對RPC-Style WebAPI，指定路由包含Action名稱
                //settings.GeneratorSettings.DefaultUrlTemplate =
                //    "api/{controller}/{action}/{id?}";
                //可加入客製化調整邏輯
                settings.PostProcess = document =>
                {
                    document.Info.Title = "Northwind API";
                    document.Info.Description = "Contains function of CRUD.";
                };
            });
            //app.UseWebApi(config);
            //config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
        }
    }
}