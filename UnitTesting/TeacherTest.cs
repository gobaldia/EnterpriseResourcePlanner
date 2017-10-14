using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccess;
using FrameworkCommon;
using CoreLogic;
using FrameworkCommon.MethodParameters;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using UnitTesting.Utilities;

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
            SystemData.GetInstance.Reset();

            Teacher newTeacher = this.CreateRandomTeacher();
            var input = new AddTeacherInput { aTeacher = newTeacher };
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(input);

            Assert.IsNotNull(this.FindTeacherOnSystem(newTeacher.GetDocumentNumber()));
        }

        [TestMethod]
        public void DoNotAllowToAddDuplicateTeacherToSystem()
        {
            try
            {
                SystemData.GetInstance.Reset();

                Teacher firstTeacher = this.CreateRandomTeacher();
                Teacher secondTeacher = new Teacher(firstTeacher.GetName(), firstTeacher.GetLastName(), firstTeacher.GetDocumentNumber());

                var firtTeacherInput = new AddTeacherInput { aTeacher = firstTeacher };
                var secondTeacherInput = new AddTeacherInput { aTeacher = secondTeacher };
                ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(firtTeacherInput);
                ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(secondTeacherInput);

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
            SystemData.GetInstance.Reset();

            List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();
            Subject aSubject = new Subject(123456, "Math");
            systemSubjects.Add(aSubject);

            Teacher newTeacher = this.CreateRandomTeacher();
            Subject subjectToBeAdded = SystemData.GetInstance.GetSubjectByCode(123456);

            newTeacher.AddSubjectToTeach(subjectToBeAdded);

            Assert.IsTrue(newTeacher.GetSubjects().Count > 0);
        }

        [TestMethod]
        public void FindTeacherByDocumentNumber()
        {
            SystemData.GetInstance.Reset();

            string documentNumber = "1234567-8";
            Teacher firstTeacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);

            var firtTeacherInput = new AddTeacherInput { aTeacher = firstTeacher };
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(firtTeacherInput);
            
            Teacher teacherFound = ClassFactory.GetOrCreate<TeacherLogic>().GetTeacherByDocumentNumber(documentNumber);
            Assert.IsNotNull(teacherFound);
        }

        [TestMethod]
        public void DeleteTeacher()
        {
            try
            {
                SystemData.GetInstance.Reset();

                string documentNumber = "1234567-8";
                Teacher teacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), documentNumber);

                var teacherInput = new AddTeacherInput { aTeacher = teacher };
                ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacherInput);

                ClassFactory.GetOrCreate<TeacherLogic>().DeleteTeacher(teacher);

                Assert.IsNull(this.FindTeacherOnSystem(teacher.GetDocumentNumber()));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #region Extra Methods
        private Teacher FindTeacherOnSystem(string documentNumber)
        {
            return SystemData.GetInstance.GetTeachers().Find(x => x.GetDocumentNumber().Equals(documentNumber));
        }

        private Teacher CreateRandomTeacher()
        {
            Teacher newTeacher = new Teacher(Utility.GetRandomName(), Utility.GetRandomLastName(), Utility.GetRandomDocument());
            return newTeacher;
        }
        #endregion
    }
}
