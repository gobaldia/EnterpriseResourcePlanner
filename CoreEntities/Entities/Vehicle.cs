using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Vehicle
    {
        public string Registration { get; set; }
        public int Capacity { get; set; }

        public Vehicle()
        {
            this.Registration = "AAA0000";
            this.Capacity = 1;
        }

        public Vehicle(string registration, int capacity)
        {
            this.Registration = registration;
            this.Capacity = capacity;
        }
    }
}
