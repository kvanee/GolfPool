using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GolfPool.DependencyResolution;
using Microsoft.AspNet.SignalR;
using StructureMap;

namespace GolfPool
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GolfPoolEntities.RecreateAndSeedDB();

            GlobalHost.DependencyResolver = new StructureMapSignalRDependencyResolver(ObjectFactory.Container);
            
            AreaRegistration.RegisterAllAreas();

            RouteTable.Routes.MapHubs();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Handle all unhandled exceptions
            var ex = Server.GetLastError().GetBaseException();
            //log.Error(ex);
            Server.ClearError();
        }
    }
}