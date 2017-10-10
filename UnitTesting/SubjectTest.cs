using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class SubjectTest
    {
        [TestMethod]
        public void CreateSubjectWithoutParameters()
        {
            Subject subject = new Subject();

            int expectedCode = 0;
            string expectedName = string.Empty;
            List<Student> expectedStudents = new List<Student>();
            List<Teacher> expectedTeachers = new List<Teacher>();

            Assert.AreEqual(expectedCode, subject.Code);
            Assert.AreEqual(expectedName, subject.Name);
            this.CompareListsOfStudents(expectedStudents, subject.Students);
            this.CompareListsOfTeachers(expectedTeachers, subject.Teachers);
        }

        [TestMethod]
        public void CreateSubjectWithParameters()
        {
            int expectedCode = 100;
            string expectedName = "Diseno de Aplicaciones";
            List<Student> expectedStudents = new List<Student>();
            List<Teacher> expectedTeachers = new List<Teacher>();

            Subject subject = new Subject(expectedCode, expectedName);

            Assert.AreEqual(expectedCode, subject.Code);
            Assert.AreEqual(expectedName, subject.Name);
            this.CompareListsOfStudents(expectedStudents, subject.Students);
            this.CompareListsOfTeachers(expectedTeachers, subject.Teachers);
        }

        [TestMethod]
        public void SubjectInstancesAreEqual()
        {
            int expectedCode = 100;
            string expectedName = "Diseno de Aplicaciones";
            List<Student> expectedStudents = new List<Student>();
            List<Teacher> expectedTeachers = new List<Teacher>();

            Subject firstSubject = new Subject(100, "Diseno de Aplicaciones");
            Subject secondSubject = new Subject(100, "Diseno de Aplicaciones");

            Assert.IsTrue(firstSubject.Equals(secondSubject));
        }


        #region Extra Methods
        private void CompareListsOfStudents(List<Student> real, List<Student> toBeCompareWith)
        {
            Assert.AreEqual(real.Count, toBeCompareWith.Count);
            for (var index = 0; index < real.Count; index++)
            {
                Assert.AreEqual(real[index], toBeCompareWith[index]);
            }
        }
        private void CompareListsOfTeachers(List<Teacher> real, List<Teacher> toBeCompareWith)
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
