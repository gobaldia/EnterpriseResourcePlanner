using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCommon.MethodParameters;

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

        public void ModifyVehicle(ModifyVehicleInput input)
        {
            Vehicle vehicleToModify = GetVehicleByRegistration(input.Registration);

            if(input.NewCapacity > 0)
            {
                vehicleToModify.SetCapacity(input.NewCapacity);
            }
            else
            {
                throw new CoreException("Capacity should be greater than 0.");
            }
        }

        public Vehicle GetVehicleByRegistration(string registration)
        {
            Vehicle vehicleFound = this.systemVehicles.Find(v => v.Registration.Equals(registration));
            if (vehicleFound == null)
            {
                throw new CoreException("Vehicle not found.");
            }
            else
            {
                return vehicleFound;
            }
        }
    }
}
