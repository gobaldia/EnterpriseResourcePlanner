using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class ActivityLogic
    {
        private List<Activity> systemActivities = SystemData.GetInstance.GetActivities();

        public List<Activity> GetActivities()
        {
            return systemActivities;
        }

        public void AddActivity(Activity newActivity)
        {
            if (this.IsActivityInSystem(newActivity))
                throw new CoreException("Activity already exists.");
            else
                this.systemActivities.Add(newActivity);
        }

        private bool IsActivityInSystem(Activity activity)
        {
            return this.systemActivities.Exists(item => item.Equals(activity));
        }

        public void ModifyActivityById(int id, Activity newActivity)
        {
            var activityIndexToModify = this.systemActivities.FindIndex(a => a.Id == id);
            this.systemActivities[activityIndexToModify].Name = newActivity.Name;
            this.systemActivities[activityIndexToModify].Date = newActivity.Date;
            this.systemActivities[activityIndexToModify].Cost = newActivity.Cost;
            this.systemActivities[activityIndexToModify].Students = newActivity.Students;
        }

        public Activity GetActivityById(int id)
        {
            var activity = this.systemActivities.Where(a => a.Id == id);
            if (activity == null)
                throw new CoreException("There's no activity with this id.");
            return activity.First();
        }
    }
}
