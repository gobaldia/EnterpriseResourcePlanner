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
using CoreLogic;

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
            var expectedDate = new DateTime(2017, 11, 14);
            var expectedCost = 100;

            Activity activity = new Activity();
            activity.Name = expectedName;
            activity.Id = expectedId;
            activity.Date = new DateTime(2017, 11, 14);
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
            var expectedDate = new DateTime(2017, 11, 14);
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
            var expectedDate = new DateTime(2017, 11, 14);
            var expectedCost = 100;

            Activity firstActivity = new Activity(expectedName, expectedDate, expectedCost);
            Activity secondActivity = new Activity(expectedName, expectedDate, expectedCost);

            Assert.AreEqual(firstActivity, secondActivity);
        }

        [TestMethod]
        public void AddActivityToSystem()
        {
            SystemData.GetInstance.Reset();

            Activity newActivity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);

            ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(newActivity);

            Assert.IsNotNull(this.FindActivityOnSystem(newActivity.Id));
        }

        private object FindActivityOnSystem(int id)
        {
            List<Activity> activities = ClassFactory.GetOrCreate<ActivityLogic>().GetActivities();
            return activities.Find(x => x.Id == id);
        }

        [TestMethod]
        public void TryToAddActivityThatAlreadyExistsToSystem()
        {
            try
            {
                Activity firstActivity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
                Activity secondActivity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);

                ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(firstActivity);
                ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(secondActivity);

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

        [TestMethod]
        public void ModifyActivity()
        {
            SystemData.GetInstance.Reset();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(activity);

            activity.Name = "Yoga Reloaded";
            ClassFactory.GetOrCreate<ActivityLogic>().ModifyActivityById(activity.Id, activity);

            var modifiedActivity = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityByCode(activity.Id);
            Assert.AreEqual(modifiedActivity.GetName(), "Yoga Reloaded");
        }

    }
}
