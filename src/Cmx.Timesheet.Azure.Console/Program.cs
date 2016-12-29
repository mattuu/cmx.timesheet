using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Cmx.Timesheet.Api;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Microsoft.Azure.Documents.Client;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cmx.Timesheet.Azure.Console
{
    class Program
    {
        private static DocumentClient _client;
        private static readonly string EndpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string AuthorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseId"];
        private static readonly string CollectionName = ConfigurationManager.AppSettings["CollectionId"];
        private static Uri _documentCollectionOrDatabaseUri;

        static void Main(string[] args)
        {
            ConfigureJsonSerializer();

            var container = new UnityContainer();
            _documentCollectionOrDatabaseUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);

            Api.UnityConfig.RegisterComponents(container);
            var dataStore = container.Resolve<ITimesheetDataStore>();

            System.Console.WriteLine("RUNNING...");
            System.Console.WriteLine("GET ALL:");

            var timesheets = dataStore.GetTimesheets().Result;
            foreach (var timesheet in timesheets)
            {
                System.Console.WriteLine(timesheet.Id);
                System.Console.WriteLine(timesheet.CreatedOn);
                System.Console.WriteLine(timesheet.CreatedBy);
            }

            System.Console.WriteLine("CREATING...");

            var model = new TimesheetModel
            {
                CreatedBy = "VS",
                CreatedOn = DateTime.Now,
                StartDate = new DateTime(2016, 8, 8),
                EndDate = new DateTime(2016, 8, 12),
                //WorkDays = new[]
                //{
                //    new WorkDayModel()
                //    {
                //        Date = new DateTime(2016, 8, 8),
                //        StartTime = new TimeSpan(7, 30, 0),
                //        EndTime = new TimeSpan(16, 30, 0)
                //    }
                //}
            };

            var newModel = dataStore.CreateTimesheet(model).Result;


            var ts = dataStore.GetTimesheetById(newModel.Id ?? new Guid()).Result;

            System.Console.WriteLine("CREATED:");
            System.Console.WriteLine(ts.Id);
            System.Console.WriteLine(ts.CreatedOn);
            System.Console.WriteLine(ts.CreatedBy);
            System.Console.WriteLine(ts.Status);


            System.Console.WriteLine("...");
            System.Console.WriteLine("UPDATING STATUS...");

            var updateModel = ts;
            updateModel.Status = TimesheetStatus.Submitted;
            updateModel.TotalHours = 120.5M;

            var isUpdated = dataStore.UpdateTimesheet(updateModel).Result;
            System.Console.WriteLine("UPDATED:");
            System.Console.WriteLine(isUpdated);

            ts = dataStore.GetTimesheetById(updateModel.Id ?? new Guid()).Result;

            System.Console.WriteLine(ts.Id);
            System.Console.WriteLine(ts.Status);


            System.Console.WriteLine("FINISHING...");

            System.Console.ReadLine();
        }

        private static void ConfigureJsonSerializer()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}