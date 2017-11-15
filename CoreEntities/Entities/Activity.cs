using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
        public List<Student> Students { get; set; }

        public static int activitiesCount = 0;

        public Activity()
        {
            this.Id = activitiesCount++;
            this.Name = string.Empty;
            this.Date = new DateTime(1970, 1, 1);
            this.Cost = 0;
            this.Students = new List<Student>();
        }

        public Activity(string name, DateTime date, int cost)
        {
            this.Id = activitiesCount++;
            this.Name = name;
            this.Date = date;
            this.Cost = cost;
            this.Students = new List<Student>();
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
