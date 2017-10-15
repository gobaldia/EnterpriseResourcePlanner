using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using DataAccess;
using FrameworkCommon;
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

        [TestMethod]
        public void AddStudentToSystem()
        {
            SystemData.GetInstance.Reset();

            Student newStudent = this.CreateRandomStudent();
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(newStudent);

            Assert.IsNotNull(this.FindStudentOnSystem(newStudent.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateStudentToSystem()
        {
            try
            {
                SystemData.GetInstance.Reset();

                Student firstStudent = this.CreateRandomStudent();
                Student secondStudent = new Student(firstStudent.GetName(), firstStudent.GetLastName(), firstStudent.GetDocumentNumber());

                ClassFactory.GetOrCreate<StudentLogic>().AddStudent(firstStudent);
                ClassFactory.GetOrCreate<StudentLogic>().AddStudent(secondStudent);

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Student already exists."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AddSubjectToStudent()
        {
            SystemData.GetInstance.Reset();

            List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();
            Subject aSubject = new Subject(123456, "Math");
            systemSubjects.Add(aSubject);

            Student newStudent = this.CreateRandomStudent();
            Subject subjectToBeAdded = SystemData.GetInstance.GetSubjectByCode(123456);

            newStudent.AddSubjectToStudent(subjectToBeAdded);

            Assert.IsTrue(newStudent.GetSubjects().Count > 0);
        }

        [TestMethod]
        public void FindStudentByDocumentNumber()
        {
            SystemData.GetInstance.Reset();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(firstStudent);

            Student StudentFound = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(documentNumber);
            Assert.IsNotNull(StudentFound);
        }

        [TestMethod]
        public void SetStudentForPickUpVehicle()
        {
            SystemData.GetInstance.Reset();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(firstStudent);

            Student studentFound = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(documentNumber);
            studentFound.SetPickUpService(true);

            Assert.IsNotNull(studentFound.HavePickUpService());
        }

        [TestMethod]
        public void AddStudentCoordinates()
        {
            SystemData.GetInstance.Reset();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(firstStudent);

            Student studentFound = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(documentNumber);
            decimal latitud = 1.2M;
            decimal longitud = 2.2M;
            Location location = new Location(latitud, longitud);
            studentFound.SetLocation(location);

            Assert.IsTrue(studentFound.GetLocation().Equals(location));
        }



        #region Extra methods
        private Student CreateRandomStudent()
        {
            Student newStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), Utility.GetRandomDocument());
            return newStudent;
        }
        private Student FindStudentOnSystem(string documentNumber)
        {
            return SystemData.GetInstance.GetStudents().Find(x => x.GetDocumentNumber().Equals(documentNumber));
        }
        #endregion
    }
}
