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

        public void AddTeacher(AddTeacherInput input)
        {
            if (this.IsTeacherInSystem(input.aTeacher))
                throw new CoreException("Teacher already exists.");

            this.systemTeachers.Add(input.aTeacher);
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {
            return this.systemTeachers.Find(item => item.GetDocumentNumber().Equals(documentNumber));
        }

        #region Utilities
        private bool IsTeacherInSystem(Teacher aTeacher)
        {
            return this.systemTeachers.Exists(item => item.Equals(aTeacher));
        }
        #endregion
    }
}