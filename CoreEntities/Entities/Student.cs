using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Student : Person
    {
        private static int studentsCount = 0;
        private List<Subject> subjects { get; set; }
        private int studentNumber { get; set; }

        public Student()
        {
            this.studentNumber = ++studentNumber;
            base.Name = string.Empty;
            base.LastName = string.Empty;
            this.subjects = new List<Subject>();
        }
        public Student(string name, string lastName, string documentNumber)
        {
            this.studentNumber = ++studentNumber;
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
        public List<Subject> GetSubjects()
        {
            return this.subjects;
        }
        public static int GetNextStudentNumber()
        {
            return studentsCount + 1;
        }

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
    }
}
