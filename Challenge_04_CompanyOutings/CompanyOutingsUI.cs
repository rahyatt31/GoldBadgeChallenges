using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04_CompanyOutings
{

    public class CompanyOutingsUI
    {
        private readonly CompanyOutingsRepository _repo = new CompanyOutingsRepository();
        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {

            Console.WindowWidth = 140;

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. View List of Company Outings\n" +
                    "2. Add Event to Company Outings\n" +
                    "3. Exit"
                    );

                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        ViewCompanyOutingsList();
                        break;
                    case "2":
                        AddCompanyOutingToList();
                        break;
                    case "3":
                        continueToRun = false;
                        Console.WriteLine("Have a Great Day, see you at the next event!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please selection a valid option.");
                        break;
                }
                        Console.ReadKey();
                        Console.Clear();
            }
        }

        public void ViewCompanyOutingsList()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of past and upcoming events!");
            Console.ReadKey();

            string formatString = "{0,-40} | {1,-15} | {2,10} | {3,15} | {4,20} | {5,10} |";
            Console.WriteLine(String.Format(formatString , "Event Name" , "Type" , "Attendance" , "Date" , "Cost per Person" , "Total Cost"));

            List<CompanyOutings> companyOutingsList = _repo.ViewOutingsList();


            foreach (CompanyOutings companyOutings in companyOutingsList)
            { 
                string eventName = NameForEventType(companyOutings.EventType);
                Console.WriteLine(String.Format(formatString , $"{companyOutings.EventName}" , $"{eventName}" , $"{Convert.ToString(companyOutings.EventAttendence)}" , $"{companyOutings.EventDate}" , $"${Convert.ToString(companyOutings.TotalCostPerAttendee)}" , $" ${Convert.ToString(companyOutings.TotalCostPerEvent)}"));
            }
            DisplayTotalCostOfAllEvents();
            TotalCostByEvent();
        }

        public void DisplayTotalCostOfAllEvents()
        {
            Console.WriteLine("\n\nWould you like to view the TOTAL COST of all events?");
            Console.WriteLine("1. Yes\n" + "2. No");

            string viewTotalCost = Console.ReadLine();
            double costOfAllEvents = _repo.GetTotalCostOfEvents();

            switch (viewTotalCost)
            {
                case "1":
                    Console.WriteLine($"The TOTAL COST of all Company Outings is ${costOfAllEvents}");
                    break;
                case "2":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    ViewCompanyOutingsList();
                    break;
            }
        }

        public void TotalCostByEvent()
        {
            Console.WriteLine("\n\nWould you like to view the TOTAL COST by event type?");
            Console.WriteLine(
                "1. Golf Events\n" +
                "2. Bowling Events\n" +
                "3. Amusement Park Events\n" +
                "4. Concert Events\n" +
                "5. No, return to the Menu");
        
            string viewTotalCostByEvent = Console.ReadLine();

            switch (viewTotalCostByEvent)
            {
                case "1":
                    double totalCostOfGolfEvents = _repo.GetTotalCostEventsByType(EventType.Golf);
                    Console.WriteLine($"The TOTAL COST of all Golf events is ${totalCostOfGolfEvents}");
                    break;
                case "2":
                    double totalCostOfBowlingEvents = _repo.GetTotalCostEventsByType(EventType.Bowling);
                    Console.WriteLine($"The TOTAL COST of all Bowling events is ${totalCostOfBowlingEvents}");
                    break;
                case "3":
                    double totalCostOfAmusementParkEvents = _repo.GetTotalCostEventsByType(EventType.AmusementPark);
                    Console.WriteLine($"The TOTAL COST of all Amusement Park events is ${totalCostOfAmusementParkEvents}");
                    break;
                case "4":
                    double totalCostOfConcertEvents = _repo.GetTotalCostEventsByType(EventType.Concert);
                    Console.WriteLine($"The TOTAL COST of all Concert events is ${totalCostOfConcertEvents}");
                    break;
                case "5":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }

        public void AddCompanyOutingToList()
        {
            Console.Clear();

            Console.WriteLine("Please enter the NAME of the event you want to add to the list of Company Outings");
            string eventName = Console.ReadLine();

            Console.WriteLine("Please select the EVENT TYPE");
            Console.WriteLine(
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            
            string eventTypeChoice = Console.ReadLine();

            EventType eventType = EventType.Golf;

            switch (eventTypeChoice)
            {
                case "1":
                    eventType = EventType.Golf;
                    break;
                case "2":
                    eventType = EventType.Bowling;
                    break;
                case "3":
                    eventType = EventType.AmusementPark;
                    break;
                case "4":
                    eventType = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    AddCompanyOutingToList();
                    break;
            }

            Console.WriteLine("Please enter the ATTENDENCE for the event");
            int eventAttendence = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the DATE of the event (Month, Day, Year)(Ex. June 3 2020)");
            string eventDate = Console.ReadLine();

            Console.WriteLine("Please enter the COST for one person to attend this event");
            double eventCost = Convert.ToDouble(Console.ReadLine());

            double eventTotalCost = (eventAttendence * eventCost);

            CompanyOutings outings = new CompanyOutings(eventName, eventType, eventAttendence, eventDate, eventCost, eventTotalCost);
            _repo.AddToOutingsList(outings);

            Console.WriteLine("Thank you for adding an event to the list of Company Outings!");
            Console.ReadKey();
            RunMenu();
        }

        public string NameForEventType(EventType eventType)             // Changing an event type to a string
        {
            string eventName = "";
            switch (eventType)
            {
                case EventType.Golf:
                    eventName = "Golf";
                    break;
                case EventType.Bowling:
                    eventName = "Bowling";
                    break;
                case EventType.AmusementPark:
                    eventName = "Amusement Park";
                    break;
                case EventType.Concert:
                    eventName = "Concert";
                    break;
            }
            return eventName;
        }
    }
}
