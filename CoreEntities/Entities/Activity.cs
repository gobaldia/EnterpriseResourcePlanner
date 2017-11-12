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

        public Activity()
        {
            this.Name = string.Empty;
            this.Id = 0;
            this.Date = new DateTime();
            this.Cost = 0;
        }

        public Activity(string name, int id, DateTime date, int cost)
        {
            this.Name = name;
            this.Id = id;
            this.Date = date;
            this.Cost = cost;
        }
    }
}
