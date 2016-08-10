using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Filters;
using J2BI.Services.Logging.Service.Contract;

namespace J2BI.Holidays.HotelBranding.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        #region Constants

        private const string LogMessageTemplate = "Unhandled exception occurred - {0} - in {1}";

        #endregion

        #region Private Members

        private readonly ILoggingService _loggingService;

        #endregion

        #region .ctor

        public UnhandledExceptionFilter(IDependencyScope dependencyScope)
        {
            _loggingService = dependencyScope.GetService(typeof(ILoggingService)) as ILoggingService;
        }

        #endregion

        public override void OnException(HttpActionExecutedContext context)
        {
            _loggingService.Error(context.Exception.Message, context.Exception);

            var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(string.Format(LogMessageTemplate, context.Exception.Message, context.Exception.StackTrace)),
                ReasonPhrase = context.Exception.Message.Replace(Environment.NewLine, string.Empty)
            };

            context.Response = msg;
        }
    }
}