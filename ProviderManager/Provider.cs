﻿using CoreLogic;
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
        //private List<Subject> subjects;
        //private List<Vehicle> vehicles;

        #region Singleton
        // Variable estática para la instancia, se necesita utilizar una función lambda ya que el constructor es privado.
        private static readonly Lazy<Provider> instance = new Lazy<Provider>(() => new Provider());
        private Provider()
        {
            this.teachersLogic = new TeacherLogic(new TeacherPersistance());
            //this.subjects = new List<Subject>();
            //this.students = new List<Student>();
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

        public ITeacherLogic GetTeacherLogicOperations()
        {
            return this.teachersLogic;
        }
    }
}