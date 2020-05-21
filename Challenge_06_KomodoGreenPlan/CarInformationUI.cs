using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_KomodoGreenPlan
{
    public class CarInformationUI
    {
        private readonly CarInformationRepository _repo = new CarInformationRepository();

        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Add to Car Directory\n" +
                    "2. View Car Directory\n" +
                    "3. Update Car Directory\n" +
                    "4. Delete from Car Directory\n" +
                    "5. Exit");

                string selectMenu = Console.ReadLine();

                switch (selectMenu)
                {
                    case "1":
                        AddCarToDirectory();
                        break;
                    case "2":
                        ViewCarDirectory();
                        break;
                    case "3":
                        UpdateCarDirectory();
                        break;
                    case "4":
                        DeleteCarFromDirectory();
                        break;
                    case "5":
                        continueToRun = false;
                        Console.WriteLine("\nGoodbye, Have a Great Day");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid option");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddCarToDirectory()
        {
            Console.Clear();

            Console.WriteLine("What is the name of the car?\n");
            string carName = Console.ReadLine();

            Console.WriteLine("\nWhat is the type of car?\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid"
                );

            string carTypeChoice = Console.ReadLine();

            CarType carType = CarType.Electric;

            switch (carTypeChoice)
            {
                case "1":
                    carType = CarType.Electric;
                    break;
                case "2":
                    carType = CarType.Gas;
                    break;
                case "3":
                    carType = CarType.Hybrid;
                    break;
                default:
                    Console.WriteLine("\nPlease select a valid option");
                    Console.ReadKey();
                    AddCarToDirectory();
                    break;
            }

            Console.WriteLine("\nPlease write any additional notes that you would like to save on this car. You can update your notes anytime.\n");
            string carDescription = Console.ReadLine();

            CarInformation cars = new CarInformation(carName, carType, carDescription);
            _repo.AddCarToDirectory(cars);
            
            Console.WriteLine("\nThank you for adding a new car the Car Directory!");
            Console.ReadKey();
            RunMenu();
        }

        public void ViewCarDirectory()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Car Directory!\n");

            Console.WriteLine("Which TYPE of car would you like to view?\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid\n" +
                "4. All Types");

            string carTypeChoice = Console.ReadLine();
            ViewCarType(carTypeChoice);
        }

        public void ViewCarType(string userChoice)
        {
            Console.Clear();

            List<CarInformation> carDirectory = _repo.CarInformationForCarType(CarType.Electric);
            switch (userChoice)
            {
                case "1": // electric
                    carDirectory = _repo.CarInformationForCarType(CarType.Electric);
                    break;
                case "2": // gas
                    carDirectory = _repo.CarInformationForCarType(CarType.Gas);
                    break;
                case "3": // hybrid
                    carDirectory = _repo.CarInformationForCarType(CarType.Hybrid);
                    break;
                case "4": // all
                    carDirectory = _repo.ViewCarDirectory();
                    break;
                default:
                    Console.WriteLine("\nPlease select a valid option");
                    Console.ReadKey();
                    ViewCarDirectory();
                    break;
            }

            bool carTypeMatched = false;
            foreach (CarInformation car in carDirectory)
            {
                carTypeMatched = true;
                DisplayContent(car);
            }
            if (!carTypeMatched)
            {
                Console.WriteLine("Sorry, there don't seem to be any cars of that TYPE.");
            }
        }

        public void DisplayContent(CarInformation car)
        {
            Console.WriteLine($"Name: {car.CarName}\n" +
                                $"Car Type: {car.CarType}\n" +
                                $"Car Details: {car.CarDescription}\n\n");
        }

        public void UpdateCarDirectory()
        {
            Console.Clear();

            Console.WriteLine("Please enter the car NAME that you would like to UPDATE.");
            string carName = Console.ReadLine();

            Console.WriteLine("Please select the new car TYPE.\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid");

            string carTypeChoice = Console.ReadLine();

            CarType carType = CarType.Electric;

            switch (carTypeChoice)
            {
                case "1":
                    carType = CarType.Electric;
                    break;
                case "2":
                    carType = CarType.Gas;
                    break;
                case "3":
                    carType = CarType.Hybrid;
                    break;
                default:
                    Console.WriteLine("\nPlease select a valid option");
                    Console.ReadKey();
                    AddCarToDirectory();
                    break;
            }

            Console.WriteLine("Please enter new DETAILS of the car.");
            string carDescription = Console.ReadLine();

            CarInformation newCarName = new CarInformation(carName, carType, carDescription);
            _repo.UpdateCarByCarName(carName, newCarName);

            Console.WriteLine("Thank you for UPDATING the Car Directory");
            Console.ReadKey();
        }

        public bool DeleteCarFromDirectory()
        {
            Console.Clear();
            Console.WriteLine("Please enter the NAME of the car that you would like to remove.");
            string carName = Console.ReadLine();

            foreach (CarInformation car in _repo.ViewCarDirectory())
            {
                if (car.CarName == carName)
                {
                    _repo.DeleteFromCarDirectory(carName);
                    Console.WriteLine("You have sucessfuly deleted the car from the Car Directory!");
                    return true;
                }
                else
                {
                    Console.WriteLine("I'm sorry, the car name you entered doesn't appear to be in the Car Directory. Make sure to double check your spelling.");
                    Console.ReadKey();
                    DeleteCarFromDirectory();
                    return false;
                }
            }
            Console.ReadKey();
            return false;
        }
    }
}
