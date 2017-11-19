using CoreLogic;
using CoreLogic.Interfaces;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderManager
{
    public class Provider
    {
        private ITeacherLogic teachersLogic;
        //private List<Student> students;
        private ISubjectLogic subjectsLogic;
        //private List<Vehicle> vehicles;
        private IActivityLogic activitiesLogic;
        private IStudentLogic studentsLogic;

        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<Provider> instance = new Lazy<Provider>(() => new Provider());
        private Provider()
        {
            this.teachersLogic = new TeacherLogic(new TeacherPersistance());
            //this.subjects = new List<Subject>();
            this.subjectsLogic = new SubjectLogic(new SubjectPersistance());
            //this.vehicles = new List<Vehicle>();
            this.activitiesLogic = new ActivityLogic(new ActivityPersistance());
            this.studentsLogic = new StudentLogic(new StudentPersistance());
        }
        public static Provider GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        #endregion

        public ITeacherLogic GetTeacherOperations()
        {
            return this.teachersLogic;
        }
        public ISubjectLogic GetSubjectOperations()
        {
            return this.subjectsLogic;
        }

        public IActivityLogic GetActivityOperations()
        {
            return this.activitiesLogic;
        }

        public IStudentLogic GetStudentOperations()
        {
            return this.studentsLogic;
        }
    }
}
