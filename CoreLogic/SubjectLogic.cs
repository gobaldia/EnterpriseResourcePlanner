using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class SubjectLogic
    {
        private List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();

        public List<Subject> GetSubjects()
        {
            return this.systemSubjects;
        }

        public void AddSubject(Subject newSubject)
        {
            if (this.IsSubjectInSystem(newSubject))
            {
                throw new CoreException("Subject already exists.");
            }
            else
            {
                this.systemSubjects.Add(newSubject);
            }
        }

        public void ModifySubjectByCode(int code, Subject newSubjectValues)
        {
            var subjectIndexToModify = this.systemSubjects.FindIndex(s => s.Code == code);
            this.systemSubjects[subjectIndexToModify].SetCode(newSubjectValues.Code);
            this.systemSubjects[subjectIndexToModify].SetName(newSubjectValues.Name);
        }

        private bool IsSubjectInSystem(Subject subject)
        {
            return this.systemSubjects.Exists(item => item.Equals(subject));
        }
    }
}
