using Newtonsoft.Json;
using System      ;     
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SchoolMS
{
    class Config
    {
        public string DateUpdated { get; set; }
        public int[] Term { get; set; }
    }
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Application Variable. CONTROLS THE WORKINGS OF THE APP.
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateresult;
            var config = File.ReadAllText(@"C:\Users\User\Desktop\SchoolMS\SchoolMS\TermConfig.json");
            Config _config = JsonConvert.DeserializeObject<Config>(config);

            var x = _config.Term[0];
            var y = _config.Term[1];
            DateTime[] dates = new DateTime[5];
            dates[0] = new DateTime(x, 8, 10); // x YEAR Aug 10
            dates[1] = new DateTime(x, 12, 6); // x YEAR Dec 6 or Dec 23 
            dates[2] = new DateTime(y, 4, 17); // y YEAR Apr 17 
            dates[3] = new DateTime(y, 7, 22); // y YEAR July 22
            dates[4] = new DateTime(y, 7, 22); // y YEAR AUG 10

           // Console.WriteLine("format: m-d-y");


            if (DateTime.Now >= dates[0] && DateTime.Now < dates[1])
            {
                //Console.WriteLine("Term: 1");
                Application["term"] = "1";
            }
            else if (DateTime.Now >= dates[1] && DateTime.Now < dates[2])
            {
                //Console.WriteLine("Term: 2");
                Application["term"] = "2";
               /* if (DateTime.TryParseExact(_config.DateUpdated, "M/dd/yyyy", enUS, DateTimeStyles.None, out dateresult))
                {
                    Console.WriteLine(dateresult - DateTime.Now);
                }*/
            }
            else if (DateTime.Now >= dates[2] && DateTime.Now < dates[3])
            {
                Console.WriteLine("Term: 3");
                Application["term"] = "3";
            }
            else if (DateTime.Now >= dates[3] && DateTime.Now < dates[4])
            {
                //TODO: SET APPLICATION VARIABLE TO FIRST TERM AND INCREMENT SESSION 2020/2021 TO 2021/2022
               // Console.WriteLine("SUMMER... CHANGE DATES");

                if (DateTime.TryParseExact(_config.DateUpdated, "M/dd/yyyy", enUS, DateTimeStyles.None, out dateresult))
                {
                    Console.WriteLine(dateresult - DateTime.Now);
                }



            }
            // ADD AN ELSE RETURN BACK TO FIRST TERM BEFORE JULY 22?





        }
    }
}