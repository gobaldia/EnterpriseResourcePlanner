using CoreEntities.Entities;
using CoreEntities.Exceptions;
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

        [TestMethod]
        public void StudentsInstancesAreEqual()
        {
            string name = Utility.GetRandomName();
            string lastName = Utility.GetRandomLastName();
            string documentNumber = "1234567-8";
            Student firstStudent = new Student(name, lastName, documentNumber);
            Student secondStudent = new Student(name, lastName, documentNumber);

            Assert.IsTrue(firstStudent.Equals(secondStudent));
        }

        [TestMethod]
        public void StudentsInstancesAreNotEqual()
        {
            string name1 = "Edinson";
            string lastName1 = "Cavani";
            string document1 = "1234567-8";

            string name2 = "Luis";
            string lastName2 = "Suarez";
            string document2 = "3216549-8";

            Student firstStudent = new Student(name1, lastName1, document1);
            Student secondStudent = new Student(name2, lastName2, document2);

            Assert.IsFalse(firstStudent.Equals(secondStudent));
        }

        [TestMethod]
        public void GetFullNameCorrectly()
        {
            string name = Utility.GetRandomName();
            string lastName = Utility.GetRandomLastName();
            string document = "1234567-8";

            Student firstStudent = new Student(name, lastName, document);

            Assert.AreEqual(string.Format("{0} {1}", name, lastName), firstStudent.GetFullName());
        }

        [TestMethod]
        public void ThrowExceptionOnInvalidDocumentFormat()
        {
            try
            {
                string name = Utility.GetRandomName();
                string lastName = Utility.GetRandomLastName();
                string document = "12345678"; // Invalid format

                Student firstStudent = new Student(name, lastName, document);
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
    }
}
