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
        private DocumentClient _client;
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
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var data = _client.CreateDocumentQuery<TimesheetModel>(_documentCollectionOrDatabaseUri);

            return Task.FromResult(data.AsEnumerable());
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey, ConnectionPolicy);

            var uri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, $"{timesheetId}");
            var task = _client.ReadDocumentAsync(uri);

            return Task.Factory.FromAsync(task, result =>
            {
                if (result.IsCompleted)
                {
                    var t = result as Task<ResourceResponse<Document>>;
                    var doc =  t?.Result?.Resource;
                    if (doc != null)
                    {
                        return new TimesheetModel
                        {
                            Id = Guid.Parse(doc.Id),
                            CreatedOn = doc.GetPropertyValue<DateTime>("CreatedOn"),
                            CreatedBy = doc.GetPropertyValue<string>("CreatedBy"),
                            Status = doc.GetPropertyValue<TimesheetStatus>("Status")
                        };
                    }

                }
                return null;
            });
        }

        public TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> CreateTimesheet(TimesheetCreateModel timesheetCreateModel)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey, ConnectionPolicy);
            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);

            var task = _client.CreateDocumentAsync(uri, timesheetCreateModel);

            return Task.Factory.FromAsync(task, result =>
            {
                if (result.IsCompleted)
                {
                    var t = result as Task<ResourceResponse<Document>>;
                    var doc = t?.Result?.Resource;
                    if (doc != null)
                    {
                        return new TimesheetModel()
                        {
                            Id = Guid.Parse(doc.Id),
                            CreatedOn = doc.GetPropertyValue<DateTime>("CreatedOn"),
                            CreatedBy = doc.GetPropertyValue<string>("CreatedBy"),
                            Status = doc.GetPropertyValue<TimesheetStatus>("Status")
                        };
                    }

                }
                return null;
            });
        }

        public void DeleteTimesheet(int timesheetId)
        {
            throw new NotImplementedException();
        }
    }
}