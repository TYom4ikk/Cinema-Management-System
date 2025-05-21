using CinemaManagementSystem.View;
using CinemaManagementSystem.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaManagementSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsLastNameEmptyTest_1()
        {
            AddStaffPageViewModel model = new AddStaffPageViewModel();
            var result = model.IsLastNameEmpty("Смирнов");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void IsLastNameEmptyTest_2()
        {
            AddStaffPageViewModel model = new AddStaffPageViewModel();
            var result = model.IsLastNameEmpty("");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void IsFirstNameEmptyTest_1()
        {
            AddStaffPageViewModel model = new AddStaffPageViewModel();
            var result = model.IsFirstNameEmpty("Илья");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void IsFirstNameEmptyTest_2()
        {
            AddStaffPageViewModel model = new AddStaffPageViewModel();
            var result = model.IsFirstNameEmpty("");
            Assert.AreEqual(result, true);
        }
    }
}
