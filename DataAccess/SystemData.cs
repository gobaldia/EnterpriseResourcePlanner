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
        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<SystemData> instance = new Lazy<SystemData>(() => new SystemData());
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
        #endregion

        private List<Teacher> teachers;
        private List<Subject> subjects;

        public void Reset()
        {
            this.teachers.Clear();
            this.subjects.Clear();
        }        

        public List<Teacher> GetSystemTeachers()
        {
            return this.teachers;
        }
        public List<Subject> GetSystemSubjects()
        {
            return this.subjects;
        }

        #region Teacher Methods
        public void AddTeacher(Teacher newTeacher)
        {
            if (this.IsTeacherInSystem(newTeacher))
                throw new CoreException("Teacher already exists.");

            this.teachers.Add(newTeacher);
        }


        private bool IsTeacherInSystem(Teacher aTeacher)
        {
            return this.teachers.Exists(item => item.Equals(aTeacher));
        }
        #endregion

        #region Student Methods
        #endregion

        #region Subject Methods
        #endregion

        #region Subject Methods
        #endregion
    }
}