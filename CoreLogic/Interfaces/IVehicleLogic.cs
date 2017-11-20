using CoreEntities.Entities;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface IVehicleLogic
    {
        List<Vehicle> GetVehicles();
        void AddVehicle(Vehicle newVehicle);
        void DeleteVehicle(Vehicle vehicleToDelete);
        void ModifyVehicle(ModifyVehicleInput input);
        Vehicle GetVehicleByRegistration(string registration);
        List<Tuple<Student, double>> StudentsOrderedByDistanceToSchool();
        List<Tuple<Vehicle, List<Student>>> GetVehiclesOrderedByCapacityConsideringStudentsNumber();
        List<Vehicle> GetVehiclesOrderedByCapacityPerFuelConsumption();
        List<Tuple<Vehicle, List<Student>>> GetVehiclesOrderedByEfficiencyConsideringStudentsNumber();
    }
}
