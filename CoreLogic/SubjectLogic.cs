using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using DataContracts;
using System.Collections.Generic;

namespace CoreLogic
{
    public class SubjectLogic : ISubjectLogic
    {
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

            var subjectIndexToModify = persistanceProvider.GetSubjectByCode(code);
            newSubjectValues.SubjectOID = subjectIndexToModify.SubjectOID;

            this.persistanceProvider.ModifySubject(newSubjectValues);
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
