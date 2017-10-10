using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using System.Collections.Generic;
using DataAccess;

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
            string name = "Luis";
            string lastName = "Suarez";
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
            string name = "Edinson";
            string lastName = "Cavani";
            string document = "1234567-8";

            Teacher firstTeacher = new Teacher(name, lastName, document);

            Assert.AreEqual(string.Format("{0} {1}", name, lastName), firstTeacher.GetFullName());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid document number format.")]
        public void ThrowExceptionOnInvalidDocumentFormat()
        {
            string name = "Edinson";
            string lastName = "Cavani";
            string document = "12345678"; // Invalid format

            Teacher firstTeacher = new Teacher(name, lastName, document);
        }

        [TestMethod]
        public void AddTeacherToTheSystem()
        {
            var systemData = SystemData.GetInstance;
            var teachers = systemData.GetSystemTeachers();

            Teacher newTeacher = new Teacher("Luis", "Suarez", "1234567-8");
            teachers.Add(newTeacher);

            Assert.IsNotNull(teachers.Find(x => x.GetDocumentNumber() == newTeacher.GetDocumentNumber()));
        }

        #region Extra Methods
        
        private void CompareSubjects(List<Subject> real, List<Subject> toBeCompareWith)
        {
            Assert.AreEqual(real.Count, toBeCompareWith.Count);
            for (var index = 0; index < real.Count; index++)
            {
                Assert.AreEqual(real[index], toBeCompareWith[index]);
            }
        }

        
        #endregion
    }
}
