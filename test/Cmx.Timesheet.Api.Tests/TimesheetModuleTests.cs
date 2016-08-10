using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.Diagnostics;
using Nancy.Routing;
using Nancy.Testing;
using Nancy.ViewEngines;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Kernel;
using Xunit;

namespace J2BI.Namespace.Template.Api.Tests
{
    public class TimesheetModuleTests
    {
        [Fact, AutoMoqData, Ignore]
        public void Get_ShouldReturn_HttpStatusCode_OK( /*[Frozen] Mock<ITimesheetDataStore> timesheetDataStoreMock, IEnumerable<TimesheetModel> timesheetModels, TimesheetModule sut*/)
        {
            // arrange
            //timesheetDataStoreMock.Setup(m => m.GetTimesheets()).Returns(timesheetModels);
            try
            {
                var bootstrapper = new AutoFixtureMoqBootstrapper();
                var browser = new Browser(bootstrapper);

                browser.Get("", with => with.HttpRequest());
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
            // act

            //var result = await browser.Get("", with => { with.HttpRequest(); });

            // assert
            //result.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }

    public class AutoFixtureMoqBootstrapper : NancyBootstrapperWithRequestContainerBase<IFixture>
    {
        private INancyEnvironment _nancyEnvironment;
        private IEnumerable<TypeRegistration> _registrations;
        private IEnumerable<CollectionTypeRegistration> _collectionRegistrations;
        private IEnumerable<InstanceRegistration> _instanceRegistrations;
        private IEnumerable<ModuleRegistration> _moduleRegistrations;

        public AutoFixtureMoqBootstrapper()
        {
            ApplicationContainer.Customize(new AutoConfiguredMoqCustomization());
        }

        protected override INancyEnvironmentConfigurator GetEnvironmentConfigurator()
        {
            return ApplicationContainer.Create<DefaultNancyEnvironmentConfigurator>();
        }

        protected override IDiagnostics GetDiagnostics()
        {
            return ApplicationContainer.Create<DefaultDiagnostics>();
        }

        protected override IEnumerable<IApplicationStartup> GetApplicationStartupTasks()
        {
            return ApplicationContainer.CreateMany<ViewEngineApplicationStartup>();
        }
    
        protected override IEnumerable<IRegistrations> GetRegistrationTasks()
        {
            return ApplicationContainer.CreateMany<IRegistrations>();
        }

        public override INancyEnvironment GetEnvironment()
        {
            return _nancyEnvironment ?? (_nancyEnvironment = ApplicationContainer.Create<DefaultNancyEnvironment>());
        }

        protected override INancyEngine GetEngineInternal()
        {
            return ApplicationContainer.Create<NancyEngine>();
        }

        protected override IFixture GetApplicationContainer()
        {
            return ApplicationContainer;
        }

        protected override void RegisterNancyEnvironment(IFixture container, INancyEnvironment environment)
        {
            _nancyEnvironment = environment;
        }

        protected override void RegisterBootstrapperTypes(IFixture applicationContainer)
        {
        }

        protected override void RegisterTypes(IFixture container, IEnumerable<TypeRegistration> typeRegistrations)
        {
            _registrations = typeRegistrations;
        }

        protected override void RegisterCollectionTypes(IFixture container, IEnumerable<CollectionTypeRegistration> collectionTypeRegistrations)
        {
            _collectionRegistrations = collectionTypeRegistrations;
        }

        protected override void RegisterInstances(IFixture container, IEnumerable<InstanceRegistration> instanceRegistrations)
        {
            _instanceRegistrations = instanceRegistrations;
        }

        protected override IEnumerable<IRequestStartup> RegisterAndGetRequestStartupTasks(IFixture container, Type[] requestStartupTypes)
        {
            foreach (var requestStartupType in requestStartupTypes)
            {
                yield return ApplicationContainer.Create<IRequestStartup>();
            }
        }

        protected override IFixture CreateRequestContainer(NancyContext context)
        {
            return ApplicationContainer;
        }

        protected override void RegisterRequestContainerModules(IFixture container, IEnumerable<ModuleRegistration> moduleRegistrationTypes)
        {
            _moduleRegistrations = moduleRegistrationTypes;
        }

        protected override IEnumerable<INancyModule> GetAllModules(IFixture container)
        {
            foreach (var moduleRegistration in _moduleRegistrations)
            {
                yield return GetModule(container, moduleRegistration.ModuleType);
            }
        }

        protected override INancyModule GetModule(IFixture container, Type moduleType)
        {
            return (INancyModule) ApplicationContainer.Create(moduleType, new SpecimenContext(new SpecimenFactory<INancyModule>(() => (INancyModule) Activator.CreateInstance(moduleType))));
        }
    }
}