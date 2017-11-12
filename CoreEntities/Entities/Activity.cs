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
        public string Date { get; set; }
        public int Cost { get; set; }

        public Activity()
        {
            this.Name = string.Empty;
            this.Id = 0;
            this.Date = string.Empty;
            this.Cost = 0;
        }

        public Activity(string name, int id, string date, int cost)
        {
            this.Name = name;
            this.Id = id;
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
