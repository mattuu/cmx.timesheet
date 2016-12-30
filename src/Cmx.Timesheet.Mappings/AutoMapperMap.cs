using System;
using AutoMapper;

namespace Cmx.Timesheet.Mappings
{
    public abstract class AutoMapperMap<TFrom, TTo> : Profile, IMap<TFrom, TTo>
    {
        protected AutoMapperMap()
        {

        }

        public virtual void CreateMap()
        {
            base.CreateMap<TFrom, TTo>();
        }
    }
}