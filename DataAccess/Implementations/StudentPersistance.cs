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

        public Student GetStudentByDocumentNumber(string documentNumber)
        {
            Student studentFound;
            using (Context context = new Context())
            {
                var queryResult = (from student in (context.people.OfType<Student>()).Include("Subjects")
                                   where student.Document.Equals(documentNumber)
                                   select student).FirstOrDefault();

                studentFound = queryResult;
            }
            return studentFound;
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

        public void DeleteStudent(Student studentToDelete)
        {
            using (Context context = new Context())
            {
                context.people.Attach(studentToDelete);
                context.people.Remove(studentToDelete);
                context.SaveChanges();
            }
        }

        public List<Student> GetStudents(bool bringSubjects = false)
        {
            List<Student> students;
            using (Context context = new Context())
            {
                if (bringSubjects)
                    students = this.GetStudentsWithEagerLoading(context);
                else
                    students = this.GetStudentsWithLazyLoading(context);
            }
            return students;
        }

        public void ModifyStudent(Student studentToModify)
        {
            using (Context context = new Context())
            {
                var studentOnDB = context.people.OfType<Student>().Include("Subjects").Where(t => t.PersonOID.Equals(studentToModify.PersonOID)).FirstOrDefault();

                var deletedSubjects = this.GetDeletedSubjects(studentOnDB, studentToModify);
                var addedSubjects = this.GetAddedSubjects(studentOnDB, studentToModify);
                this.UpdateSubjects(context, studentOnDB, addedSubjects, deletedSubjects);
                this.UpdatePickUpServiceData(studentOnDB, studentToModify);

                studentOnDB.Name = studentToModify.Name;
                studentOnDB.LastName = studentToModify.LastName;

                context.SaveChanges();
            }
        }

        #region Private Methods
        private List<Subject> GetDeletedSubjects(Student studentOnDB, Student studentToModify)
        {
            return studentOnDB.Subjects.Where(systemSubject => !studentToModify.Subjects.Any(studentSubject => systemSubject.Code.Equals(studentSubject.Code))).ToList();
        }
        private List<Subject> GetAddedSubjects(Student studentOnDB, Student studentToModify)
        {
            return studentToModify.Subjects.Where(studentToModifySubject => !studentOnDB.Subjects.Any(studentOnDBSubject => studentToModifySubject.Code.Equals(studentOnDBSubject.Code))).ToList();
        }
        private void UpdateSubjects(Context context, Student studentOnDB, List<Subject> addedSubjects, List<Subject> deletedSubjects)
        {
            deletedSubjects.ForEach(s => studentOnDB.Subjects.Remove(s));
            foreach (Subject s in addedSubjects)
            {
                if (context.Entry(s).State == EntityState.Detached)
                    context.subjects.Attach(s);

                studentOnDB.Subjects.Add(s);
            }
        }
        private void UpdatePickUpServiceData(Student studentOnDB, Student studentToModify)
        {
            if (studentOnDB.HavePickUpService != studentToModify.HavePickUpService)
            {
                studentOnDB.HavePickUpService = studentToModify.HavePickUpService;
                studentOnDB.Location.Latitud = studentToModify.Location.Latitud;
                studentOnDB.Location.Longitud = studentToModify.Location.Longitud;
            }
        }
        private List<Student> GetStudentsWithEagerLoading(Context context)
        {
            return (from student in context.people.OfType<Student>().Include("Subjects")
                    select student).ToList();
        }
        private List<Student> GetStudentsWithLazyLoading(Context context)
        {
            return (from student in context.people.OfType<Student>()
                    select student).ToList();
        }
        #endregion
    }
}