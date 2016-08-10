using System.Web;

namespace Cmx.Timesheet.WebApi {
    public class WebApiApplication : HttpApplication {
        protected void Application_Start() {
            UnityConfig.RegisterComponents();

            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}