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
    public class DocumentDbTimesheetDataStore : ITimesheetDataStore
    {
        private static readonly string EndpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string AuthorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseId"];
        private const string CollectionName = "Timesheets";
        private DocumentClient _client;

        public Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var data = _client.CreateDocumentQuery<TimesheetModel>(uri);

            return Task.FromResult(data.AsEnumerable());
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, $"{timesheetId}");
            var task = _client.ReadDocumentAsync(uri);

            return Task.Factory.FromAsync(task, result =>
            {
                if (result.IsCompleted)
                {
                    var t = result as Task<ResourceResponse<Document>>;
                    var doc = t?.Result?.Resource;
                    if (doc != null)
                    {
                        return new TimesheetModel
                        {
                            Id = Guid.Parse(doc.Id),
                            StartDate = doc.GetPropertyValue<DateTime>("startDate"),
                            EndDate = doc.GetPropertyValue<DateTime>("endDate"),
                            CreatedOn = doc.GetPropertyValue<DateTime>("createdOn"),
                            CreatedBy = doc.GetPropertyValue<string>("createdBy"),
                            Status = doc.GetPropertyValue<TimesheetStatus>("status")
                        };
                    }
                }
                return null;
            });
        }

        public Task<bool> UpdateTimesheetStatus(TimesheetModel model)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var task = _client.UpsertDocumentAsync(uri, model);

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

        public Task<TimesheetModel> CreateTimesheet(TimesheetModel timesheetCreateModel)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);

            var task = _client.CreateDocumentAsync(uri, timesheetCreateModel);

            return Task.Factory.FromAsync<TimesheetModel>(task, result =>
            {
                if (result.IsCompleted)
                {
                    var t = result as Task<ResourceResponse<Document>>;
                    var doc = t?.Result?.Resource;
                    if (doc != null)
                    {
                        return new TimesheetModel
                        {
                            Id = Guid.Parse(doc.Id),
                            CreatedOn = doc.GetPropertyValue<DateTime>("createdOn"),
                            CreatedBy = doc.GetPropertyValue<string>("createdBy"),
                            Status = doc.GetPropertyValue<TimesheetStatus>("status")
                        };
                    }
                }
                return null;
            });
        }

        public Task<bool> DeleteTimesheet(Guid timesheetId)
        {
            _client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

            var uri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, $"{timesheetId}");
            var task = _client.DeleteDocumentAsync(uri);

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