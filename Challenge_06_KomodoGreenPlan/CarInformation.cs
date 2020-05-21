using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_KomodoGreenPlan
{
    public enum CarType {Electric, Gas, Hybrid}
    public class CarInformation
    {
        public string CarName { get; set; }
        public CarType CarType { get; set; }
        public string CarDescription { get; set; }


        public CarInformation() { }

        public CarInformation(string carName, CarType carType, string carDescription)
        {
            CarName = carName;
            CarType = carType;
            CarDescription = carDescription;
        }
    }
}
