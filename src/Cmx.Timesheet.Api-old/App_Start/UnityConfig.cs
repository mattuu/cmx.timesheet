using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;

namespace Cmx.Timesheet.WebApi
{
    public static class UnityConfig
    {
        public static string LoggingConfigKey = "ILoggingService";
        public static string RepsConfigKey = "IRepsService";
        public static string PropertyConfigKey = "IPropertyService";

        public static void RegisterComponents()
        {
            //var container = new UnityContainer();
            //container.RegisterType<IPrincipal>(new InjectionFactory(_ => HttpContext.Current.User));
            //container.RegisterType<IActionHandlerFactory, ActionHandlerFactory>();
            //container.RegisterType<IActionProcessor, ActionProcessor>();
            //container.RegisterType<Func<Type, IActionHandler>>(new InjectionFactory(c => new Func<Type, IActionHandler>(type => (IActionHandler) container.Resolve(type))));
            //container.RegisterType<IAppConfigReader, AppConfigReader>(new InjectionConstructor());
            //container.RegisterType<IApplicationCache, InMemoryApplicationCache>(new InjectionConstructor());

            //container.RegisterType<IHotelBrandingContext, HotelBrandingContext>(new PerResolveLifetimeManager());

            //RegisterQueryHandlers(container);
            //RegisterCommandHandlers(container);
            //RegisterServices(container);
            //RegisterDataStores(container);

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        //private static void RegisterServices(UnityContainer container)
        //{
        //    container.RegisterType<ILoggingService>(new InjectionFactory(s => new ServiceClient<ILoggingService>(LoggingConfigKey).Proxy));
        //    container.RegisterType<IPropertyService>(new InjectionFactory(s => new ServiceClient<IPropertyService>(PropertyConfigKey).Proxy));
        //    container.RegisterType<IRepsService>(new InjectionFactory(s => new ServiceClient<IRepsService>(RepsConfigKey).Proxy));

        //    container.RegisterType<IPropertyDataService, PropertyDataService>();
        //    container.RegisterType<IUserInfoDataService, UserInfoDataService>();

        //    container.RegisterType<IEscalationWorkflowManager, EscalationWorkflowManager>();
        //    container.RegisterType<IBrandingCategoryProvider, BrandingCategoryProvider>();
        //}

        //private static void RegisterDataStores(UnityContainer container)
        //{
        //    container.RegisterType<IBrandingCategoryDataStore, BrandingCategoryDataStore>();
        //    container.RegisterType<IBrandingCategoryEscalationDataStore, BrandingCategoryEscalationDataStore>();
        //    container.RegisterType<IBrandingItemDataStore, BrandingItemDataStore>();
        //    container.RegisterType<IEscalationLevelDataStore, EscalationLevelDataStore>();
        //    container.RegisterType<IEscalationReasonDataStore, EscalationReasonDataStore>();
        //    container.RegisterType<IRequestDataStore, RequestDataStore>();
        //}

        //private static void RegisterQueryHandlers(UnityContainer container)
        //{
        //    container.RegisterType<QueryHandler<PropertyListQuery, IEnumerable<PropertyModel>>, PropertyListQueryHandler>();
        //    container.RegisterType<QueryHandler<PropertySummaryQuery, PropertySummaryModel>, PropertySummaryQueryHandler>();

        //    container.RegisterType<QueryHandler<BrandingCategoryEscalationHistoryQuery, IEnumerable<EscalationHistoryModel>>, BrandingCategoryEscalationHistoryQueryHandler>();

        //    container.RegisterType<QueryHandler<RequestListQuery, IEnumerable<RequestModel>>, RequestListQueryHandler>();
        //    container.RegisterType<QueryHandler<RequestQuery, RequestModel>, RequestQueryHandler>();
        //    container.RegisterType<QueryHandler<NewRequestQuery, RequestModel>, NewRequestQueryHandler>();
        //}

        //private static void RegisterCommandHandlers(UnityContainer container)
        //{
        //    container.RegisterType<CommandHandler<EscalationInitializeCommand>, EscalationInitializeCommandHandler>();
        //    container.RegisterType<CommandHandler<EscalationProgressCommand>, EscalationProgressCommandHandler>();
        //    container.RegisterType<CommandHandler<EscalationResolveCommand>, EscalationResolveCommandHandler>();
        //    container.RegisterType<CommandHandler<CreateRequestCommand>, CreateRequestCommandHandler>();
        //    container.RegisterType<CommandHandler<UpdateRequestCommand>, UpdateRequestCommandHandler>();
        //    container.RegisterType<CommandHandler<SendRequestToMarketingCommand>, SendRequestToMarketingCommandHandler>();
        //    container.RegisterType<CommandHandler<RejectRequestCommand>, RejectRequestCommandHandler>();
        //}
    }
}