﻿using CoreEntities.Exceptions;
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

        public int VehicleOID { get; set; }// This id is used by EntityFramework.
        public string Registration { get; set; }
        public int Capacity { get; set; }
        public int FuelConsumptionKmsPerLtr { get; set; }

        public Vehicle()
        {
            this.Registration = "AAA0000";
            this.Capacity = 1;
            this.FuelConsumptionKmsPerLtr = 1;
        }

        public Vehicle(string registration, int capacity)
        {
            if (capacity <= 0)
            {
                throw new CoreException("Vehicle's capacity should be greater than 0.");
            }
            if (!registrationRegex.IsMatch(registration))
            {
                throw new CoreException("Vehicle's registration should have the format ABC1234.");
            }
            this.Registration = registration;
            this.Capacity = capacity;
            this.FuelConsumptionKmsPerLtr = 1;
        }

        public Vehicle(string registration, int capacity, int fuelConsumption)
        {
            if (capacity <= 0)
            {
                throw new CoreException("Vehicle's capacity should be greater than 0.");
            }
            if (fuelConsumption <= 0)
            {
                throw new CoreException("Vehicle's fuel consumption should be greater than 0.");
            }
            if (!registrationRegex.IsMatch(registration))
            {
                throw new CoreException("Vehicle's registration should have the format ABC1234.");
            }
            this.Registration = registration;
            this.Capacity = capacity;
            this.FuelConsumptionKmsPerLtr = fuelConsumption;
        }

        public string GetFullToString()
        {
            return string.Format("{0} - Capacity: {1} - Kms/Ltr: {2}", GetRegistration(), GetCapacity(), GetFuelConsumption());
        }

        private int GetFuelConsumption()
        {
            return this.FuelConsumptionKmsPerLtr;
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

        public void SetCapacity(int capacity)
        {
            this.Capacity = capacity;
        }

        public int GetCapacity()
        {
            return this.Capacity;
        }

        public string GetRegistration()
        {
            return this.Registration;
        }

        public double GetVehicleEfficiency()
        {
            return this.FuelConsumptionKmsPerLtr + this.Capacity;
        }
    }
}
