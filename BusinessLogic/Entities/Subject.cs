using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }

        public Subject()
        {
            this.Code = 0;
            this.Name = string.Empty;
            this.Teachers = new List<Teacher>();
        }

        public Subject(int code, string name)
        {
            this.Code = code;
            this.Name = name;
            this.Teachers = new List<Teacher>();
        }
    }
}
