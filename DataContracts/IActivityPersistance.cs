using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface IActivityPersistance
    {
        void AddActivity(Activity newActivity);
        void DeleteActivity(Activity activityToDelete);
        void ModifyActivity(Activity activityToModify);
        List<Activity> GetActivities();
        Activity GetActivityById(int id);
    }
}
