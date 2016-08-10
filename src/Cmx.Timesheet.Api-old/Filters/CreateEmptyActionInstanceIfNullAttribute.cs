using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using J2BI.Holidays.HotelBranding.Action.Core.Action;

namespace J2BI.Holidays.HotelBranding.Api.Filters
{
    public class CreateEmptyActionInstanceIfNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var parameters = actionContext.ActionDescriptor.GetParameters();
            foreach (var parameter in parameters)
            {
                object value = null;

                if (actionContext.ActionArguments.ContainsKey(parameter.ParameterName))
                    value = actionContext.ActionArguments[parameter.ParameterName];

                if (value != null)
                    continue;

                value = CreateInstance(parameter.ParameterType);
                if (value == null)
                {
                    actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, "The argument cannot be null");
                }
                else
                {
                    actionContext.ActionArguments[parameter.ParameterName] = value;
                    // rerun the validator as it will run before any filters
                    var controller = actionContext.ControllerContext.Controller as ApiController;
                    controller?.Validate(value);
                }
            }

            base.OnActionExecuting(actionContext);
        }

        protected virtual object CreateInstance(Type type)
        {
            if (type.GetInterface(typeof(IAction).Name) != null)
            {
                return Activator.CreateInstance(type); // create object only if the type is Action
            }
            return null;
        }
    }
}