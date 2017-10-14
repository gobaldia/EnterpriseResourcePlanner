using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccess;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using FrameworkCommon;
using CoreLogic;

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
            Subject newSubject = new Subject(1, "Logic");
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(newSubject);

            Assert.IsNotNull(this.FindSubjectOnSystem(newSubject.GetCode()));
        }

        [TestMethod]
        public void TryToAddSubjectThatAlreadyExistsToSystem()
        {
            try
            {
                Subject firstTeacher = new Subject(1, "Logic");
                Subject secondTeacher = new Subject(1, "Logic");
                ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(firstTeacher);
                ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(secondTeacher);

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
        public void ModifySubjectName()
        {
            string expectedName = "Programming";
            Subject subject = new Subject(1, "Logic");
            subject.Name = expectedName;

            Assert.AreEqual(expectedName, subject.Name);
        }

        [TestMethod]
        public void ModifySubjectCode()
        {
            int expectedCode = 100;
            Subject subject = new Subject(1, "Logic");
            subject.Code = expectedCode;

            Assert.AreEqual(expectedCode, subject.Code);
        }

        [TestMethod]
        public void AddNewStudentToSubject()
        {
            Subject subject = new Subject(1, "Logic");
            Student student = new Student("1234567-8", "Jose", "Lopez", 123456);
            subject.AddStudent(student);
            Assert.IsNotNull(FindStudentByDocument(student.Document));

        }

        [TestMethod]
        public void AddNewTeacherToSubject()
        {
            Subject subject = new Subject(1, "Logic");
            Teacher teacher = new Teacher("Juan", "Perez", "1234567-8");
            subject.AddTeacher(teacher);
            Assert.IsNotNull(FindTeacherByDocument(teacher.GetDocumentNumber()));
        }

        [TestMethod]
        public void ThrowExceptionWhenTryToAddAnAlreadyExistentStudentToSubject()
        {
            try
            {
                Subject subject = new Subject(1, "Logic");
                Student student = new Student("1234567-8", "Jose", "Lopez", 123456);
                subject.AddStudent(student);
                subject.AddStudent(student);
            }
            catch(CoreException ex)
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
                Teacher teacher = new Teacher("Juan", "Perez", "1234567-8");
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

        private SystemData GetNewSystemData()
        {
            SystemData.GetInstance.Reset();
            return SystemData.GetInstance;
        }

        private Subject FindSubjectOnSystem(int code)
        {
            return SystemData.GetInstance.GetSubjects().Find(x => x.GetCode() == code);
        }
        #endregion
    }
}
