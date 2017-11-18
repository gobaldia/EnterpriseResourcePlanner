using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Teacher : Person
    {
        public virtual List<Subject> Subjects { get; set; }

        public Teacher()
        {
            base.Name = string.Empty;
            base.LastName = string.Empty;
            this.Subjects = new List<Subject>();
        }
        public Teacher(string name, string lastName, string documentNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Document = documentNumber;
            this.Subjects = new List<Subject>();
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
            return this.Subjects;
        }
        public void AddSubjectToTeach(Subject subjectToBeTeach)
        {
            this.Subjects.Add(subjectToBeTeach);
        }
        public void RemoveSubject(Subject subjectToRemove)
        {
            this.Subjects.Remove(subjectToRemove);
        }
        public void ModifySubjects(List<Subject> newSubjects)
        {
            this.Subjects.Clear();
            foreach (Subject subject in newSubjects)
            {
                this.Subjects.Add(subject);
            }
        }

        public override string ToString()
        {
            return string.Format("Full name: {0}, Document number: {1}", GetFullName(), GetDocumentNumber());
        }
        public override bool Equals(object obj)
        {
            if(obj is Teacher)
                return this.GetDocumentNumber().Equals(((Teacher)obj).GetDocumentNumber());
            else
                return false;
        }
    }
}
