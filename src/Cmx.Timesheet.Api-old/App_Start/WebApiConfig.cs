using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cmx.Timesheet.WebApi
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services
        //    //var formatters = config.Formatters;
        //    //formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        //    //var jsonFormatter = formatters.JsonFormatter;
        //    //var settings = jsonFormatter.SerializerSettings;
        //    //settings.Formatting = Formatting.Indented;
        //    //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        //    //config.MapHttpAttributeRoutes();

        //    //config.Filters.Add(new UnhandledExceptionFilter(config.DependencyResolver));
        //    //config.Filters.Add(new CreateEmptyActionInstanceIfNullAttribute());
        //    //config.Filters.Add(new ValidateModelAttribute());
        //    //config.Filters.Add(new EnableRoleImpersonationAttribute(
        //    //    (config.DependencyResolver).GetService(typeof(IAppConfigReader)) as IAppConfigReader));

        //    // Web API routes

        //    //config.Routes.MapHttpRoute(
        //    //    name: "DefaultApi",
        //    //    routeTemplate: "{controller}/{id}",
        //    //    defaults: new { id = RouteParameter.Optional }
        //    //);
        //}
    }
}
