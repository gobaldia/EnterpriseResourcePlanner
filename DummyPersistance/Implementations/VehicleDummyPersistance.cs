using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyPersistance.Implementations
{
    public class VehicleDummyPersistance : IVehiclePersistance
    {
        private List<Vehicle> dummySystemVehicles = SystemDummyData.GetInstance.GetVehicles();
        private List<Student> dummySystemStudents = SystemDummyData.GetInstance.GetStudents();

        public void AddVehicle(Vehicle newVehicle)
        {
            dummySystemVehicles.Add(newVehicle);
        }

        public void DeleteVehicle(Vehicle vehicleToDelete)
        {
            dummySystemVehicles.Remove(vehicleToDelete);
        }

        public List<Student> GetStudentsWithPickUpService()
        {
            return dummySystemStudents.Where(s => s.HavePickUpService).ToList();
        }

        public Vehicle GetVehicleByRegistration(string registration)
        {
            return dummySystemVehicles.Find(v => v.Registration.Equals(registration));
        }

        public List<Vehicle> GetVehicles()
        {
            return dummySystemVehicles;
        }

        public bool IsVehicleInSystem(Vehicle aVehicle)
        {
            return dummySystemVehicles.Any(v => v.Registration.Equals(aVehicle.Registration));
        }

        public void ModifyVehicle(Vehicle vehicleToModify)
        {
            var systemVehicle = this.GetVehicleByRegistration(vehicleToModify.Registration);
            systemVehicle.Registration = vehicleToModify.Registration;
            systemVehicle.Capacity = vehicleToModify.Capacity;
            systemVehicle.FuelConsumptionKmsPerLtr = vehicleToModify.FuelConsumptionKmsPerLtr;
        }
    }
}
