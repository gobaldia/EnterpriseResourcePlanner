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
            this.dummySystemActivities.Add(newActivity);
        }

        public void DeleteActivity(Activity activityToDelete)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetActivities()
        {
            return this.dummySystemActivities;
        }

        public Activity GetActivityById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNextActivityNumber()
        {
            throw new NotImplementedException();
        }

        public void ModifyActivity(Activity activityToModify)
        {
            throw new NotImplementedException();
        }
    }
}
