using System;
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
            var expectedDate = new DateTime(2017, 17, 11, 10, 0, 0);
            var expectedCost = 100;

            Activity activity = new Activity();
            activity.Name = expectedName;
            activity.Id = expectedId;
            activity.Date = expectedDate;
            activity.Cost = expectedCost;

            Assert.AreEqual(activity.Name = expectedName);
            Assert.AreEqual(activity.Id = expectedId);
            Assert.AreEqual(activity.Date = expectedDate);
            Assert.AreEqual(activity.Cost = expectedCost);
        }
    }
}
