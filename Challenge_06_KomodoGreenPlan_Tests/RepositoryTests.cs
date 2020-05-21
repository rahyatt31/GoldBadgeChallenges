using System;
using System.Collections.Generic;
using Challenge_06_KomodoGreenPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_06_KomodoGreenPlan_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private CarInformationRepository _repo = new CarInformationRepository();            // We are testing the repository

        [TestMethod]
        public void AddToMenuListTest()
        {
            CarInformation tesla = new CarInformation("Tesla", CarType.Electric, "Electric");
            CarInformation fiat = new CarInformation("Fiat", CarType.Gas, "Gas");

            _repo.AddCarToDirectory(tesla);
            _repo.AddCarToDirectory(fiat);

            int expected = 2;
            int actual = _repo.ViewCarDirectory().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ViewMenuTest()
        {
            CarInformation tesla = new CarInformation("Tesla", CarType.Electric, "Electric");
            _repo.AddCarToDirectory(tesla);

            CarInformation viewCarInformation = _repo.ViewCarDirectoryByCarName("Tesla");

            Assert.AreEqual(tesla, viewCarInformation);
        }

        [TestMethod]
        public void UpdateCarInformationTest()
        {
            CarInformation tesla = new CarInformation("Tesla", CarType.Electric, "Electric");
            _repo.AddCarToDirectory(tesla);

            CarInformation newCar = new CarInformation("Tesla", CarType.Gas, "Gas");
            _repo.UpdateCarByCarName("Tesla", newCar);

            string expected = ("Tesla");
            string actual = _repo.ViewCarDirectoryByCarName("Tesla").CarName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteCarFromCarDirectoryTest()
        {
            CarInformation tesla = new CarInformation("Tesla", CarType.Electric, "Electric");
            CarInformation fiat = new CarInformation("Fiat", CarType.Gas, "Gas");
            _repo.AddCarToDirectory(tesla);
            _repo.AddCarToDirectory(fiat);

            _repo.DeleteFromCarDirectory("Tesla");
            int expected = 1;
            int actual = _repo.ViewCarDirectory().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}