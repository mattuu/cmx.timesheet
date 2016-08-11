using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Cmx.Timesheet.DataAccess
{
    public class DocumentDbWorkDayDataStore : IWorkDayDataStore
    {
        private static readonly string EndpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string AuthorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseId"];
        private const string CollectionName = "WorkDays";
        private DocumentClient _client;

        public Task<IEnumerable<WorkDayModel>> GetWorkDaysByTimesheetId(Guid timesheetId)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var data = _client.CreateDocumentQuery<WorkDayModel>(uri)
                              .Where(wd => wd.TimesheetId == timesheetId)
                              .AsEnumerable();

            return Task.FromResult(data);
        }

        public Task<bool> SaveWorkDay(WorkDayModel workDayModel)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var task = _client.UpsertDocumentAsync(uri, workDayModel);

            return Task.Factory.FromAsync(task, result =>
            {
                if (result.IsCompleted)
                {
                    var t = result as Task<ResourceResponse<Document>>;
                    return t != null;
                }
                return false;
            });
        }
    }
}