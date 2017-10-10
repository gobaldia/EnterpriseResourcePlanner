using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
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

        public string GetName()
        {
            return base.Name;
        }
        public string GetLastName()
        {
            return base.LastName;
        }
        public List<Subject> GetSubjects()
        {
            return this.subjects;
        }
    }
}
