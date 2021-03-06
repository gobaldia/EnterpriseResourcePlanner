﻿using CoreLogic;
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
        private IVehicleLogic vehiclesLogic;
        private IActivityLogic activitiesLogic;
        private IPaymentLogic paymentsLogic;

        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<Provider> instance = new Lazy<Provider>(() => new Provider());
        private Provider()
        {
            this.teachersLogic = new TeacherLogic(new TeacherPersistance());
            this.studentsLogic = new StudentLogic(new StudentPersistance());
            this.subjectsLogic = new SubjectLogic(new SubjectPersistance());
            this.vehiclesLogic = new VehicleLogic(new VehiclePersistance());
            this.activitiesLogic = new ActivityLogic(new ActivityPersistance());
            this.paymentsLogic = new PaymentLogic(new PaymentPersistence());
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

        public IVehicleLogic GetVehicleOperations()
        {
            return this.vehiclesLogic;
        }

        public IActivityLogic GetActivityOperations()
        {
            return this.activitiesLogic;
        }

        public IPaymentLogic GetPaymentOperations()
        {
            return this.paymentsLogic;
        }
    }
}
