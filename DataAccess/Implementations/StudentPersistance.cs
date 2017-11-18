using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class StudentPersistance : IStudentPersistance
    {
        public bool IsStudentInSystem(string documentNumber)
        {
            using (Context context = new Context())
            {
                return context.people.OfType<Student>().Any(s => s.Document.Equals(documentNumber));
            }
        }

        public Student GetStudentByNumber(int studentNumber)
        {
            Student foundStudent;
            using (Context context = new Context())
            {
                foundStudent = context.people.OfType<Student>().Include("Subjects")
                    .FirstOrDefault(s => s.StudentNumber.Equals(studentNumber));
            }
            return foundStudent;
        }

        public int GetNextStudentNumber()
        {
            int studentNumber = 0;
            using (Context context = new Context())
            {
                var students = context.people.OfType<Student>();
                if(students?.Count() > 0)
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

        public void DeleteStudent(Student studentToDelete)
        {
            using (Context context = new Context())
            {
                context.people.Attach(studentToDelete);
                context.people.Remove(studentToDelete);
                context.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> students;
            using (Context context = new Context())
            {
                students = (from student
                                in context.people.OfType<Student>()
                             select student).ToList();

            }
            return students;
        }
    }
}