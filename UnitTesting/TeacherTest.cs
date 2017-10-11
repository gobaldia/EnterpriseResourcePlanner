using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using System.Collections.Generic;
using DataAccess;
using BusinessLogic.Exceptions;

namespace UnitTesting
{
    [TestClass]
    public class TeacherTest
    {
        [TestMethod]
        public void CreateTeacher()
        {
            Teacher teacher = new Teacher();

            string expectedName = string.Empty;
            string expectedLastName = string.Empty;
            List<Subject> expectedSubjects = new List<Subject>();
            List<Subject> actualSubjects = teacher.GetSubjects();

            Assert.AreEqual(expectedName, teacher.GetName());
            Assert.AreEqual(expectedLastName, teacher.GetLastName());

            this.CompareSubjects(actualSubjects, expectedSubjects);
        }

        [TestMethod]
        public void CreateTeacherWithParameters()
        {
            string expectedName = "Luis";
            string expectedLastName = "Suarez";
            string expectedDocumentNumber = "1234567-8";
            List<Subject> expectedSubjects = new List<Subject>();

            Teacher teacher = new Teacher(expectedName, expectedLastName, expectedDocumentNumber);

            Assert.AreEqual(expectedName, teacher.GetName());
            Assert.AreEqual(expectedLastName, teacher.GetLastName());
            Assert.AreEqual(expectedDocumentNumber, teacher.GetDocumentNumber());

            List<Subject> actualSubjects = teacher.GetSubjects();
            this.CompareSubjects(actualSubjects, expectedSubjects);
        }

        [TestMethod]
        public void TeachersInstancesAreEqual()
        {
            string name = this.GetRandomName();
            string lastName = this.GetRandomLastName();
            string documentNumber = "1234567-8";
            Teacher firstTeacher = new Teacher(name, lastName, documentNumber);
            Teacher secondTeacher = new Teacher(name, lastName, documentNumber);

            Assert.IsTrue(firstTeacher.Equals(secondTeacher));
        }

        [TestMethod]
        public void TeachersInstancesAreNotEqual()
        {
            string name1 = "Edinson";
            string lastName1 = "Cavani";
            string document1 = "1234567-8";

            string name2 = "Luis";
            string lastName2 = "Suarez";
            string document2 = "3216549-8";

            Teacher firstTeacher = new Teacher(name1, lastName1, document1);
            Teacher secondTeacher = new Teacher(name2, lastName2, document2);

            Assert.IsFalse(firstTeacher.Equals(secondTeacher));
        }

        [TestMethod]
        public void GetFullNameCorrectly()
        {
            string name = this.GetRandomName();
            string lastName = this.GetRandomLastName();
            string document = "1234567-8";

            Teacher firstTeacher = new Teacher(name, lastName, document);

            Assert.AreEqual(string.Format("{0} {1}", name, lastName), firstTeacher.GetFullName());
        }

        [TestMethod]
        public void ThrowExceptionOnInvalidDocumentFormat()
        {
            try
            {
                string name = this.GetRandomName();
                string lastName = this.GetRandomLastName();
                string document = "12345678"; // Invalid format

                Teacher firstTeacher = new Teacher(name, lastName, document);
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Invalid document number format."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AddTeacherToSystem()
        {
            SystemData systemData = this.GetNewSystemData();
            List<Teacher> systemTeachers = systemData.GetSystemTeachers();

            Teacher newTeacher = this.CreateRandomTeacher();
            systemTeachers.Add(newTeacher);

            Assert.IsNotNull(this.FindTeacherOnSystem(newTeacher.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateTeacherToSystem()
        {
            try
            {
                SystemData systemData = this.GetNewSystemData();
                List<Teacher> systemTeachers = systemData.GetSystemTeachers();

                Teacher firstTeacher = this.CreateRandomTeacher();
                Teacher secondTeacher = new Teacher(firstTeacher.GetName(), firstTeacher.GetLastName(), firstTeacher.GetDocumentNumber());

                systemData.AddTeacher(firstTeacher);
                systemData.AddTeacher(secondTeacher);
                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Teacher already exists."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #region Extra Methods        
        private SystemData GetNewSystemData()
        {
            SystemData.GetInstance.Reset();
            return SystemData.GetInstance;
        }

        private string[] maleNames = new string[5] { "Alfred", "Tony", "Bart", "Peter", "Jhon" };
        private string[] femaleNames = new string[5] { "Carol", "Jennifer", "Storm", "Leia", "Jessica" };
        private string[] lastNames = new string[5] { "Richards", "Kovacs", "Wayne", "Johnes", "Stark" };
        private string[] documents = new string[5] { "1234567-8", "3216549-8", "7418529-6", "9638527-4", "1596324-7" };

        private void CompareSubjects(List<Subject> real, List<Subject> toBeCompareWith)
        {
            Assert.AreEqual(real.Count, toBeCompareWith.Count);
            for (var index = 0; index < real.Count; index++)
            {
                Assert.AreEqual(real[index], toBeCompareWith[index]);
            }
        }

        private Teacher FindTeacherOnSystem(string documentNumber)
        {
            return SystemData.GetInstance.GetSystemTeachers().Find(x => x.GetDocumentNumber().Equals(documentNumber));
        }

        private Teacher CreateRandomTeacher()
        {
            Teacher newTeacher = new Teacher(this.GetRandomName(), this.GetRandomLastName(), this.GetRandomDocument());
            return newTeacher;
        }

        private string GetRandomName()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            string name = string.Empty;
            if (randomNumber.Next(1, 2) == 1)
                name = maleNames[randomNumber.Next(0, maleNames.Length - 1)];
            else
                name = femaleNames[randomNumber.Next(0, femaleNames.Length - 1)];

            return name;
        }

        private string GetRandomLastName()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            return lastNames[randomNumber.Next(0, lastNames.Length - 1)];
        }

        private string GetRandomDocument()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            return documents[randomNumber.Next(0, documents.Length - 1)];
        }
        #endregion
    }
}
