using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyPersistance.Implementations
{
    public class ActivityDummyPersistence : IActivityPersistance
    {
        private List<Activity> dummySystemActivities = SystemDummyData.GetInstance.GetActivities();

        public void AddActivity(Activity newActivity)
        {
            dummySystemActivities.Add(newActivity);
        }

        public void DeleteActivity(Activity activityToDelete)
        {
            dummySystemActivities.Remove(activityToDelete);
        }

        public List<Activity> GetActivities()
        {
            return this.dummySystemActivities;
        }

        public Activity GetActivityById(int id)
        {
            return this.dummySystemActivities.Find(a => a.Id == id);
        }

        public int GetNextActivityNumber()
        {
            return this.dummySystemActivities.OrderByDescending(a => a.Id).FirstOrDefault().Id;
        }

        public void ModifyActivity(Activity activityToModify)
        {
            var systemActivity = this.GetActivityById(activityToModify.Id);
            systemActivity.Name = activityToModify.Name;
            systemActivity.Date = activityToModify.Date;
            systemActivity.Cost = activityToModify.Cost;
            systemActivity.Students = activityToModify.Students;
        }
    }
}
