using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using DataAccess;
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
            var input = new AddStudentInput();
            input.Name = newStudent.GetName();
            input.LastName = newStudent.GetLastName();
            input.DocumentNumber = newStudent.GetDocumentNumber();
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input);

            Assert.IsNotNull(this.FindStudentOnSystem(newStudent.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateStudentToSystem()
        {
            try
            {
                SystemData.GetInstance.Reset();

                Student firstStudent = this.CreateRandomStudent();
                var firstInput = new AddStudentInput
                {
                    Name = firstStudent.GetName(),
                    LastName = firstStudent.GetLastName(),
                    DocumentNumber = firstStudent.GetDocumentNumber()
                };

                Student secondStudent = new Student(firstStudent.GetName(), firstStudent.GetLastName(), firstStudent.GetDocumentNumber());
                var secondInput = new AddStudentInput
                {
                    Name = firstStudent.GetName(),
                    LastName = firstStudent.GetLastName(),
                    DocumentNumber = firstStudent.GetDocumentNumber()
                };

                ClassFactory.GetOrCreate<StudentLogic>().AddStudent(firstInput);
                ClassFactory.GetOrCreate<StudentLogic>().AddStudent(secondInput);

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
            var input = new AddStudentInput
            {
                DocumentNumber = documentNumber,
                Name = firstStudent.GetName(),
                LastName = firstStudent.GetLastName()
            };

            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input);

            Student StudentFound = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(documentNumber);
            Assert.IsNotNull(StudentFound);
        }

        [TestMethod]
        public void SetStudentForPickUpVehicle()
        {
            SystemData.GetInstance.Reset();

            string documentNumber = "1234567-8";
            Student firstStudent = new Student(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);
            var input = new AddStudentInput
            {
                DocumentNumber = documentNumber,
                Name = firstStudent.GetName(),
                LastName = firstStudent.GetLastName()
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input);

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
            var input = new AddStudentInput
            {
                DocumentNumber = documentNumber,
                Name = firstStudent.GetName(),
                LastName = firstStudent.GetLastName()
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input);

            Student studentFound = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(documentNumber);
            double latitud = 1.2;
            double longitud = 2.2;
            Location location = new Location(latitud, longitud);
            studentFound.SetLocation(location);

            Assert.IsTrue(studentFound.GetLocation().Equals(location));
        }

        [TestMethod]
        public void ModifyStudentName()
        {
            SystemData.GetInstance.Reset();

            Student newStudent = new Student("Rodigo", Utility.GetRandomLastName(), "1234567-8");
            var addInput = new AddStudentInput
            {
                Name = newStudent.GetName(),
                LastName = newStudent.GetLastName(),
                DocumentNumber = newStudent.GetDocumentNumber()
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(addInput);

            ModifyStudentInput modifyInput = new ModifyStudentInput();
            modifyInput.NewName = "Santiago";
            modifyInput.StudentNumber = 1;
            ClassFactory.GetOrCreate<StudentLogic>().ModifyStudent(modifyInput);

            Student modifiedStudent = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByNumber(modifyInput.StudentNumber);
            Assert.AreEqual(modifiedStudent.GetName(), modifyInput.NewName);
        }

        [TestMethod]
        public void ModifyStudentLastName()
        {
            SystemData.GetInstance.Reset();

            Student newStudent = new Student(Utility.GetRandomName(), "de Leon", "1234567-8");
            var addInput = new AddStudentInput
            {
                Name = newStudent.GetName(),
                LastName = newStudent.GetLastName(),
                DocumentNumber = newStudent.GetDocumentNumber()
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(addInput);

            ModifyStudentInput modifyInput = new ModifyStudentInput();
            modifyInput.NewLastName = "Diaz";
            modifyInput.StudentNumber = 1;
            ClassFactory.GetOrCreate<StudentLogic>().ModifyStudent(modifyInput);

            Student modifiedStudent = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByNumber(modifyInput.StudentNumber);
            Assert.AreEqual(modifiedStudent.GetLastName(), modifyInput.NewLastName);
        }

        [TestMethod]
        public void ModifyStudentSubjects()
        {
            SystemData.GetInstance.Reset();

            #region Add subjects to the system
            List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();
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
            var input = new AddStudentInput
            {
                DocumentNumber = "1234567-8",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Subjects = studentSubjects
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input);
            #endregion

            List<Subject> newSubjects = new List<Subject>();
            newSubjects.Add(subject1);
            newSubjects.Add(subject2);
            newSubjects.Add(subject4);

            var modifyInput = new ModifyStudentInput();
            modifyInput.NewSubjects = newSubjects;
            modifyInput.StudentNumber = 1;
            ClassFactory.GetOrCreate<StudentLogic>().ModifyStudent(modifyInput);

            Student modifiedStudent = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByNumber(1);

            Assert.IsTrue(Utility.CompareLists(modifiedStudent.GetSubjects(), input.NewSubjects));
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
