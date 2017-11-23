using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface ISubjectLogic
    {   
        void AddSubject(Subject newSubject);
        void ModifySubjectByCode(int code, Subject newSubjectValues);
        void DeleteSubjectByCode(int code);
        List<Subject> GetSubjects();
        Subject GetSubjectByCode(int subjectCode);
    }
}
