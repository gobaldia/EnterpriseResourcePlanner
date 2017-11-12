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

        public List<Teacher> GetAllTeacher()
        {
            var teachers = new List<Teacher>();
            using (Context context = new Context())
            {
                var query = from teacher in context.people.OfType<Teacher>()
                            select teacher;

                foreach (var teacher in query)
                {
                    teachers.Add(teacher);
                }
            }
            return teachers;
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {
            Teacher teacherFound;
            using (Context context = new Context())
            {
                var queryResult = (from teacher in context.people.OfType<Teacher>()
                            where teacher.Document.Equals(documentNumber) select teacher).FirstOrDefault();

                teacherFound = queryResult;
            }
            return teacherFound;
        }

        public void ModifyTeacher(Teacher teacherToModify)
        {
            using (Context context = new Context())
            {
                context.people.Attach(teacherToModify);
                context.Entry(teacherToModify).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
