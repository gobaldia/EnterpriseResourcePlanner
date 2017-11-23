using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FrameworkCommon.MethodParameters;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using UnitTesting.Utilities;
using CoreLogic.Interfaces;
using DummyPersistance;

namespace UnitTesting
{
    [TestClass]
    public class TeacherTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

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

            Assert.IsTrue(Utility.CompareLists(actualSubjects, expectedSubjects));
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
            Assert.IsTrue(Utility.CompareLists(actualSubjects, expectedSubjects));            
        }

        [TestMethod]
        public void TeachersInstancesAreEqual()
        {
            string name = Utility.GetRandomName();
            string lastName = Utility.GetRandomLastName();
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
            string name = Utility.GetRandomName();
            string lastName = Utility.GetRandomLastName();
            string document = "1234567-8";

            Teacher firstTeacher = new Teacher(name, lastName, document);

            Assert.AreEqual(string.Format("{0} {1}", name, lastName), firstTeacher.GetFullName());
        }

        [TestMethod]
        public void ThrowExceptionOnInvalidDocumentFormat()
        {
            try
            {
                string name = Utility.GetRandomName();
                string lastName = Utility.GetRandomLastName();
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
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

            Teacher newTeacher = this.CreateRandomTeacher();
            teacherOperations.AddTeacher(newTeacher);

            Assert.IsNotNull(this.FindTeacherOnSystem(newTeacher.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateTeacherToSystem()
        {
            try
            {
                ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

                Teacher firstTeacher = this.CreateRandomTeacher();
                Teacher secondTeacher = new Teacher(firstTeacher.GetName(), firstTeacher.GetLastName(), firstTeacher.GetDocumentNumber());
                
                teacherOperations.AddTeacher(firstTeacher);
                teacherOperations.AddTeacher(secondTeacher);

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

        [TestMethod]
        public void AddSubjectToTeacher()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

            List<Subject> systemSubjects = SystemDummyData.GetInstance.GetSubjects();
            Subject aSubject = new Subject(123456, "Math");
            systemSubjects.Add(aSubject);

            Teacher newTeacher = this.CreateRandomTeacher();
            Subject subjectToBeAdded = subjectOperations.GetSubjectByCode(123456);

            newTeacher.AddSubjectToTeach(subjectToBeAdded);

            Assert.IsTrue(newTeacher.GetSubjects().Count > 0);
        }

        [TestMethod]
        public void FindTeacherByDocumentNumber()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

            string documentNumber = "1234567-8";
            Teacher firstTeacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);

            teacherOperations.AddTeacher(firstTeacher);
            
            Teacher teacherFound = teacherOperations.GetTeacherByDocumentNumber(documentNumber);
            Assert.IsNotNull(teacherFound);
        }

        [TestMethod]
        public void DeleteTeacher()
        {
            try
            {
                ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

                string documentNumber = "1234567-8";
                Teacher teacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);

                teacherOperations.AddTeacher(teacher);
                teacherOperations.DeleteTeacher(teacher);

                Assert.IsNull(this.FindTeacherOnSystem(teacher.GetDocumentNumber()));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void RemoveSubjectFromTeacher()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

            List<Subject> systemSubjects = SystemDummyData.GetInstance.GetSubjects();
            Subject subject1 = new Subject(123456, "Math");
            Subject subject2 = new Subject(654321, "Physics");
            systemSubjects.Add(subject1);
            systemSubjects.Add(subject2);

            Teacher newTeacher = this.CreateRandomTeacher();
            Subject subjectToBeAdded1 = subjectOperations.GetSubjectByCode(123456);
            Subject subjectToBeAdded2 = subjectOperations.GetSubjectByCode(654321);
            
            newTeacher.AddSubjectToTeach(subjectToBeAdded1);
            newTeacher.AddSubjectToTeach(subjectToBeAdded2);

            newTeacher.RemoveSubject(subjectToBeAdded1);
            List<Subject> teacherSubjects = newTeacher.GetSubjects();

            Assert.IsFalse(teacherSubjects.Exists(item => item.Equals(subjectToBeAdded1)));
        }

        [TestMethod]
        public void ModifyTeacherName()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

            Teacher newTeacher = new Teacher("Rodigo", Utility.GetRandomLastName(), "1234567-8");
            teacherOperations.AddTeacher(newTeacher);

            ModifyTeacherInput input = new ModifyTeacherInput();
            input.NewName = "Santiago";
            input.DocumentNumber = "1234567-8";
            teacherOperations.ModifyTeacher(input);

            Teacher modifiedTeacher = teacherOperations.GetTeacherByDocumentNumber("1234567-8");

            Assert.AreEqual(modifiedTeacher.GetName(), input.NewName);
        }

        [TestMethod]
        public void ModifyTeacherLastName()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

            Teacher newTeacher = new Teacher(Utility.GetRandomName(), "de Leon", "1234567-8");
            teacherOperations.AddTeacher(newTeacher);

            ModifyTeacherInput input = new ModifyTeacherInput();
            input.NewLastName = "Diaz";
            input.DocumentNumber = "1234567-8";
            teacherOperations.ModifyTeacher(input);

            Teacher modifiedTeacher = teacherOperations.GetTeacherByDocumentNumber("1234567-8");

            Assert.AreEqual(modifiedTeacher.GetLastName(), input.NewLastName);
        }

        [TestMethod]
        public void ModifyTeacherSubjects()
        {
            ITeacherLogic teacherOperations = DummyProvider.GetInstance.GetTeacherOperations();

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

            #region Add teacher to the system
            Teacher newTeacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), "1234567-8");
            newTeacher.AddSubjectToTeach(subject1);
            newTeacher.AddSubjectToTeach(subject2);
            newTeacher.AddSubjectToTeach(subject3);
             teacherOperations.AddTeacher(newTeacher);
            #endregion

            List<Subject> newSubjects = new List<Subject>();
            newSubjects.Add(subject1);
            newSubjects.Add(subject2);
            newSubjects.Add(subject4);

            ModifyTeacherInput input = new ModifyTeacherInput();
            input.NewSubjects = newSubjects;
            input.DocumentNumber = "1234567-8";
            teacherOperations.ModifyTeacher(input);

            Teacher modifiedTeacher = teacherOperations.GetTeacherByDocumentNumber("1234567-8");

            Assert.IsTrue(Utility.CompareLists(modifiedTeacher.GetSubjects(), input.NewSubjects));
        }

        [TestMethod]
        public void ToString()
        {
            var teacher = new Teacher();
            teacher.SetName("George");
            teacher.SetLastName("Harrison");
            teacher.Document = "1234567-8";
            var expectedToString = "Full name: George Harrison, Document number: 1234567-8";
            Assert.AreEqual(expectedToString, teacher.ToString());
        }

        #region Extra Methods
        private Teacher FindTeacherOnSystem(string documentNumber)
        {
            return SystemDummyData.GetInstance.GetTeachers().Find(x => x.GetDocumentNumber().Equals(documentNumber));
        }

        private Teacher CreateRandomTeacher()
        {
            Teacher newTeacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), Utility.GetRandomDocument());
            return newTeacher;
        }
        #endregion
    }
}
