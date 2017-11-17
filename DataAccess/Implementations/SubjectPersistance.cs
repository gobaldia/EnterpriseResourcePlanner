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
    }
}
