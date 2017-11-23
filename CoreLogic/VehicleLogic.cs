using CoreEntities.Entities;
using CoreEntities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCommon.MethodParameters;
using CoreLogic.Interfaces;
using DataContracts;
using FrameworkCommon;

namespace CoreLogic
{
    public class VehicleLogic : IVehicleLogic
    {
        private IVehiclePersistance persistanceProvider;
        public VehicleLogic(IVehiclePersistance provider)
        {
            this.persistanceProvider = provider;
        }

        public List<Vehicle> GetVehicles()
        {
            return persistanceProvider.GetVehicles();
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            if (this.IsVehicleInSystem(newVehicle))
                throw new CoreException("Vehicle already exists.");

            this.persistanceProvider.AddVehicle(newVehicle);
        }

        public void DeleteVehicle(Vehicle vehicleToDelete)
        {            
            if (!IsVehicleInSystem(vehicleToDelete))
                throw new CoreException("This vehicle is not in the system.");
            
            this.persistanceProvider.DeleteVehicle(vehicleToDelete);
        }

        public void ModifyVehicle(ModifyVehicleInput input)
        {
            Vehicle vehicleToModify = GetVehicleByRegistration(input.Registration);

            if (input.NewCapacity <= 0)
            {
                throw new CoreException("Capacity should be greater than 0.");
            }
            else if (input.FuelConsumptionKmsPerLtr <= 0)
            {
                throw new CoreException("Fuel consumption should be greater than 0.");
            }
            else
            {
                vehicleToModify.SetCapacity(input.NewCapacity);
                vehicleToModify.FuelConsumptionKmsPerLtr = input.FuelConsumptionKmsPerLtr;
                this.persistanceProvider.ModifyVehicle(vehicleToModify);
            }
        }

        public Vehicle GetVehicleByRegistration(string registration)
        {
            Vehicle vehicleFound = this.persistanceProvider.GetVehicleByRegistration(registration);
            if (vehicleFound == null)
                throw new CoreException("Vehicle not found.");
            
            return vehicleFound;
        }

        public List<Tuple<Student, double>> StudentsOrderedByDistanceToSchool()
        {
            List<Student> studentsThatWillUseVehicles = this.persistanceProvider.GetStudentsWithPickUpService();
            List<Tuple<Student, double>> studentsThatWillUseVehiclesWithDistancesToSchool = new List<Tuple<Student, double>>();
            for (int index = 0; index < studentsThatWillUseVehicles.Count; index++)
            {
                var student = studentsThatWillUseVehicles[index];
                var distanceToSchool = CalculateDistanceToSchool(student);
                Tuple<Student, double> elementToAddToStudentsThatWillUseVehiclesWithDistancesToSchool = new Tuple<Student, double>(student, distanceToSchool);
                studentsThatWillUseVehiclesWithDistancesToSchool.Add(elementToAddToStudentsThatWillUseVehiclesWithDistancesToSchool);
            }
            var studentsThatWillUseVehiclesWithDistancesToSchoolOrderder = studentsThatWillUseVehiclesWithDistancesToSchool.OrderBy(x => x.Item2).ToList();
            return studentsThatWillUseVehiclesWithDistancesToSchoolOrderder;
        }
                
        public List<Tuple<Vehicle, List<Student>>> GetVehiclesOrderedByCapacityConsideringStudentsNumber()
        {
            List<Vehicle> systemVehicles = this.persistanceProvider.GetVehicles();
            if (systemVehicles.Count == 0)
                throw new CoreException("Currently there is not any vehicle in the system.");

            List<Tuple<Vehicle, List<Student>>> vehiclesToShow = new List<Tuple<Vehicle, List<Student>>>();
            var studentsToUseVehicles = this.StudentsOrderedByDistanceToSchool();
            var vehicles = this.GetVehiclesOrderedByCapacity();
            var vehiclesQuantity = vehicles.Count;
            var studentsQuantity = studentsToUseVehicles.Count;
            var vehicleIndex = 0;
            while (studentsQuantity > 0)
            {
                Vehicle vehicle = vehicles[vehicleIndex];
                int studentsAlreadyAssignedToAVehicle = studentsToUseVehicles.Count - studentsQuantity;
                int currentVehicleCapacity = vehicle.Capacity;
                List<Student> students = studentsToUseVehicles.Skip(studentsAlreadyAssignedToAVehicle).Take(currentVehicleCapacity).Select(x => x.Item1).ToList();
                Tuple<Vehicle, List<Student>> elementToAdd = new Tuple<Vehicle, List<Student>>(vehicle, students);
                vehiclesToShow.Add(elementToAdd);
                studentsQuantity -= vehicles[vehicleIndex].Capacity;
                if (vehicleIndex == vehiclesQuantity - 1)
                    vehicleIndex = 0;
                else
                    vehicleIndex++;
            }
            return vehiclesToShow;
        }

