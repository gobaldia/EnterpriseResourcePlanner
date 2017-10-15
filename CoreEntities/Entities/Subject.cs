using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        public Subject()
        {
            this.Code = 0;
            this.Name = string.Empty;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public Subject(int code, string name)
        {
            this.Code = code;
            this.Name = name;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public int GetCode()
        {
            return this.Code;
        }

        public string GetName()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Subject)
                return this.GetCode().Equals(((Subject)obj).GetCode());
            else
                return false;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Code, this.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
