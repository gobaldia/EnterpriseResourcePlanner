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
    }
}
