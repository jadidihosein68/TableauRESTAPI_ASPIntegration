using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Routing;
using TableauRestAPI.App_Start;
using System.Net.Http;
using TableauRestAPI.Services;

namespace TableauRestAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        


        protected void Application_Start()
        {



            TableauHttpClientConfig.RegisterClient(TableauHttpClient.client);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
