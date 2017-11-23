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
using CoreLogic.Interfaces;
using DummyPersistance;
using UnitTesting.Utilities;

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
                Activity secondActivity = firstActivity;

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

            var modifiedActivity = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activity.Id);
            Assert.AreEqual(modifiedActivity.Name, "Yoga Reloaded");
        }

        [TestMethod]
        public void AssignStudentsToActivity()
        {
            SystemData.GetInstance.Reset();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(activity);

            var firstStudent = new Student("Jon", "Bon Jovi", "1234567-8");
            var secondStudent = new Student("Jim Morrison", "Varela", "1234567-9");

            var students = new List<Student>();
            students.Add(firstStudent);
            students.Add(secondStudent);

            var newActivity = new Activity(activity.Name, activity.Date, activity.Cost);
            newActivity.Students = students;

            ClassFactory.GetOrCreate<ActivityLogic>().ModifyActivityById(activity.Id, newActivity);

            var modifiedActivity = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activity.Id);

            Assert.AreEqual(modifiedActivity.Students, students);
        }

        [TestMethod]
        public void DeleteActivity()
        {
            SystemData.GetInstance.Reset();

            var activity = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            ClassFactory.GetOrCreate<ActivityLogic>().AddActivity(activity);

            ClassFactory.GetOrCreate<ActivityLogic>().DeleteActivityById(activity.Id);

            var quantityOfActivities = ClassFactory.GetOrCreate<ActivityLogic>().GetActivities().Count();

            Assert.IsTrue(quantityOfActivities == 0);
        }

        [TestMethod]
        public void TryToDeleteActivityThatDoesntExists()
        {
            SystemData.GetInstance.Reset();

            try
            {
                ClassFactory.GetOrCreate<ActivityLogic>().DeleteActivityById(1);
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
    }
}
