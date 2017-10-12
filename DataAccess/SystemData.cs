using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SystemData
    {
        private static readonly Lazy<SystemData> instance = new Lazy<SystemData>(() => new SystemData());
        private List<Teacher> teachers;
        private List<Subject> subjects;

        private SystemData()
        {
            this.teachers = new List<Teacher>();
            this.subjects = new List<Subject>();
        }

        public static SystemData GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<Teacher> GetSystemTeachers()
        {
            return this.teachers;
        }

        
    }
}
