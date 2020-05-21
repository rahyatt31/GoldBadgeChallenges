using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04_CompanyOutings
{
    public class CompanyOutingsRepository
    {
        private List<CompanyOutings> _outingsList = new List<CompanyOutings>();

        public void AddToOutingsList(CompanyOutings item)
        {
            _outingsList.Add(item);
        }

        public List<CompanyOutings> ViewOutingsList()
        {
            return _outingsList;
        }

        public double GetTotalCostOfEvents()
        {
            double totalCostOfEvents = 0;
            foreach (CompanyOutings thisEvent in _outingsList)
            {
                totalCostOfEvents += thisEvent.TotalCostPerAttendee * thisEvent.EventAttendence;                
            }
            return totalCostOfEvents;
        }

        public double GetTotalCostEventsByType(EventType eventType)
        {
            double totalCostOfEventsByType = 0;
            foreach (CompanyOutings thisEvent in _outingsList)
            {
                if (thisEvent.EventType == eventType)
                {
                    totalCostOfEventsByType += thisEvent.TotalCostPerAttendee * thisEvent.EventAttendence;
                }
            }
            return totalCostOfEventsByType;
        }

        public List<CompanyOutings> GetEventType()
        {
            List<CompanyOutings> GetEventType = new List<CompanyOutings>();
            foreach (CompanyOutings content in _outingsList)
            {
                if (content.EventType == EventType.Golf)
                {
                    GetEventType.Add(content);
                }
            }
            return GetEventType;
        }

    }
}
