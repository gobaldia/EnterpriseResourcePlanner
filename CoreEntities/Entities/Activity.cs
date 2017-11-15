using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Activity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }

        public static int activitiesCount = 0;

        public Activity()
        {
            this.Name = string.Empty;
            this.Id = activitiesCount++;
            this.Date = new DateTime(1970, 1, 1);
            this.Cost = 0;
        }

        public Activity(string name, DateTime date, int cost)
        {
            this.Name = name;
            this.Id = activitiesCount++;
            this.Date = date;
            this.Cost = cost;
        }

        public override bool Equals(object obj)
        {
            if (obj is Activity)
                return this.Id == ((Activity) obj).Id;
            else
                return false;
        }
    }
}
