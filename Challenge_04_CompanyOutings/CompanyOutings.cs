using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04_CompanyOutings
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert}
    public class CompanyOutings
    {
        public string EventName {get;set;}
        public EventType EventType { get; set; }
        public int EventAttendence { get; set; }
        public string EventDate { get; set; }
        public double TotalCostPerAttendee { get; set; }
        public double TotalCostPerEvent { get; set; }


        public CompanyOutings() { }

        public CompanyOutings(string eventName, EventType eventType, int eventAttendence, string eventDate, double totalCostPerAttendee, double totalCostPerEvent)
        {
            EventName = eventName;
            EventType = eventType;
            EventAttendence = eventAttendence;
            EventDate = eventDate;
            TotalCostPerAttendee = totalCostPerAttendee;
            TotalCostPerEvent = totalCostPerEvent;
        }
    }
}
