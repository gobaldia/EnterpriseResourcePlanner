using CoreEntities.Entities;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface IStudentLogic
    {
        void AddStudent(Student newStudent);
        Student GetStudentByDocumentNumber(string documentNumber);
        void ModifyStudent(ModifyStudentInput input);
        Student GetStudentByNumber(int studentNumber);
        List<Student> GetStudents(bool bringSubjects = false);
        void DeleteStudent(int studentNumber);
        int GetNextStudentNumber();
        void PayFees(List<Fee> feesToBePaid);
    }
}
