using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class VehicleLogic
    {
        private List<Vehicle> systemVehicles = SystemData.GetInstance.GetVehicles();

        public void AddVehicle(Vehicle newVehicle)
        {
            if (this.IsVehicleInSystem(newVehicle))
                throw new CoreException("Vehicle already exists.");

            this.systemVehicles.Add(newVehicle);
        }

        public List<Vehicle> GetVehicles()
        {
            return this.systemVehicles;
        }

        private bool IsVehicleInSystem(Vehicle aVehicle)
        {
            return this.systemVehicles.Exists(item => item.Equals(aVehicle));
        }

        public void DeleteVehicle(Vehicle vehicleToDelete)
        {
            if(this.systemVehicles.Count == 0)
            {
                throw new CoreException("Currently there is not any vehicle in the system.");
            }
            else if (!IsVehicleInSystem(vehicleToDelete))
            {
                throw new CoreException("This vehicle is not in the sytem.");
            }
            else
            {
                this.systemVehicles.Remove(vehicleToDelete);
            }
        }
    }
}
