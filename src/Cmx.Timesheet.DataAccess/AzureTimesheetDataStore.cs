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
    public class AzureTimesheetDataStore : ITimesheetDataStore
    {
        private static DocumentClient _client;
        private static readonly string EndpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string AuthorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseId"];
        private static readonly string CollectionName = ConfigurationManager.AppSettings["CollectionId"];

        private static readonly ConnectionPolicy ConnectionPolicy = new ConnectionPolicy
        {
            UserAgentSuffix = " samples-net/3"
        };

        private readonly Uri _documentCollectionOrDatabaseUri;

        public AzureTimesheetDataStore()
        {
            _documentCollectionOrDatabaseUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
        }

        public Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            using (_client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey, ConnectionPolicy))
            {
                //CreateNewDatabaseAsync().Wait();
                //RunCollectionDemo().Wait();
                //_client.CreateDocumentCollectionAsync()

                var timesheetModels = _client.CreateDocumentQuery<TimesheetModel>(_documentCollectionOrDatabaseUri)
                                             .AsEnumerable();
                return Task.FromResult(timesheetModels);
            }
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> GetTimesheetById(int timesheetId)
        {
            using (_client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey, ConnectionPolicy))
            {
                //CreateNewDatabaseAsync().Wait();
                //RunCollectionDemo().Wait();
                //_client.CreateDocumentCollectionAsync()

                var uri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, "${timesheetId}");
                var task = _client.ReadDocumentAsync(uri);

                var data = task.Result;
                //var response = task.Result.;

                return Task.FromResult(new TimesheetModel());
            }
        }

        public TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel)
        {
            throw new NotImplementedException();
        }

        public TimesheetModel InsertTimesheet(TimesheetModel timesheetModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteTimesheet(int timesheetId)
        {
            throw new NotImplementedException();
        }
    }
}