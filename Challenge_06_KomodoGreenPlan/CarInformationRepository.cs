using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_KomodoGreenPlan
{
    public class CarInformationRepository
    {
        private List<CarInformation> _carDirectory = new List<CarInformation>();

        public void AddCarToDirectory(CarInformation item)                  // CREATE
        {
            _carDirectory.Add(item);
        }

        public List<CarInformation> ViewCarDirectory()                      // READ
        {
            return _carDirectory;
        }

        public CarInformation ViewCarDirectoryByCarName(string carName)         // READ
        {
            foreach (CarInformation car in _carDirectory)
            {
                if (car.CarName.ToLower() == carName.ToLower())
                {
                    return car;
                }
            }
            return null;
        }

        public List<CarInformation> CarInformationForCarType(CarType carType)
        {
            List<CarInformation> carsMatchingType = new List<CarInformation>();

            foreach (CarInformation car in _carDirectory)
            {
                if (car.CarType == carType)
                {
                    carsMatchingType.Add(car);
                }
            }
            return carsMatchingType;
        }

        public bool UpdateCarByCarName(string carName, CarInformation newCar) // UPDATE Using a bool, because if we try to update content that isn't there then we want it to be able to tell us FALSE
        {
            CarInformation car = ViewCarDirectoryByCarName(carName); // We are using a Method we created (GCBT)(lines 35-44) to grab the title content we want

            if (car == null) // If we can't find content then return false
            {
                return false;
            }
            else
            {
                car.CarName = newCar.CarName;
                car.CarType = newCar.CarType;
                car.CarDescription = newCar.CarDescription;
                return true;
            }
        }

        public bool DeleteFromCarDirectory(string carName)                   // Remove
        {
            CarInformation car = ViewCarDirectoryByCarName(carName);

            if (car == null)
            {
                return false;
            }
            else
            {
                _carDirectory.Remove(car);
                return true;
            }
        }
    }
}
