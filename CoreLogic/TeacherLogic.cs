using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class TeacherLogic
    {
        private List<Teacher> systemTeachers = SystemData.GetInstance.GetTeachers();

        public void AddTeacher(Teacher newTeacher)
        {
            if (this.IsTeacherInSystem(newTeacher))
                throw new CoreException("Teacher already exists.");

            this.systemTeachers.Add(newTeacher);
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {   
            Teacher teacherFound = this.systemTeachers.Find(item => item.GetDocumentNumber().Equals(documentNumber));
            if (teacherFound == null)
                throw new CoreException("No teacher found.");

            return teacherFound;
        }

        public void DeleteTeacher(Teacher teacherToDelete)
        {
            this.systemTeachers.Remove(teacherToDelete);
        }

        public void ModifyTeacher(ModifyTeacherInput input)
        {            
            Teacher teacherToModify = GetTeacherByDocumentNumber(input.DocumentNumber);

            if(!teacherToModify.GetName().Equals(input.NewName))
                teacherToModify.SetName(input.NewName);

            if (!teacherToModify.GetLastName().Equals(input.NewLastName))
                teacherToModify.SetLastName(input.NewLastName);

            List<Subject> teacherSubjects = teacherToModify.GetSubjects();
            if (this.AreSubjectsToModify(input.NewSubjects, teacherSubjects))
                teacherToModify.ModifySubjects(input.NewSubjects);
        }

        #region Utilities
        private bool IsTeacherInSystem(Teacher aTeacher)
        {
            return this.systemTeachers.Exists(item => item.Equals(aTeacher));
        }

        private bool SubjectExitsOnTeacher(Subject aSubject, Teacher aTeacher)
        {
            return aTeacher.GetSubjects().Exists(item => item.Equals(aSubject));
        }
        private bool AreSubjectsToModify(List<Subject> newSubjects, List<Subject> teacherSubjects)
        {
            bool result = false;

            if(newSubjects != null && !newSubjects.SequenceEqual(teacherSubjects))
            {
                result = true;
            }

            return result;
        }
        #endregion
    }
}