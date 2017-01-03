using AutoMapper;
using Microsoft.Practices.Unity;

namespace Cmx.Timesheet.Mappings
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<IMapper>(
                new InjectionFactory(
                    c =>
                    {
                        return
                            new Mapper(
                                new MapperConfiguration(
                                    cfg => cfg.AddProfile(new TimesheetModelToTimesheetListItemMap())));
                    }));
        }
    }
}