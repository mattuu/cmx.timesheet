using System;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cmx.Timesheet.Api
{
    public class Global : HttpApplication
    {
        //protected void Application_Start(object sender, EventArgs e)
        //{
        //    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        //    {
        //        Formatting = Formatting.Indented,
        //        TypeNameHandling = TypeNameHandling.Objects,
        //        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //    };
        //}
    }
}