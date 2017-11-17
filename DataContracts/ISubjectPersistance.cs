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
        List<Subject> GetSubjects();
    }
}
