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
            if (this.systemVehicles.Count == 0)
                throw new CoreException("Currently there is not any vehicle in the system.");
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

        public List<Tuple<Student, double>> StudentsOrderedByDistanceToSchool()
        {
            var systemStudents = SystemData.GetInstance.GetStudents();
            List<Tuple<Student, double>> studentsThatWillUseVehiclesWithDistancesToSchool = new List<Tuple<Student, double>>();
            List<Student> studentsThatWillUseVehicles = systemStudents.FindAll(s => s.HavePickUpService());
            for (int index = 0; index < studentsThatWillUseVehicles.Count; index++)
            {
                var student = studentsThatWillUseVehicles[index];
                var distanceToSchool = CalculateDistanceToSchool(student);
                Tuple<Student, double> elementToAddToStudentsThatWillUseVehiclesWithDistancesToSchool = new Tuple<Student, double>(student, distanceToSchool);
                studentsThatWillUseVehiclesWithDistancesToSchool.Add(elementToAddToStudentsThatWillUseVehiclesWithDistancesToSchool);
            }
            studentsThatWillUseVehiclesWithDistancesToSchool.OrderBy(x => x.Item2).ToList();
            return studentsThatWillUseVehiclesWithDistancesToSchool;
        }

        private double CalculateDistanceToSchool(Student student)
        {
            var studentLatitude = student.GetLocation().GetLatitud();
            var studentLongitude = student.GetLocation().GetLongitud();
            return Math.Sqrt(Math.Pow(studentLatitude, 2) + Math.Pow(studentLongitude, 2));
        }

        public List<Vehicle> GetVehiclesOrderedByCapacity()
        {
            var systemVehicles = SystemData.GetInstance.GetVehicles();
            var sortedVehicles = systemVehicles.OrderByDescending(v => v.Capacity).ToList();
            return sortedVehicles;
        }

        public List<Tuple<Vehicle, List<Student>>> GetVehiclesOrderedByCapacityConsideringStudentsNumber()
        {
            List<Tuple<Vehicle, List<Student>>> vehiclesToShow = new List<Tuple<Vehicle, List<Student>>>();
            var studentsToUseVehicles = this.StudentsOrderedByDistanceToSchool();
            var vehicles = this.GetVehiclesOrderedByCapacity();
            var vehiclesQuantity = vehicles.Count;
            var studentsQuantity = studentsToUseVehicles.Count;
            var vehicleIndex = 0;
            while (studentsQuantity > 0)
            {
                // https://stackoverflow.com/questions/1042087/how-to-select-values-within-a-provided-index-range-from-a-list-using-linq
                // aqui deberia tomar los alumnos entre un rango para agregarlo a la tupla
                Vehicle vehicle = vehicles[vehicleIndex];
                int sk = studentsToUseVehicles.Count - studentsQuantity;
                int ta = vehicle.Capacity;
                List<Student> students = studentsToUseVehicles.Skip(sk).Take(ta).Select(x => x.Item1).ToList();
                Tuple<Vehicle, List<Student>> elementToAdd = new Tuple<Vehicle, List<Student>>(vehicle, students);
                vehiclesToShow.Add(elementToAdd);
                studentsQuantity -= vehicles[vehicleIndex].Capacity;
                if(vehicleIndex == vehiclesQuantity - 1)
                {
                    vehicleIndex = 0;
                }
                else
                {
                    vehicleIndex++;
                }
            }
            return vehiclesToShow;
        }

        public double[,] GetAdjacencyMatrix(List<Tuple<Student, double>> students)
        {
            int size = students.Count + 1;
            double[,] adjacencyMatrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var studentOne = students[i].Item1;
                    var studentTwo = students[j].Item1;
                    adjacencyMatrix[i, j] = DistanceBetweenTwoStudents(studentOne, studentTwo);
                }
            }
            return adjacencyMatrix;
        }

        private double DistanceBetweenTwoStudents(Student studentOne, Student studentTwo)
        {
            var studentOneLatitud = studentOne.GetLocation().GetLatitud();
            var studentOneLongitud = studentOne.GetLocation().GetLongitud();

            var studentTwoLatitud = studentTwo.GetLocation().GetLatitud();
            var studentTwoLongitud = studentTwo.GetLocation().GetLongitud();

            return Math.Sqrt(Math.Pow((studentTwoLatitud - studentOneLatitud), 2) + Math.Pow((studentTwoLongitud - studentOneLongitud), 2));
        }
    }
}
