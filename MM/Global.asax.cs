using System.Web.Http;
using System.Web.Routing;
using Host;
using Mike.MM.App_Start;

namespace Mike.MM
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
