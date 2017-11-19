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
        bool IsStudentInSystem(string documentNumber);
        int GetNextStudentNumber();
        Student GetStudentByNumber(int studentNumber);
        void DeleteStudent(Student studentToDelete);
        List<Student> GetStudents(bool bringSubjects = false);
        void ModifyStudent(Student studentToModify);
    }
}