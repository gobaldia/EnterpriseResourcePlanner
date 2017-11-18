using CoreLogic;
using CoreLogic.Interfaces;
using DataAccess.Implementations;
using System;

namespace ProviderManager
{
    public class Provider
    {
        private ITeacherLogic teachersLogic;
        private IStudentLogic studentsLogic;
        private ISubjectLogic subjectsLogic;
        //private List<Vehicle> vehicles;

        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<Provider> instance = new Lazy<Provider>(() => new Provider());
        private Provider()
        {
            this.teachersLogic = new TeacherLogic(new TeacherPersistance());
            this.studentsLogic = new StudentLogic(new StudentPersistance());
            this.subjectsLogic = new SubjectLogic(new SubjectPersistance());
            //this.vehicles = new List<Vehicle>();
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

        public IStudentLogic GetStudentOperations()
        {
            return this.studentsLogic;
        }
    }
}
