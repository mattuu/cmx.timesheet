namespace Cmx.Timesheet.Mappings
{
    public interface IMap<in TFrom, out TTo>
    {
        void CreateMap();
    }
}