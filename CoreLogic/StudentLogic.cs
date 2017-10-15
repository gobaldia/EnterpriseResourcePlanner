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

        public Student GetStudentByDocumentNumber(string documentNumber)
        {
            Student studentFound = this.systemStudents.Find(item => item.GetDocumentNumber().Equals(documentNumber));
            if (studentFound == null)
                throw new CoreException("Student not found.");

            return studentFound;
        }

        #region Utility methods
        private bool IsStudentInSystem(Student aStudent)
        {
            return this.systemStudents.Exists(item => item.Equals(aStudent));
        }
        #endregion
    }
}
