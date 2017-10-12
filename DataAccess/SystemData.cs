using BusinessLogic.Entities;
using BusinessLogic.Exceptions;
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

        public List<Subject> GetSystemSubjects()
        {
            return this.subjects;
        }

        public void Reset()
        {
            this.teachers.Clear();
            this.subjects.Clear();
        }

        public void AddSubject(Subject newSubject)
        {
            if (this.IsSubjectInSystem(newSubject))
            {
                throw new CoreException("Subject already exists.");
            }
            else
            {
                this.subjects.Add(newSubject);
            }
        }

        private bool IsSubjectInSystem(Subject subject)
        {
            return this.subjects.Exists(item => item.Equals(subject));
        }
    }
}
