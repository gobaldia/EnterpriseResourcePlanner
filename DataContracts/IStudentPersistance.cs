using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface IStudentPersistance
    {
        void AddStudent(Student newStudent);
        bool IsStudentInSystem(int studentNumber);
        int GetNextStudentNumber();
        List<Student> GetStudents();
    }
}
