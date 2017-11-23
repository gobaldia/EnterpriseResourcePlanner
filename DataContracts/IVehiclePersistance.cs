using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface IVehiclePersistance
    {
        List<Vehicle> GetVehicles();
        void AddVehicle(Vehicle newVehicle);
        void DeleteVehicle(Vehicle vehicleToDelete);
        void ModifyVehicle(Vehicle vehicleToModify);
        Vehicle GetVehicleByRegistration(string registration);
        bool IsVehicleInSystem(Vehicle aVehicle);
        List<Student> GetStudentsWithPickUpService();
        List<Vehicle> GetVehiclesOrderedByCapacityPerFuelConsumption();
    }
}
