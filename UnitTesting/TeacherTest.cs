using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using System.Collections.Generic;

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

            Assert.AreEqual(actualSubjects.Count, expectedSubjects.Count);
            for (var index = 0; index < actualSubjects.Count; index++)
            {
                Assert.AreEqual(actualSubjects[index], actualSubjects[index]);
            }
        }
    }
}
