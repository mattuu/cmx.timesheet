using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.Model;

namespace Cmx.Timesheet.Mappings
{
    //public class TimesheetModelToTimesheetListItemMap : IMap<TimesheetModel, TimesheetListItem>
    //{
    //    public void CreateMap()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public interface IMap<in TFrom, out TTo>
    {
        void CreateMap();
    }

    public abstract class AutoMapperMap<TFrom, TTo> : Profile, IMap<TFrom, TTo>
    {
        private readonly IMapper _mapper;

        protected AutoMapperMap(IMapper mapper)
        {
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper;
        }

        public virtual void CreateMap /*<TFrom, TTo>*/()
        {
            CreateMap<TFrom, TTo>();
        }
    }
}
