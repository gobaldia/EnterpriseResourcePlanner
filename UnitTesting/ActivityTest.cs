using System;
using CoreEntities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class ActivityTest
    {
        [TestMethod]
        public void CreateActivity()
        {
            var expectedName = "Yoga";
            var expectedId = 1;
            var expectedDate = "12/11/2017";
            var expectedCost = 100;

            Activity activity = new Activity();
            activity.Name = expectedName;
            activity.Id = expectedId;
            activity.Date = expectedDate;
            activity.Cost = expectedCost;

            Assert.AreEqual(activity.Name, expectedName);
            Assert.AreEqual(activity.Id, expectedId);
            Assert.AreEqual(activity.Date, expectedDate);
            Assert.AreEqual(activity.Cost, expectedCost);
        }

        [TestMethod]
        public void CreateActivityWithParameters()
        {
            var expectedName = "Yoga";
            var expectedId = 1;
            var expectedDate = "12/11/2017";
            var expectedCost = 100;

            Activity activity = new Activity(expectedName, expectedId, expectedDate, expectedCost);

            Assert.AreEqual(activity.Name, expectedName);
            Assert.AreEqual(activity.Id, expectedId);
            Assert.AreEqual(activity.Date, expectedDate);
            Assert.AreEqual(activity.Cost, expectedCost);
        }

        [TestMethod]
        public void ActivityInstancesAreEqual()
        {
            var expectedName = "Yoga";
            var expectedId = 1;
            var expectedDate = "12/11/2017";
            var expectedCost = 100;

            Activity firstActivity = new Activity(expectedName, expectedId, expectedDate, expectedCost);
            Activity secondActivity = new Activity(expectedName, expectedId, expectedDate, expectedCost);

            Assert.AreEqual(firstActivity, secondActivity);
        }
    }
}
