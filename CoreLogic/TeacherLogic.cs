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

        #region Utilities
        private bool IsTeacherInSystem(Teacher aTeacher)
        {
            return this.systemTeachers.Exists(item => item.Equals(aTeacher));
        }
        #endregion
    }
}