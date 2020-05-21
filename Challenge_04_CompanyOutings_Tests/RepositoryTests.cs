using System;
using Challenge_04_CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_04_CompanyOutings_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private CompanyOutingsRepository _repo = new CompanyOutingsRepository();
       
        [TestMethod]
        public void AddToOutingListsTest()
        {
            CompanyOutings masters = new CompanyOutings("Masters", EventType.Golf, 1000, "June 3 2020", 1200, 300000);
            _repo.AddToOutingsList(masters);

            int expect = 1;
            int actual = _repo.ViewOutingsList().Count;
            Assert.AreEqual(expect, actual);
        }
        /*
        [TestMethod]
        public void ViewOutingsListTest()
        {
            CompanyOutings masters = new CompanyOutings("Masters", EventType.Golf, 1000, DateTime.Now, 1200, 300000);
            _repo.AddToOutingsList(masters);

            CompanyOutings viewOutings = _repo.ViewOutingsList("Masters");

        } */
    }
}
