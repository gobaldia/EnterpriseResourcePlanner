using CoreEntities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Utilities;

namespace UnitTesting
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CreateStudent()
        {
            Student student = new Student();

            string expectedName = string.Empty;
            string expectedLastName = string.Empty;
            int expectedStudentNumber = 1;
            List<Subject> expectedSubjects = new List<Subject>();
            List<Subject> actualSubjects = student.GetSubjects();

            Assert.AreEqual(expectedName, student.GetName());
            Assert.AreEqual(expectedLastName, student.GetLastName());
            Assert.AreEqual(expectedStudentNumber, student.GetStudentNumber());

            Assert.IsTrue(Utility.CompareLists(actualSubjects, expectedSubjects));
        }

        [TestMethod]
        public void CreateStudentWithParameters()
        {
            string expectedName = "Luis";
            string expectedLastName = "Suarez";
            string expectedDocumentNumber = "1234567-8";
            int expectedStudentNumber = 1;
            List<Subject> expectedSubjects = new List<Subject>();

            Student student = new Student(expectedName, expectedLastName, expectedDocumentNumber);

            Assert.AreEqual(expectedName, student.GetName());
            Assert.AreEqual(expectedLastName, student.GetLastName());
            Assert.AreEqual(expectedDocumentNumber, student.GetDocumentNumber());
            Assert.AreEqual(expectedStudentNumber, student.GetStudentNumber());

            List<Subject> actualSubjects = student.GetSubjects();
            Assert.IsTrue(Utility.CompareLists(actualSubjects, expectedSubjects));
        }
    }
}
