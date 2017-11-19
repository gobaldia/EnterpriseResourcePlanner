using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccess;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using FrameworkCommon;
using CoreLogic;
using DummyPersistance;
using CoreLogic.Interfaces;

namespace UnitTesting
{
    [TestClass]
    public class SubjectTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

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
            string expectedName = "Logic";
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
            string expectedName = "Logic";
            List<Student> expectedStudents = new List<Student>();
            List<Teacher> expectedTeachers = new List<Teacher>();

            Subject firstSubject = new Subject(100, "Logic");
            Subject secondSubject = new Subject(100, "Logic");

            Assert.IsTrue(firstSubject.Equals(secondSubject));
        }

        [TestMethod]
        public void AddSubjectToSystem()
        {
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();
            Subject newSubject = new Subject(1, "Logic");
            subjectOperations.AddSubject(newSubject);

            Assert.IsNotNull(this.FindSubjectOnSystem(newSubject.GetCode()));
        }

        [TestMethod]
        public void TryToAddSubjectThatAlreadyExistsToSystem()
        {
            try
            {
                ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

                Subject firstTeacher = new Subject(1, "Logic");
                Subject secondTeacher = new Subject(1, "Logic");
                subjectOperations.AddSubject(firstTeacher);
                subjectOperations.AddSubject(secondTeacher);

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Subject already exists."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteSubject()
        {
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

            Subject subject = new Subject(1000, "Logic");
            subjectOperations.AddSubject(subject);
            subjectOperations.DeleteSubjectByCode(1000);
            Assert.IsNull(this.FindSubjectOnSystem(1000));
        }

        [TestMethod]
        public void AfterDeleteSubjectCodeIsAvailableToCreateNewSubject()
        {
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();
            Subject subject = new Subject(1000, "Logic");
            subjectOperations.AddSubject(subject);
            subjectOperations.DeleteSubjectByCode(subject.GetCode());
            Subject anotherSubject = new Subject(1000, "Logic");
            subjectOperations.AddSubject(anotherSubject);
            Assert.IsNotNull(this.FindSubjectOnSystem(anotherSubject.GetCode()));
        }

        [TestMethod]
        public void ModifySubjectName()
        {
            string expectedName = "Programming";
            Subject subject = new Subject(1, "Logic");
            subject.SetName(expectedName);

            Assert.AreEqual(expectedName, subject.Name);
        }

        [TestMethod]
        public void ModifySubjectCode()
        {
            int expectedCode = 100;
            Subject subject = new Subject(1, "Logic");
            subject.SetCode(expectedCode);

            Assert.AreEqual(expectedCode, subject.Code);
        }

        [TestMethod]
        public void ModifySubject()
        {
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();

            int subjectCode = 1;
            Subject subject = new Subject(subjectCode, "Logic");
            subjectOperations.AddSubject(subject);

            subject.SetName("LogicModified");
            subjectOperations.ModifySubjectByCode(subjectCode, subject);

            Subject modifiedSubject = subjectOperations.GetSubjectByCode(subjectCode);
            Assert.AreEqual(modifiedSubject.GetName(), "LogicModified");
        }
        
        [TestMethod]
        public void AddNewStudentToSubject()
        {
            Subject subject = new Subject(1, "Logic");
            Student student = new Student("Jose", "Lopez", "1234567-8");
            subject.AddStudent(student);
            Assert.IsNotNull(FindStudentByDocument(subject.Students, student.GetDocumentNumber()));

        }

        [TestMethod]
        public void AddNewTeacherToSubject()
        {
            Subject subject = new Subject(1, "Logic");
            Teacher teacher = new Teacher("Juan", "Perez", "1234567-8");
            subject.AddTeacher(teacher);
            Assert.IsNotNull(FindTeacherByDocument(subject.Teachers, teacher.GetDocumentNumber()));
        }

        [TestMethod]
        public void ThrowExceptionWhenTryToAddAnAlreadyExistentStudentToSubject()
        {
            try
            {
                Subject subject = new Subject(1, "Logic");
                Student student = new Student("Jose", "Lopez", "1234567-8");
                subject.AddStudent(student);
                subject.AddStudent(student);
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("This student is already enrolled to this subject."));
            }
        }

        [TestMethod]
        public void ThrowExceptionWhenTryToAddAnAlreadyExistentTeacherToSubject()
        {
            try
            {
                Subject subject = new Subject(1, "Logic");
                Teacher teacher = new Teacher("Juan", "Perez", "1234567-9");
                subject.AddTeacher(teacher);
                subject.AddTeacher(teacher);
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("This teacher is already enrolled to this subject."));
            }
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

        private Subject FindSubjectOnSystem(int code)
        {
            ISubjectLogic subjectOperations = DummyProvider.GetInstance.GetSubjectOperations();
            List<Subject> subjects = subjectOperations.GetSubjects();
            return subjects.Find(x => x.GetCode() == code);
        }

        private Student FindStudentByDocument(List<Student> students, string document)
        {
            return students.Find(s => s.GetDocumentNumber() == document);
        }

        private Teacher FindTeacherByDocument(List<Teacher> teachers, string document)
        {
            return teachers.Find(t => t.GetDocumentNumber() == document);
        }
        #endregion
    }
}
