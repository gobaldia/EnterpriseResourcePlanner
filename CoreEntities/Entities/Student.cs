using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Student : Person
    {
        #region Properties
        private static int studentsCount = 0;
        private List<Subject> subjects { get; set; }
        private int studentNumber { get; set; }
        private bool havePickUpService { get; set; } = false;
        private Location location { get; set; }
        #endregion

        public Student()
        {
            this.studentNumber = ++studentsCount;
            base.Name = string.Empty;
            base.LastName = string.Empty;
            this.subjects = new List<Subject>();
        }
        public Student(string name, string lastName, string documentNumber)
        {
            this.studentNumber = ++studentsCount;
            this.Name = name;
            this.LastName = lastName;
            this.Document = documentNumber;
            this.subjects = new List<Subject>();
        }

        #region Methods
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
        public int GetStudentNumber()
        {
            return this.studentNumber;
        }
        public void SetName(string newName)
        {
            base.Name = newName;
        }
        public void SetLastName(string newLastName)
        {
            base.LastName = newLastName;
        }
        public void SetPickUpService(bool pickup)
        {
            this.havePickUpService = pickup;
        }
        public void SetLocation(Location studentLocation)
        {
            this.location = studentLocation;
        }
        public Location GetLocation()
        {
            return this.location;
        }
        public bool HavePickUpService()
        {
            return this.havePickUpService;
        }
        public List<Subject> GetSubjects()
        {
            return this.subjects;
        }
        public void ModifySubjects(List<Subject> newSubjects)
        {
            this.subjects.Clear();
            foreach (Subject subject in newSubjects)
            {
                this.subjects.Add(subject);
            }
        }
        public static int GetNextStudentNumber()
        {
            return studentsCount + 1;
        }
        #endregion

        public void AddSubjectToStudent(Subject newSubject)
        {
            this.subjects.Add(newSubject);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
                return this.GetDocumentNumber().Equals(((Student)obj).GetDocumentNumber());
            else
                return false;
        }

        public override string ToString()
        {
            return this.GetFullName();
        }

        public string GetFullNameAndLocation()
        {
            return string.Format("{0}: {1}", this.GetFullName(), this.GetLocation());
        }
    }
}
