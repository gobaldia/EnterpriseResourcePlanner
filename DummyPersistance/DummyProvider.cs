using CoreLogic;
using CoreLogic.Interfaces;
using DummyPersistance.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyPersistance
{
    public class DummyProvider
    {
        private ITeacherLogic teachersLogic;
        private IStudentLogic studentsLogic;
        private ISubjectLogic subjectsLogic;
        //private IVehicleLogic vehiclesLogic;

        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<DummyProvider> instance = new Lazy<DummyProvider>(() => new DummyProvider());
        private DummyProvider()
        {
            this.teachersLogic = new TeacherLogic(new TeacherDummyPersistance());
            this.studentsLogic = new StudentLogic(new StudentDummyPersistance());
            this.subjectsLogic = new SubjectLogic(new SubjectDummyPersistance());
            //this.vehiclesLogic = new VehicleLogic(new VehiclePersistance());
        }
        public static DummyProvider GetInstance
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

        //public IVehicleLogic GetVehicleOperations()
        //{
        //    return this.vehiclesLogic;
        //}
    }
}
