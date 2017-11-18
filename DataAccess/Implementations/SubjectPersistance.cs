using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
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
                var queryResult = (from subject in context.subjects
                                   where subject.GetCode().Equals(code)
                                   select subject).FirstOrDefault();

                subjectFound = queryResult;
            }
            return subjectFound;
        }
    }
}