        //public double[,] GetAdjacencyMatrix(List<Tuple<Student, double>> students)
        //{
        //    int size = students.Count + 1;
        //    double[,] adjacencyMatrix = new double[size, size];
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < size; j++)
        //        {
        //            var studentOne = students[i].Item1;
        //            var studentTwo = students[j].Item1;
        //            adjacencyMatrix[i, j] = DistanceBetweenTwoStudents(studentOne, studentTwo);
        //        }
        //    }
        //    return adjacencyMatrix;
        //}

        #region Private Methods
        private List<Vehicle> GetVehiclesOrderedByCapacity()
        {
            var systemVehicles = this.persistanceProvider.GetVehicles();
            var sortedVehicles = systemVehicles.OrderByDescending(v => v.Capacity).ToList();
            return sortedVehicles;
        }
        private bool IsVehicleInSystem(Vehicle aVehicle)
        {
            return this.persistanceProvider.IsVehicleInSystem(aVehicle);
        }
        private double CalculateDistanceToSchool(Student student)
        {
            var studentLatitude = student.GetLocation().GetLatitud();
            var studentLongitude = student.GetLocation().GetLongitud();
            return Math.Sqrt(Math.Pow(studentLatitude, 2) + Math.Pow(studentLongitude, 2));
        }
        private double DistanceBetweenTwoStudents(Student studentOne, Student studentTwo)
        {
            var studentOneLatitud = studentOne.GetLocation().GetLatitud();
            var studentOneLongitud = studentOne.GetLocation().GetLongitud();

            var studentTwoLatitud = studentTwo.GetLocation().GetLatitud();
            var studentTwoLongitud = studentTwo.GetLocation().GetLongitud();

            return Math.Sqrt(Math.Pow((studentTwoLatitud - studentOneLatitud), 2) + Math.Pow((studentTwoLongitud - studentOneLongitud), 2));
        }
        #endregion

        public List<Tuple<Vehicle, List<Student>>> GetVehiclesOrderedByEfficiencyConsideringStudentsNumber()
        {
            List<Vehicle> systemVehicles = this.persistanceProvider.GetVehicles();
            if (systemVehicles.Count == 0)
                throw new CoreException("Currently there is not any vehicle in the system.");

            List<Tuple<Vehicle, List<Student>>> vehiclesToShow = new List<Tuple<Vehicle, List<Student>>>();
            var studentsToUseVehicles = this.StudentsOrderedByDistanceToSchool();
            var vehicles = this.GetVehiclesOrderedByCapacityPerFuelConsumption();
            var vehiclesQuantity = vehicles.Count;
            var studentsQuantity = studentsToUseVehicles.Count;
            var vehicleIndex = 0;
            while (studentsQuantity > 0)
            {
                Vehicle vehicle = vehicles[vehicleIndex];
                int studentsAlreadyAssignedToAVehicle = studentsToUseVehicles.Count - studentsQuantity;
                int currentVehicleCapacity = vehicle.Capacity;
                List<Student> students = studentsToUseVehicles.Skip(studentsAlreadyAssignedToAVehicle).Take(currentVehicleCapacity).Select(x => x.Item1).ToList();
                Tuple<Vehicle, List<Student>> elementToAdd = new Tuple<Vehicle, List<Student>>(vehicle, students);
                vehiclesToShow.Add(elementToAdd);
                studentsQuantity -= vehicles[vehicleIndex].Capacity;
                if (vehicleIndex == vehiclesQuantity - 1)
                    vehicleIndex = 0;
                else
                    vehicleIndex++;
            }
            return vehiclesToShow;
        }

        public List<Vehicle> GetVehiclesOrderedByCapacityPerFuelConsumption()
        {
            return persistanceProvider.GetVehiclesOrderedByCapacityPerFuelConsumption();
        }

        public double CalculateDistanceToCoverByVehicle(Tuple<Vehicle, List<Student>> vehiclesWithStudents)
        {
            var students = vehiclesWithStudents.Item2;
            var school = new Student();
            school.SetLocation(new Location());
            students.Insert(0, school);
            students.Add(school);
            var distance = 0.0;
            for (int index = 1; index < students.Count(); index++)
            {
                var studentLocation = students[index].Location;
                distance += Utils.Distance(students[index].Location, students[index - 1].Location);
            }
            students.RemoveAll(s => s.Location.Equals(new Location()));
            return distance;
        }
    }
}
