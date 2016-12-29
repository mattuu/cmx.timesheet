using System;
using System.Web;
using System.Web.Http;

namespace Cmx.Timesheet.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    TypeNameHandling = TypeNameHandling.Objects,
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
        }
    }
}