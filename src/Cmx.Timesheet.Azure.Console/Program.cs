using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Cmx.Timesheet.Api;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Microsoft.Azure.Documents.Client;
using Microsoft.Practices.Unity;

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
            var container = new UnityContainer();
            _documentCollectionOrDatabaseUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);

            UnityConfig.RegisterComponents(container);
            var dataStore = container.Resolve<ITimesheetDataStore>();

            System.Console.WriteLine("RUNNING...");

            //var timesheets = dataStore.GetTimesheets().Result;
            //foreach (var timesheet in  timesheets)
            //{
            //    System.Console.WriteLine(timesheet.Id);
            //}

            var model = new TimesheetCreateModel
            {
                CreatedBy = "VS",
                CreatedOn = DateTime.Now,
                StartDate = new DateTime(2016, 8, 8),
                EndDate = new DateTime(2016, 8, 12),
                WorkDays = new[]
                {
                    new WorkDayModel()
                    {
                        Date = new DateTime(2016, 8, 8),
                        StartTime = new TimeSpan(7, 30, 0),
                        EndTime = new TimeSpan(16, 30, 0)
                    }
                }
            };

            var newModel = dataStore.CreateTimesheet(model).Result;

            var ts = dataStore.GetTimesheetById(newModel.Id).Result;

            System.Console.WriteLine(ts.Id);
            System.Console.WriteLine(ts.CreatedOn);
            System.Console.WriteLine(ts.CreatedBy);
            System.Console.WriteLine(ts.Status);


            System.Console.WriteLine("FINISHING...");

            System.Console.ReadLine();
        }
    }
}