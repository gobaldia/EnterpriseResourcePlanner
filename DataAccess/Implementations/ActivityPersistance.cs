using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;
using System.Data.Entity;

namespace DataAccess.Implementations
{
    public class ActivityPersistance : IActivityPersistance
    {
        public void AddActivity(Activity newActivity)
        {
            using (Context context = new Context())
            {
                context.activities.Add(newActivity);
                context.SaveChanges();
            }
        }

        public void DeleteActivity(Activity activityToDelete)
        {
            using (Context context = new Context())
            {
                context.activities.Attach(activityToDelete);
                context.activities.Remove(activityToDelete);
                context.SaveChanges();
            }
        }

        public List<Activity> GetActivities()
        {
            var activities = new List<Activity>();
            using (Context context = new Context())
            {
                var query = from activity in context.activities.Include("Students")
                            select activity;

                foreach (var activity in query)
                    activities.Add(activity);
            }
            return activities;
        }

        public Activity GetActivityById(int id)
        {
            Activity activityFound;
            using (Context context = new Context())
            {
                var queryResult = (from activity in (context.activities).Include("Students")
                                   where activity.Id.Equals(id)
                                   select activity).FirstOrDefault();

                activityFound = queryResult;
            }
            return activityFound;
        }

        public void ModifyActivity(Activity activityToModify)
        {
            using (Context context = new Context())
            {
                var activityOnDB = context.activities.OfType<Activity>().Include("Students").Where(a => a.ActivityOID.Equals(activityToModify.ActivityOID)).FirstOrDefault();

                var deletedStudents = this.GetDeletedStudents(activityOnDB, activityToModify);
                var addedStudents = this.GetAddedStudents(activityOnDB, activityToModify);
                this.UpdateSubjects(context, activityOnDB, addedStudents, deletedStudents);

                activityOnDB.Name = activityToModify.Name;
                activityOnDB.Cost= activityToModify.Cost;
                activityOnDB.Date = activityToModify.Date;

                context.SaveChanges();
            }
        }

        private List<Student> GetDeletedStudents(Activity activityOnDB, Activity activityToModify)
        {
            //return (from dbStudent in activityOnDB.Students
            //        where !(from memoryStudent in activityToModify.Students
            //                select memoryStudent.PersonOID)
            //                .Contains(dbStudent.PersonOID)
            //        select dbStudent).ToList();

            return activityOnDB.Students
                .Where(activityStudent => !activityToModify
                .Students.Any(actToModifyStudent => activityStudent.PersonOID
                .Equals(actToModifyStudent.PersonOID))).ToList();
        }

        private List<Student> GetAddedStudents(Activity activityOnDB, Activity activityToModify)
        {
            return (from memoryStudent in activityToModify.Students
                    where !(from dbStudent in activityOnDB.Students
                            select dbStudent.PersonOID)
                            .Contains(memoryStudent.PersonOID)
                    select memoryStudent).ToList();
        }

        private void UpdateSubjects(Context context, Activity activityOnDB, List<Student> addedStudents, List<Student> deletedStudents)
        {
            deletedStudents.ForEach(c => activityOnDB.Students.Remove(c));
            foreach (Student c in addedStudents)
            {
                if (context.Entry(c).State == EntityState.Detached)
                    context.people.Attach(c);

                activityOnDB.Students.Add(c);
            }
        }

        public int GetNextActivityNumber()
        {
            int activityNumber = 0;
            using (Context context = new Context())
            {
                var activities = context.activities;
                if (activities?.Count() > 0)
                {
                    var activity = activities.OrderByDescending(item => item.Id).First();
                    activityNumber = activity.Id;
                }
            }
            return ++activityNumber;
        }
    }
}
