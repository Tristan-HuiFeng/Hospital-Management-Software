using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Hospital_Management_Software
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //RegisterRoutes(RouteTable.Routes);
        }

        //void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.MapPageRoute("test", "Home", "~/Views/Home/Default.aspx");
        //    routes.MapPageRoute("test2", "About", "~/Views/Home/About.aspx");
        //    routes.MapPageRoute("test3", "Contact", "~/Views/Home/Contact.aspx");
        //}
    }
}