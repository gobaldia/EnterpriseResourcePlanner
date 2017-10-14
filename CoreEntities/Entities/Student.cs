using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Student : Person
    {
        public int StudentNumber { get; set; }
        public List<Subject> subjects { get; set; }

        public Student()
        {
            base.Name = string.Empty;
            base.LastName = string.Empty;
            this.subjects = new List<Subject>();
        }
        public Student(string name, string lastName, string documentNumber, int studentNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Document = documentNumber;
            this.StudentNumber = studentNumber;
            this.subjects = new List<Subject>();
        }

        public string GetDocumentNumber()
        {
            return base.Document;
        }
    }
}
