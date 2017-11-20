using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace DataAccess.Implementations
{
    public class VehiclePersistance : IVehiclePersistance
    {
        public void AddVehicle(Vehicle newVehicle)
        {
            using (Context context = new Context())
            {
                context.vehicles.Attach(newVehicle);
                context.vehicles.Add(newVehicle);
                context.SaveChanges();
            }
        }

        public void DeleteVehicle(Vehicle vehicleToDelete)
        {
            using (Context context = new Context())
            {
                context.vehicles.Attach(vehicleToDelete);
                context.vehicles.Remove(vehicleToDelete);
                context.SaveChanges();
            }
        }

        public void ModifyVehicle(Vehicle vehicleToModify)
        {
            using (Context context = new Context())
            {
                var vehicleOnDB = context.vehicles.Where(v => v.VehicleOID.Equals(vehicleToModify.VehicleOID)).FirstOrDefault();

                vehicleOnDB.Capacity = vehicleToModify.Capacity;

                context.SaveChanges();
            }
        }

        public Vehicle GetVehicleByRegistration(string registration)
        {
            Vehicle vehicleFound;
            using (Context context = new Context())
            {
                var queryResult = (from vehicle in context.vehicles
                                   where vehicle.Registration.Equals(registration)
                                   select vehicle).FirstOrDefault();

                vehicleFound = queryResult;
            }
            return vehicleFound;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles;
            using (Context context = new Context())
            {
                vehicles = (from vehicle in context.vehicles select vehicle).ToList();
            }
            return vehicles;
        }

        public bool IsVehicleInSystem(Vehicle aVehicle)
        {
            using (Context context = new Context())
            {
                return context.vehicles.Any(v => v.Registration.Equals(aVehicle.Registration));
            }
        }

        public List<Student> GetStudentsWithPickUpService()
        {
            List<Student> studentsWithPickUpService;

            using (Context context = new Context())
            {
                studentsWithPickUpService = (from student in context.people.OfType<Student>()
                                             where student.HavePickUpService select student).ToList();
            }

            return studentsWithPickUpService;
        }

        public List<Vehicle> GetVehiclesOrderedByCapacityPerFuelConsumption()
        {
            return this.GetVehicles().OrderByDescending(v => v.GetVehicleEfficiency()).ToList();
        }
    }
}
