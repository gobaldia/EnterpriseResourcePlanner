using System;
using CoreEntities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using FrameworkCommon;
using CoreEntities.Exceptions;

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

        [TestMethod]
        public void AddActivityToSystem()
        {
            SystemData.GetInstance.Reset();

            Activity newActivity = new Activity("Yoga", 1, "13/11/2017", 100);

            ClassFactory.GetOrCreate<ActivityLogic>().AddSubject(newActivity);

            Assert.IsNotNull(this.FindActivityOnSystem(newActivity.Id));
        }

        [TestMethod]
        public void TryToAddActivityThatAlreadyExistsToSystem()
        {
            try
            {
                Activity firstActivity = new Activity("Yoga", 1, "13/11/2017", 100);
                Activity secondActivity = new Activity("Yoga", 1, "13/11/2017", 100);

                ClassFactory.GetOrCreate<ActivityLogic>().AddSubject(firstActivity);
                ClassFactory.GetOrCreate<ActivityLogic>().AddSubject(secondActivity);

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Activity already exists."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
