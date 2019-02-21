using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phramd
{
    public class Calendar
    {
        public bool isAddCalendar { get; set; }
        public List<string> summary = new List<string>();
        public List<string> time = new List<string>();
        public List<string> timeFormat = new List<string>();
        public List<string> dateTime = new List<string>();
        public List<string> dateFormat = new List<string>();
        public List<string> calEvents = new List<string>();

        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Phramd";

        public void CalendarSetUp()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    Program.UserDetails.emails,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            DateTime endDate = DateTime.Now.AddDays(5);

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.TimeMax = endDate; 
            request.ShowDeleted = false;
            request.SingleEvents = true;
            //request.MaxResults = 20;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();

            //Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;   
                    }
                    time = when.Split(',').ToList();
                    timeFormat.Add(time[0].Remove(0,10));
                    dateTime.Add(time[0]);
                    dateFormat.Add(time[0].Substring(0,10));
                    summary = eventItem.Summary.Split(',').ToList();
                    calEvents.Add(summary[0]);
                }
            }
        }
    }
}

