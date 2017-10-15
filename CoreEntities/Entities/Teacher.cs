using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Teacher : Person
    {
        private List<Subject> subjects { get; set; }

        public Teacher()
        {
            base.Name = string.Empty;
            base.LastName = string.Empty;
            this.subjects = new List<Subject>();
        }
        public Teacher(string name, string lastName, string documentNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Document = documentNumber;
            this.subjects = new List<Subject>();
        }

        public string GetName()
        {
            return base.Name;
        }
        public string GetLastName()
        {
            return base.LastName;
        }
        public string GetDocumentNumber()
        {
            return base.Document;
        }
        public void SetName(string newName)
        {
            base.Name = newName;
        }
        public void SetLastName(string newLastName)
        {
            base.LastName = newLastName;
        }
        public List<Subject> GetSubjects()
        {
            return this.subjects;
        }
        public void AddSubjectToTeach(Subject subjectToBeTeach)
        {
            this.subjects.Add(subjectToBeTeach);
        }
        public void RemoveSubject(Subject subjectToRemove)
        {
            this.subjects.Remove(subjectToRemove);
        }
        public void ModifySubjects(List<Subject> newSubjects)
        {
            this.subjects.Clear();
            foreach (Subject subject in newSubjects)
            {
                this.subjects.Add(subject);
            }
        }

        public override bool Equals(object obj)
        {
            return this.GetDocumentNumber().Equals(((Teacher)obj).GetDocumentNumber());
        }
    }
}
