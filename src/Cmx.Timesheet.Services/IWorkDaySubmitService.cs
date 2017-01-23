using System.Threading.Tasks;
using Cmx.Timesheet.Api.Models;

namespace Cmx.Timesheet.Services
{
    public interface IWorkDaySubmitService
    {
        Task<WorkDayDetailItem> Submit(WorkDaySubmitItem item);
    }
}