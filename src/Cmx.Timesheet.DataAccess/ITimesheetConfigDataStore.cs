using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.DomainModel.Configuration;
using Microsoft.Azure.Documents.Client;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetConfigDataStore
    {
        Task<IEnumerable<TimesheetConfigModel>> GetTimesheetConfigurations();

        Task<TimesheetConfigModel> GetTimesheetConfigurationById(Guid timesheetConfigId);
    }

    public class DocumentDbTimesheetConfigDataStore : ITimesheetConfigDataStore
    {
        private static readonly string EndpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string AuthorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseId"];
        private static readonly string CollectionName = "TimesheetConfgurations";
        private DocumentClient _client;

        public Task<IEnumerable<TimesheetConfigModel>> GetTimesheetConfigurations()
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var data = _client.CreateDocumentQuery<TimesheetConfigModel>(uri);

            return Task.FromResult(data.AsEnumerable());
        }

        public Task<TimesheetConfigModel> GetTimesheetConfigurationById(Guid timesheetConfigId)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var data = _client.CreateDocumentQuery<TimesheetConfigModel>(uri)
                              .Where(d => d.Id == timesheetConfigId)
                              .AsQueryable()
                              .FirstOrDefault();

            return Task.FromResult(data);
        }
    }
}
