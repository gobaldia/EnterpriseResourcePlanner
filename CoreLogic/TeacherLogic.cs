using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using DataAccess;
using DataContracts;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class TeacherLogic : ITeacherLogic
    {
        private ITeacherPersistance persistanceProvider;

        public TeacherLogic(ITeacherPersistance provider)
        {
            this.persistanceProvider = provider;
        }

        public void AddTeacher(Teacher newTeacher)
        {
            if (this.IsTeacherInSystem(newTeacher))
                throw new CoreException("Teacher already exists.");

            this.persistanceProvider.AddTeacher(newTeacher);
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {   
            Teacher teacherFound = this.persistanceProvider.GetTeacherByDocumentNumber(documentNumber);
            if (teacherFound == null)
                throw new CoreException("Teacher not found.");

            return teacherFound;
        }

        public void DeleteTeacher(Teacher teacherToDelete)
        {
            this.persistanceProvider.DeleteTeacher(teacherToDelete);
        }

        public void ModifyTeacher(ModifyTeacherInput input)
        {            
            Teacher teacherToModify = GetTeacherByDocumentNumber(input.DocumentNumber);

            bool nameWasModified = ModifyName(teacherToModify, input.NewName);
            bool lastNameWasModified = ModifyLastName(teacherToModify, input.NewLastName);
            bool subjectsWereModified = ModifySubjects(teacherToModify, input.NewSubjects);
            
            if (!nameWasModified && !lastNameWasModified && !subjectsWereModified)
                throw new CoreException("No modifications have been made.");

            this.persistanceProvider.ModifyTeacher(teacherToModify);
        }

        public List<Teacher> GetTeachers()
        {
            return this.persistanceProvider.GetTeachers();
        }

        #region Utilities
        private bool IsTeacherInSystem(Teacher aTeacher)
        {
            var systemTeachers = this.persistanceProvider.GetTeachers();
            return systemTeachers.Exists(item => item.Equals(aTeacher));
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