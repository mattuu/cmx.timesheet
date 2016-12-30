using AutoMapper;

namespace Cmx.Timesheet.Mappings
{
    public abstract class AutoMapperMap<TFrom, TTo> : Profile, IMap<TFrom, TTo>
    {
        protected IMappingExpression<TFrom, TTo> Map;

        protected AutoMapperMap()
        {
            Map = CreateMap<TFrom, TTo>();
        }
    }
}