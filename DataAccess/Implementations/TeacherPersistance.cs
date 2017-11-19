using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;
using System.Data.Entity;

namespace DataAccess.Implementations
{
    public class TeacherPersistance : ITeacherPersistance
    {
        public void AddTeacher(Teacher newTeacher)
        {
            using (Context context = new Context())
            {
                context.people.Attach(newTeacher);
                context.people.Add(newTeacher);
                context.SaveChanges();
            }
        }

        public void DeleteTeacher(Teacher teacherToDelete)
        {
            using (Context context = new Context())
            {
                context.people.Attach(teacherToDelete);
                context.people.Remove(teacherToDelete);
                context.SaveChanges();
            }
        }

        public List<Teacher> GetTeachers(bool bringSubjects = false)
        {
            List<Teacher> teachers;
            using (Context context = new Context())
            {
                if (bringSubjects)
                    teachers = this.GetTeachersWithEagerLoading(context);
                else
                    teachers = this.GetTeachersWithLazyLoading(context);

            }
            return teachers;
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {
            Teacher teacherFound;
            using (Context context = new Context())
            {
                var queryResult = (from teacher in (context.people.OfType<Teacher>()).Include("Subjects")
                            where teacher.Document.Equals(documentNumber) select teacher).FirstOrDefault();

                teacherFound = queryResult;
            }
            return teacherFound;
        }

        public void ModifyTeacher(Teacher teacherToModify)
        {
            using (Context context = new Context())
            {
                var teacherOnDB = context.people.OfType<Teacher>().Include("Subjects").Where(t => t.PersonOID.Equals(teacherToModify.PersonOID)).FirstOrDefault();

                var deletedSubjects = this.GetDeletedSubjects(teacherOnDB, teacherToModify);
                var addedSubjects = this.GetAddedSubjects(teacherOnDB, teacherToModify);
                this.UpdateSubjects(context, teacherOnDB, addedSubjects, deletedSubjects);

                teacherOnDB.Name = teacherToModify.Name;
                teacherOnDB.LastName = teacherToModify.LastName;

                context.SaveChanges();
            }
        }

        #region Private Methods
        private List<Subject> GetDeletedSubjects(Teacher teacherOnDB, Teacher teacherToModify)
        {
            return (from dbSubject in teacherOnDB.Subjects
                    where !(from memorySubject in teacherToModify.Subjects
                            select memorySubject.SubjectOID)
                            .Contains(dbSubject.SubjectOID)
                    select dbSubject).ToList();
        }

        private List<Subject> GetAddedSubjects(Teacher teacherOnDB, Teacher teacherToModify)
        {
            return (from memorySubject in teacherToModify.Subjects
                    where !(from dbSubject in teacherOnDB.Subjects
                            select dbSubject.SubjectOID)
                            .Contains(memorySubject.SubjectOID)
                    select memorySubject).ToList();
        }

        private void UpdateSubjects(Context context, Teacher teacherOnDB, List<Subject> addedSubjects, List<Subject> deletedSubjects)
        {
            deletedSubjects.ForEach(c => teacherOnDB.Subjects.Remove(c));
            foreach (Subject c in addedSubjects)
            {
                if (context.Entry(c).State == EntityState.Detached)
                    context.subjects.Attach(c);

                teacherOnDB.Subjects.Add(c);
            }
        }
        
        private List<Teacher> GetTeachersWithEagerLoading(Context context)
        {
            return (from teacher in context.people.OfType<Teacher>().Include("Subjects")
                    select teacher).ToList();
        }
        private List<Teacher> GetTeachersWithLazyLoading(Context context)
        {
            return (from teacher in context.people.OfType<Teacher>()
                    select teacher).ToList();
        }
        #endregion
    }
}
