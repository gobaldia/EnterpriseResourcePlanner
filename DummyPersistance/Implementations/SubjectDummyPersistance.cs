using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace DummyPersistance.Implementations
{
    public class SubjectDummyPersistance : ISubjectPersistance
    {
        private List<Subject> dummySystemSubjects = SystemDummyData.GetInstance.GetSubjects();
        public void AddSubject(Subject newSubject)
        {
            dummySystemSubjects.Add(newSubject);
        }

        public void DeleteSubject(Subject subjectToDelete)
        {
            dummySystemSubjects.Remove(subjectToDelete);
        }

        public Subject GetSubjectByCode(int code)
        {
            return dummySystemSubjects.Find(s => s.Code.Equals(code));
        }

        public List<Subject> GetSubjects()
        {
            return dummySystemSubjects;
        }

        public void ModifySubject(Subject subjectToModify)
        {
            Subject systemSubject = GetSubjectByCode(subjectToModify.Code);
            systemSubject.Name = subjectToModify.Name;
            systemSubject.Students = subjectToModify.Students;
            systemSubject.Teachers = subjectToModify.Teachers;
        }
    }
}
