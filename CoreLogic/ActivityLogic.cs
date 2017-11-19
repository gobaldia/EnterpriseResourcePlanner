using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using DataAccess;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class ActivityLogic : IActivityLogic
    {
        private List<Activity> systemActivities = SystemData.GetInstance.GetActivities();
        private IActivityPersistance persistanceProvider;

        public ActivityLogic(IActivityPersistance provider)
        {
            this.persistanceProvider = provider;
        }

        public void AddActivity(Activity newActivity)
        {
            //if (this.IsActivityInSystem(newActivity))
            //    throw new CoreException("Activity already exists.");
            //else
                this.persistanceProvider.AddActivity(newActivity);
        }

        private bool IsActivityInSystem(Activity activity)
        {
            var systemActivities = this.persistanceProvider.GetActivities();
            return systemActivities.Exists(item => item.Equals(activity));
        }

        public void ModifyActivityById(int id, Activity newActivity)
        {
            var activityToModify = this.persistanceProvider.GetActivityById(id);
            newActivity.ActivityOID = activityToModify.ActivityOID;
            this.persistanceProvider.ModifyActivity(newActivity);
        }

        public void DeleteActivityById(int id)
        {
            var systemActivities = this.persistanceProvider.GetActivities();
            var activityToDelete = systemActivities.Find(a => a.Id == id);
            if (activityToDelete == null)
                throw new CoreException("There's no activity with this id.");
            this.persistanceProvider.DeleteActivity(activityToDelete);
        }

        public Activity GetActivityById(int id)
        {
            var activity = this.persistanceProvider.GetActivityById(id);
            //var activity = this.systemActivities.Where(a => a.Id == id);
            if (activity == null)
                throw new CoreException("There's no activity with this id.");
            return activity;
        }

        public List<Activity> GetActivities()
        {
            return this.persistanceProvider.GetActivities();
        }

        public int GetNextActivityNumber()
        {
            return this.persistanceProvider.GetNextActivityNumber();
        }

        //public List<Activity> GetActivities()
        //{
        //    return systemActivities;
        //}

        //public void AddActivity(Activity newActivity)
        //{
        //    if (this.IsActivityInSystem(newActivity))
        //        throw new CoreException("Activity already exists.");
        //    else
        //        this.systemActivities.Add(newActivity);
        //}

        //private bool IsActivityInSystem(Activity activity)
        //{
        //    return this.systemActivities.Exists(item => item.Equals(activity));
        //}

        //public void ModifyActivityById(int id, Activity newActivity)
        //{
        //    var activityIndexToModify = this.systemActivities.FindIndex(a => a.Id == id);
        //    this.systemActivities[activityIndexToModify].Name = newActivity.Name;
        //    this.systemActivities[activityIndexToModify].Date = newActivity.Date;
        //    this.systemActivities[activityIndexToModify].Cost = newActivity.Cost;
        //    this.systemActivities[activityIndexToModify].Students = newActivity.Students;
        //}

        //public Activity GetActivityById(int id)
        //{
        //    var activity = this.systemActivities.Where(a => a.Id == id);
        //    if (activity == null)
        //        throw new CoreException("There's no activity with this id.");
        //    return activity.First();
        //}

        //public void DeleteActivityById(int id)
        //{
        //    var activityToDelete = this.systemActivities.Find(a => a.Id == id);
        //    if (activityToDelete == null)
        //        throw new CoreException("There's no activity with this id.");
        //    this.systemActivities.Remove(activityToDelete);
        //}
    }
}
