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
    public class SubjectPersistance : ISubjectPersistance
    {
        public void AddSubject(Subject newSubject)
        {
            using (Context context = new Context())
            {
                context.subjects.Add(newSubject);
                context.SaveChanges();
            }
        }

        public void DeleteSubject(Subject subjectToDelete)
        {
            using (Context context = new Context())
            {
                context.subjects.Attach(subjectToDelete);
                context.subjects.Remove(subjectToDelete);
                context.SaveChanges();
            }
        }

        public void ModifySubject(Subject subjectToModify)
        {
            using (Context context = new Context())
            {
                var subjectOnDB = context.subjects.Include("Teachers").Where(s => s.SubjectOID.Equals(subjectToModify.SubjectOID)).FirstOrDefault();

                var deletedTeachers = this.GetDeletedTeachers(subjectOnDB, subjectToModify);
                var addedTeachers = this.GetAddedTeachers(subjectOnDB, subjectToModify);
                this.UpdateTeachers(context, subjectOnDB, addedTeachers, deletedTeachers);

                var deletedStudents = this.GetDeletedStudents(subjectOnDB, subjectToModify);
                var addedStudents = this.GetAddedStudents(subjectOnDB, subjectToModify);
                this.UpdateStudents(context, subjectOnDB, addedStudents, deletedStudents);

                subjectOnDB.Name = subjectToModify.Name;
                subjectOnDB.Code = subjectToModify.Code;

                context.SaveChanges();
            }
        }

        public List<Subject> GetSubjects()
        {
            var subjects = new List<Subject>();
            using (Context context = new Context())
            {
                var query = from subject in context.subjects
                            select subject;

                foreach (var subject in query)
                    subjects.Add(subject);
            }
            return subjects;
        }

        public Subject GetSubjectByCode(int code)
        {
            Subject subjectFound;
            using (Context context = new Context())
            {
                var queryResult = (from subject in context.subjects.Include("Teachers").Include("Students")
                                   where subject.Code.Equals(code)
                                   select subject).FirstOrDefault();

                subjectFound = queryResult;
            }
            return subjectFound;
        }

        #region Private Methods
        private List<Teacher> GetDeletedTeachers(Subject subjectOnDB, Subject subjectToModify)
        {
            return (from dbTeacher in subjectOnDB.Teachers
                    where !(from memoryTeacher in subjectToModify.Teachers
                            select memoryTeacher.PersonOID)
                            .Contains(dbTeacher.PersonOID)
                    select dbTeacher).ToList();
        }

        private List<Teacher> GetAddedTeachers(Subject subjectOnDB, Subject subjectToModify)
        {
            return (from memoryTeacher in subjectToModify.Teachers
                    where !(from dbTeacher in subjectOnDB.Teachers
                            select dbTeacher.PersonOID)
                            .Contains(memoryTeacher.PersonOID)
                    select memoryTeacher).ToList();
        }

        private void UpdateTeachers(Context context, Subject subjectOnDB, List<Teacher> addedTeachers, List<Teacher> deletedTeachers)
        {
            deletedTeachers.ForEach(c => subjectOnDB.Teachers.Remove(c));
            foreach (Teacher t in addedTeachers)
            {
                if (context.Entry(t).State == EntityState.Detached)
                    context.people.Attach(t);

                subjectOnDB.Teachers.Add(t);
            }
        }

        private List<Student> GetDeletedStudents(Subject subjectOnDB, Subject subjectToModify)
        {
            return (from dbStudent in subjectOnDB.Students
                    where !(from memoryStudent in subjectToModify.Students
                            select memoryStudent.PersonOID)
                            .Contains(dbStudent.PersonOID)
                    select dbStudent).ToList();
        }

        private List<Student> GetAddedStudents(Subject subjectOnDB, Subject subjectToModify)
        {
            return (from memoryStudent in subjectToModify.Students
                    where !(from dbStudent in subjectOnDB.Students
                            select dbStudent.PersonOID)
                            .Contains(memoryStudent.PersonOID)
                    select memoryStudent).ToList();
        }
        private void UpdateStudents(Context context, Subject subjectOnDB, List<Student >addedStudents, List<Student> deletedStudents)
        {
            deletedStudents.ForEach(c => subjectOnDB.Students.Remove(c));
            foreach (Student t in addedStudents)
            {
                if (context.Entry(t).State == EntityState.Detached)
                    context.people.Attach(t);

                subjectOnDB.Students.Add(t);
            }
        }
        #endregion
    }
}