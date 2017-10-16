using CoreEntities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Vehicle
    {
        private Regex registrationRegex = new Regex("^[A-Z]{3}[0-9]{4}$");
        public string Registration { get; set; }
        public int Capacity { get; set; }

        public Vehicle()
        {
            this.Registration = "AAA0000";
            this.Capacity = 1;
        }

        public Vehicle(string registration, int capacity)
        {
            if(capacity <= 0)
            {
                throw new CoreException("Vehicle's capacity should be greater than 0.");
            }
            if (!registrationRegex.IsMatch(registration))
            {
                throw new CoreException("Vehicle's registration should have the format ABC1234.");
            }
            this.Registration = registration;
            this.Capacity = capacity;
        }

        public override bool Equals(object obj)
        {
            if(obj is Vehicle)
            {
                return this.Registration == ((Vehicle)obj).Registration;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.Registration;
        }
    }
}
