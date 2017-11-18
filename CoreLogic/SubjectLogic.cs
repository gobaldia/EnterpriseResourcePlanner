using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using DataAccess;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class SubjectLogic : ISubjectLogic
    {
        private List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();
        private ISubjectPersistance persistanceProvider;

        public SubjectLogic(ISubjectPersistance provider)
        {
            this.persistanceProvider = provider;
        }

        public void AddSubject(Subject newSubject)
        {
            if (this.IsSubjectInSystem(newSubject))
                throw new CoreException("Subject already exists.");

            this.persistanceProvider.AddSubject(newSubject);
        }

        public void ModifySubjectByCode(int code, Subject newSubjectValues)
        {
            if (newSubjectValues.Code != code && this.IsSubjectInSystemByCode(newSubjectValues.Code))
                throw new CoreException("Subject already exists.");
            else
            {
                var subjectIndexToModify = this.systemSubjects.FindIndex(s => s.Code == code);
                this.systemSubjects[subjectIndexToModify].SetCode(newSubjectValues.Code);
                this.systemSubjects[subjectIndexToModify].SetName(newSubjectValues.Name);
                this.systemSubjects[subjectIndexToModify].SetTeachers(newSubjectValues.Teachers);
            }
        }

        public void DeleteSubjectByCode(int code)
        {
            if (!IsSubjectInSystemByCode(code))
                throw new CoreException("This subject is not in system.");
            
            var subjectToDelete = this.GetSubjectByCode(code);
            this.persistanceProvider.DeleteSubject(subjectToDelete);
        }

        public List<Subject> GetSubjects()
        {
            return this.persistanceProvider.GetSubjects();
        }
        
        public Subject GetSubjectByCode(int subjectCode)
        {
            return this.persistanceProvider.GetSubjectByCode(subjectCode);
        }

        #region Private methods
        private bool IsSubjectInSystem(Subject subject)
        {
            var systemSubjects = this.persistanceProvider.GetSubjects();
            return systemSubjects.Exists(item => item.Equals(subject));
        }

        private bool IsSubjectInSystemByCode(int code)
        {
            var systemSubjects = this.persistanceProvider.GetSubjects();
            return systemSubjects.Exists(item => item.Code.Equals(code));
        }
        #endregion
    }
}
