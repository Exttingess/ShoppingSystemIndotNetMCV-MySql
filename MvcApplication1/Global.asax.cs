using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApplication1.Extensions;
using MvcApplication1.Models;

namespace MvcApplication1
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            // autofac注册
            //AutofacConfig.Register();
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            log.Error(lastError.Message, lastError);
            Response.WriteFile("~/Views/Shared/Error.cshtml");
            Server.ClearError();
        }

    }
}