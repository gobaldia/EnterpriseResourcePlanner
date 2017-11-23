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
using DummyPersistance;
using CoreLogic.Interfaces;
using UnitTesting.Utilities;

namespace UnitTesting
{
    [TestClass]
    public class ActivityTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

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
            var expectedDate = new DateTime(2017, 11, 14);
            var expectedCost = 100;

            Activity activity = new Activity(expectedName, expectedDate, expectedCost);

            Assert.AreEqual(activity.Name, expectedName);
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
            Activity secondActivity = firstActivity;

            Assert.AreEqual(firstActivity, secondActivity);
        }

        [TestMethod]
        public void AddActivityToSystem()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            Activity newActivity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);

            activityOperations.AddActivity(newActivity);

            Assert.IsNotNull(this.FindActivityOnSystem(newActivity.Id));
        }

        private object FindActivityOnSystem(int id)
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();
            List<Activity> activities = activityOperations.GetActivities();
            return activities.Find(x => x.Id == id);
        }

        [TestMethod]
        public void TryToAddActivityThatAlreadyExistsToSystem()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();
            try
            {
                Activity firstActivity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
                Activity secondActivity = firstActivity;

                activityOperations.AddActivity(firstActivity);
                activityOperations.AddActivity(secondActivity);

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
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            activityOperations.AddActivity(activity);

            activity.Name = "Yoga Reloaded";
            activityOperations.ModifyActivityById(activity.Id, activity);

            var modifiedActivity = activityOperations.GetActivityById(activity.Id);
            Assert.AreEqual(modifiedActivity.Name, "Yoga Reloaded");
        }

        [TestMethod]
        public void AssignStudentsToActivity()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            activityOperations.AddActivity(activity);

            var firstStudent = new Student("Jon", "Bon Jovi", "1234567-8");
            var secondStudent = new Student("Jim Morrison", "Varela", "1234567-9");

            var students = new List<Student>();
            students.Add(firstStudent);
            students.Add(secondStudent);

            var newActivity = new Activity(activity.Name, activity.Date, activity.Cost);
            newActivity.Students = students;

            activityOperations.ModifyActivityById(activity.Id, newActivity);

            var modifiedActivity = activityOperations.GetActivityById(activity.Id);

            Assert.AreEqual(modifiedActivity.Students, students);
        }

        [TestMethod]
        public void DeleteActivity()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            activityOperations.AddActivity(activity);

            activityOperations.DeleteActivityById(activity.Id);

            var quantityOfActivities = activityOperations.GetActivities().Count();

            Assert.IsTrue(quantityOfActivities == 0);
        }

        [TestMethod]
        public void TryToDeleteActivityThatDoesntExists()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            try
            {
                activityOperations.DeleteActivityById(1);
                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("There's no activity with this id."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListActivities()
        {
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            var activityOne = new Activity("Yoga", new DateTime(2017, 11, 22), 150);
            var activityTwo = new Activity("Guitar class", new DateTime(2017, 11, 25), 100);

            activityOne.Id = 1;
            activityTwo.Id = 2;

            activityOperations.AddActivity(activityOne);
            activityOperations.AddActivity(activityTwo);

            var activities = activityOperations.GetActivities();

            Assert.IsTrue(activities.Count() == 2);
            Assert.AreEqual(activities[0], activityOne);
            Assert.AreEqual(activities[1], activityTwo);
        }
    }
}
