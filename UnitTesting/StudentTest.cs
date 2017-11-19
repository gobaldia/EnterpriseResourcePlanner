using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using CoreLogic.Interfaces;
using DataAccess;
using DummyPersistance;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
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
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

        [TestMethod]
        public void CreateStudent()
        {
            string expectedName = string.Empty;
            string expectedLastName = string.Empty;
            int expectedStudentNumber = 0;

            Student student = new Student();
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
            int expectedStudentNumber = 0;
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
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            Student newStudent = this.CreateRandomStudent();
            newStudent.Subjects = new List<Subject>();
            newStudent.HavePickUpService = false;
            newStudent.StudentNumber = 1;
            studentOperations.AddStudent(newStudent);

            Assert.IsNotNull(this.FindStudentOnSystem(newStudent.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateStudentToSystem()
        {
            try
            {
                IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

                Student firstStudent = this.CreateRandomStudent();
                firstStudent.StudentNumber = 1;

                Student secondStudent = new Student(firstStudent.GetName(), firstStudent.GetLastName(), firstStudent.GetDocumentNumber());
                secondStudent.StudentNumber = 2;              

                studentOperations.AddStudent(firstStudent);
                studentOperations.AddStudent(secondStudent);

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
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

            List <Subject> systemSubjects = SystemDummyData.GetInstance.GetSubjects();
            Subject aSubject = new Subject(123456, "Math");
            systemSubjects.Add(aSubject);

            Student newStudent = this.CreateRandomStudent();
            Subject subjectToBeAdded = subjectOperations.GetSubjectByCode(123456);

            newStudent.AddSubjectToStudent(subjectToBeAdded);

            Assert.IsTrue(newStudent.GetSubjects().Count > 0);
        }

        [TestMethod]
        public void FindStudentByDocumentNumber()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            firstStudent.StudentNumber = 1;
            studentOperations.AddStudent(firstStudent);

            Student StudentFound = studentOperations.GetStudentByDocumentNumber(documentNumber);
            Assert.IsNotNull(StudentFound);
        }

        [TestMethod]
        public void SetStudentForPickUpVehicle()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            studentOperations.AddStudent(firstStudent);

            Student studentFound = studentOperations.GetStudentByDocumentNumber(documentNumber);
            studentFound.SetPickUpService(true);

            Assert.IsTrue(studentFound.HavePickUpService);
        }

        [TestMethod]
        public void AddStudentCoordinates()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            studentOperations.AddStudent(firstStudent);

            Student studentFound = studentOperations.GetStudentByDocumentNumber(documentNumber);
            double latitud = 1.2;
            double longitud = 2.2;
            Location location = new Location(latitud, longitud);
            studentFound.SetLocation(location);

            Assert.IsTrue(studentFound.GetLocation().Equals(location));
        }

        [TestMethod]
        public void ModifyStudentName()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            int nextStudentNumber = 1;

            var newStudent = new Student();
            newStudent.Name = "Rodigo";
            newStudent.LastName = Utility.GetRandomLastName();
            newStudent.Document = "1234567-8";
            newStudent.StudentNumber = nextStudentNumber;
            studentOperations.AddStudent(newStudent);

            ModifyStudentInput modifyInput = new ModifyStudentInput();
            modifyInput.NewName = "Santiago";
            modifyInput.StudentNumber = nextStudentNumber;
            studentOperations.ModifyStudent(modifyInput);

            Student modifiedStudent = studentOperations.GetStudentByNumber(modifyInput.StudentNumber);
            Assert.AreEqual(modifiedStudent.GetName(), modifyInput.NewName);
        }

        [TestMethod]
        public void ModifyStudentLastName()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            int nextStudentNumber = 1;

            var newStudent = new Student();
            newStudent.Name = Utility.GetRandomName();
            newStudent.LastName = "de Leon";
            newStudent.Document = "1234567-8";
            newStudent.StudentNumber = nextStudentNumber;
            studentOperations.AddStudent(newStudent);

            ModifyStudentInput modifyInput = new ModifyStudentInput();
            modifyInput.NewLastName = "Diaz";
            modifyInput.StudentNumber = nextStudentNumber;
            studentOperations.ModifyStudent(modifyInput);

            Student modifiedStudent = studentOperations.GetStudentByNumber(modifyInput.StudentNumber);
            Assert.AreEqual(modifiedStudent.GetLastName(), modifyInput.NewLastName);
        }

        [TestMethod]
        public void ModifyStudentSubjects()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            int nextStudentNumber = 1;

            #region Add subjects to the system
            List<Subject> systemSubjects = SystemDummyData.GetInstance.GetSubjects();
            Subject subject1 = new Subject(1234, "Math");
            Subject subject2 = new Subject(3216, "Physics");
            Subject subject3 = new Subject(7418, "Chemistry");
            Subject subject4 = new Subject(9632, "History");
            systemSubjects.Add(subject1);
            systemSubjects.Add(subject2);
            systemSubjects.Add(subject3);
            systemSubjects.Add(subject4);
            #endregion

            #region Add students with subjects to the system
            List<Subject> studentSubjects = new List<Subject>();
            studentSubjects.Add(subject1);
            studentSubjects.Add(subject2);
            studentSubjects.Add(subject3);

            var newStudent = new Student();
            newStudent.Document = "1234567-8";
            newStudent.Name = Utility.GetRandomName();
            newStudent.LastName = Utility.GetRandomLastName();
            newStudent.Subjects = studentSubjects;
            newStudent.StudentNumber = nextStudentNumber;
            studentOperations.AddStudent(newStudent);
            #endregion

            List<Subject> newSubjects = new List<Subject>();
            newSubjects.Add(subject1);
            newSubjects.Add(subject2);
            newSubjects.Add(subject4);

            var modifyInput = new ModifyStudentInput();
            modifyInput.NewSubjects = newSubjects;
            modifyInput.StudentNumber = nextStudentNumber;
            studentOperations.ModifyStudent(modifyInput);

            Student modifiedStudent = studentOperations.GetStudentByNumber(modifyInput.StudentNumber);

            Assert.IsTrue(Utility.CompareLists(modifiedStudent.GetSubjects(), modifyInput.NewSubjects));
        }

        [TestMethod]
        public void ModifyStudentLocation()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            int nextStudentNumber = 1;

            #region Add students with subjects to the system
            var newStudent = new Student()
            {
                Document = "1234567-8",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Location = new Location(10.00, 15.1),
                StudentNumber = nextStudentNumber
            };
            studentOperations.AddStudent(newStudent);
            #endregion

            Location newStudentLocation = new Location(2.1, 5.6);
            var modifyInput = new ModifyStudentInput();
            modifyInput.NewLocation = newStudentLocation;
            modifyInput.StudentNumber = nextStudentNumber;
            studentOperations.ModifyStudent(modifyInput);

            Student modifiedStudent = studentOperations.GetStudentByNumber(modifyInput.StudentNumber);

            Assert.IsTrue(modifiedStudent.GetLocation().Equals(newStudentLocation));
        }

        [TestMethod]
        public void ShowErrorIfNoModifications()
        {
            try
            {
                IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
                int nextStudentNumber = 1;

                #region Add subjects to the system
                List<Subject> systemSubjects = SystemDummyData.GetInstance.GetSubjects();
                Subject subject1 = new Subject(1234, "Math");
                Subject subject2 = new Subject(3216, "Physics");
                systemSubjects.Add(subject1);
                systemSubjects.Add(subject2);
                #endregion

                #region Add students with subjects to the system
                List<Subject> studentSubjects = new List<Subject>();
                studentSubjects.Add(subject1);
                studentSubjects.Add(subject2);
                var newStudent = new Student
                {
                    Document = "1234567-8",
                    Name = Utility.GetRandomName(),
                    LastName = Utility.GetRandomLastName(),
                    Subjects = studentSubjects,
                    StudentNumber = nextStudentNumber
                };
                studentOperations.AddStudent(newStudent);
                #endregion

                List<Subject> newSubjects = new List<Subject>();
                newSubjects.Add(subject1);
                newSubjects.Add(subject2);

                var modifyInput = new ModifyStudentInput();
                modifyInput.NewSubjects = newSubjects;
                modifyInput.NewName = newStudent.Name;
                modifyInput.NewLastName = newStudent.LastName;
                modifyInput.StudentNumber = nextStudentNumber;
                modifyInput.NewLocation = new Location();
                studentOperations.ModifyStudent(modifyInput);

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("No modifications have been made."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteStudent()
        {
            try
            {
                IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
                string documentNumber = "1234567-8";

                int nextStudentNumber = 1;
                var newStudent = new Student
                {
                    Name = Utility.GetRandomName(),
                    LastName = Utility.GetRandomLastName(),
                    Document = documentNumber,
                    StudentNumber = nextStudentNumber
                };

                studentOperations.AddStudent(newStudent);
                studentOperations.DeleteStudent(nextStudentNumber);

                Assert.IsNull(this.FindStudentOnSystem(documentNumber));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AddStudentFees()
        {
            try
            {
                var newStudent = CreateRandomStudent();
                newStudent.StudentNumber = 1;

                double fee = 20.5;
                newStudent.MonthlyFeeAmount(fee);

                Assert.AreEqual(newStudent.Fees.Count(), 12);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #region Extra methods
        private Student CreateRandomStudent()
        {
            Student newStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), Utility.GetRandomDocument());
            return newStudent;
        }
        private Student FindStudentOnSystem(string documentNumber)
        {
            return SystemDummyData.GetInstance.GetStudents().Find(x => x.GetDocumentNumber().Equals(documentNumber));
        }
        #endregion
    }
}