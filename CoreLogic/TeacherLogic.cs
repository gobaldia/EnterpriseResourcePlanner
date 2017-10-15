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

            bool nameWasModified = ModifyName(teacherToModify, input.NewName);
            bool lastNameWasModified = ModifyLastName(teacherToModify, input.NewLastName);
            bool subjectsWereModified = ModifySubjects(teacherToModify, input.NewSubjects);
            
            if (!nameWasModified && !lastNameWasModified && !subjectsWereModified)
                throw new CoreException("No modifications have been made.");
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
        private bool ModifyName(Teacher teacherToModify, string newName)
        {
            bool wasModifed = false;
            if (!teacherToModify.GetName().Equals(newName))
            {
                teacherToModify.SetName(newName);
                wasModifed = true;
            }
            return wasModifed;
        }
        private bool ModifyLastName(Teacher teacherToModify, string newLastName)
        {
            bool wasModifed = false;
            if (!teacherToModify.GetLastName().Equals(newLastName))
            {
                teacherToModify.SetLastName(newLastName);
                wasModifed = true;
            }
            return wasModifed;
        }
        private bool ModifySubjects(Teacher teacherToModify, List<Subject> newSubjects)
        {
            bool wasModified = false;
            List<Subject> teacherSubjects = teacherToModify.GetSubjects();
            if (CheckIfSubjectsHaveChange(newSubjects, teacherSubjects))
            {
                teacherToModify.ModifySubjects(newSubjects);
                wasModified = true;
            }
            return wasModified;
        }
        private bool CheckIfSubjectsHaveChange(List<Subject> newSubjects, List<Subject> teacherSubjects)
        {
            bool result = false;

            if (newSubjects != null && !newSubjects.SequenceEqual(teacherSubjects))
            {
                result = true;
            }

            return result;
        }
        #endregion
    }
}