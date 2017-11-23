using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace DummyPersistance.Implementations
{
    public class TeacherDummyPersistance : ITeacherPersistance
    {
        private List<Teacher> dummySystemTeachers = SystemDummyData.GetInstance.GetTeachers();
        public void AddTeacher(Teacher newTeacher)
        {
            dummySystemTeachers.Add(newTeacher);
        }

        public void DeleteTeacher(Teacher teacherToDelete)
        {
            dummySystemTeachers.Remove(teacherToDelete);
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {
            return dummySystemTeachers.Where(t => t.Document.Equals(documentNumber)).FirstOrDefault();
        }

        public List<Teacher> GetTeachers(bool bringSubjects = false)
        {
            return dummySystemTeachers;
        }

        public void ModifyTeacher(Teacher teacherToModify)
        {
            Teacher foundTeacher = GetTeacherByDocumentNumber(teacherToModify.Document);
            foundTeacher.Name = teacherToModify.Name;
            foundTeacher.LastName = teacherToModify.LastName;
            foundTeacher.Subjects = teacherToModify.Subjects;
        }
    }
}
