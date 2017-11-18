using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface IActivityLogic
    {
        void AddActivity(Activity newActivity);
        void DeleteActivityById(int id);
        void ModifyActivityById(int id, Activity activityToModify);
        List<Activity> GetActivities();
        Activity GetActivityById(int id);
        int GetNextActivityNumber();
    }
}
