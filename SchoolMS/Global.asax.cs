using System      ;     
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SchoolMS
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Application Variable. CONTROLS THE WORKINGS OF THE APP.
            DateTime[] dates = new DateTime[3];
            dates[0] = new DateTime(DateTime.Now.Year, 4, 17); // Apr 17 
            dates[1] = new DateTime(DateTime.Now.Year, 8, 10); // Aug 10
            dates[2] = new DateTime(DateTime.Now.Year, 12, 6); // Dec 6 or Dec 23 

            if (DateTime.Now >= dates[0])
            {
                Application["term"] = "3";    
            }
            if (DateTime.Now >= dates[1])
            {
                Application["term"] = "1";
            }
            if (DateTime.Now >= dates[2])
            {
                Application["term"] = "2";
            }
            // ADD AN ELSE RETURN BACK TO FIRST TERM BEFORE JULY 22?



        }
    }
}