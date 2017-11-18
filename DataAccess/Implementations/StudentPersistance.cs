using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class StudentPersistance : IStudentPersistance
    {
        public bool IsStudentInSystem(int studentNumber)
        {
            using (Context context = new Context())
            {
                return context.people.OfType<Student>().Any(s => s.StudentNumber.Equals(studentNumber));
            }
        }

        public int GetNextStudentNumber()
        {
            int studentNumber = 0;
            using (Context context = new Context())
            {
                var students = context.people.OfType<Student>();
                if (students?.Count() > 0)
                {
                    var student = students.OrderByDescending(item => item.StudentNumber).First();
                    studentNumber = student.StudentNumber;
                }
            }
            return ++studentNumber;
        }

        public void AddStudent(Student newStudent)
        {
            using (Context context = new Context())
            {
                context.people.Attach(newStudent);
                context.people.Add(newStudent);
                context.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            using (Context context = new Context())
            {
                var query = from student in context.people.OfType<Student>()
                            select student;

                foreach (var student in query)
                    students.Add(student);
            }
            return students;
        }
    }
}
