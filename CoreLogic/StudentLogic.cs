using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class StudentLogic
    {
        private List<Student> systemStudents = SystemData.GetInstance.GetStudents();

        public void AddStudent(Student newStudent)
        {
            if (this.IsStudentInSystem(newStudent))
                throw new CoreException("Student already exists.");

            this.systemStudents.Add(newStudent);
        }

        #region Utility methods
        private bool IsStudentInSystem(Student aStudent)
        {
            return this.systemStudents.Exists(item => item.Equals(aStudent));
        }
        #endregion
    }
}
