using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace DummyPersistance.Implementations
{
    public class StudentDummyPersistance : IStudentPersistance
    {
        private List<Student> dummySystemStudents = SystemDummyData.GetInstance.GetStudents();
        public void AddStudent(Student newStudent)
        {
            dummySystemStudents.Add(newStudent);
        }

        public void DeleteStudent(Student studentToDelete)
        {
            dummySystemStudents.Remove(studentToDelete);
        }

        public int GetNextStudentNumber()
        {
            int studentNumber = 0;
            if (dummySystemStudents?.Count() > 0)
            {
                var student = dummySystemStudents.OrderByDescending(item => item.StudentNumber).First();
                studentNumber = student.StudentNumber;
            }
            return ++studentNumber;
        }

        public Student GetStudentByDocumentNumber(string documentNumber)
        {
            return dummySystemStudents.Find(s => s.Document.Equals(documentNumber));
        }

        public Student GetStudentByNumber(int studentNumber)
        {
            return dummySystemStudents.Find(s => s.StudentNumber.Equals(studentNumber));
        }

        public List<Student> GetStudents(bool bringSubjects = false)
        {
            return dummySystemStudents;
        }

        public bool IsStudentInSystem(string documentNumber)
        {
            return dummySystemStudents.Exists(s => s.Document.Equals(documentNumber));
        }

        public void ModifyStudent(Student studentToModify)
        {
            Student systemStudent = GetStudentByDocumentNumber(studentToModify.Document);
            systemStudent.SetName(studentToModify.Name);
            systemStudent.SetLastName(studentToModify.LastName);
            systemStudent.SetPickUpService(studentToModify.HavePickUpService);
            systemStudent.SetLocation(studentToModify.Location);
            systemStudent.Subjects = studentToModify.Subjects;
        }
    }
}
