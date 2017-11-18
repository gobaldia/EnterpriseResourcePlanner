using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface ISubjectPersistance
    {
        void AddSubject(Subject newSubject);
        void DeleteSubject(Subject subjectToDelete);
        void ModifySubject(Subject subjectToModify);
        List<Subject> GetSubjects();
        Subject GetSubjectByCode(int code);
    }
}
