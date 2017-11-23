using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using UnitTesting.Utilities;
using DummyPersistance;
using CoreLogic.Interfaces;

namespace UnitTesting
{
    [TestClass]
    public class VehicleTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

        [TestMethod]
        public void CreateVehicleWithParameters()
        {
            var expectedRegistration = "SBA0122";
            var expectedCapacity = 10;
            var expectedFuelConsumption = 10;

            Vehicle vehicle = new Vehicle(expectedRegistration, expectedCapacity, expectedFuelConsumption);

            Assert.AreEqual(expectedRegistration, vehicle.Registration);
            Assert.AreEqual(expectedCapacity, vehicle.Capacity);
            Assert.AreEqual(expectedFuelConsumption, vehicle.FuelConsumptionKmsPerLtr);
        }

        [TestMethod]
        public void CreateVehicleWithoutParameters()
        {
            Vehicle vehicle = new Vehicle();

            Assert.AreEqual("AAA0000", vehicle.Registration);
            Assert.AreEqual(1, vehicle.Capacity);
            Assert.AreEqual(1, vehicle.FuelConsumptionKmsPerLtr);
        }

        [TestMethod]
        public void CreateVehicleCapacityLessOrEqualThanZero()
        {
            var expectedRegistration = "SBA0122";
            var expectedCapacity = 0;
            try
            {
                Vehicle vehicle = new Vehicle(expectedRegistration, expectedCapacity);
                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Vehicle's capacity should be greater than 0."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void CreateVehicleFuelConsumptionLessOrEqualThanZero()
        {
            var expectedRegistration = "SBA0122";
            var expectedCapacity = 10;
            var expectedFuelConsumption = 0;
            try
            {
                Vehicle vehicle = new Vehicle(expectedRegistration, expectedCapacity, expectedFuelConsumption);
                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Vehicle's fuel consumption should be greater than 0."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void CreateVehicleWithMalformedRegistration()
        {
            var expectedRegistration = "123";
            var expectedCapacity = 10;
            try
            {
                Vehicle vehicle = new Vehicle(expectedRegistration, expectedCapacity);
                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Vehicle's registration should have the format ABC1234."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void VehicleInstancesAreEqual()
        {
            string registration = "SBA1234";
            int capacity = 10;

            Vehicle firstVehicle = new Vehicle(registration, capacity);
            Vehicle secondVehicle = new Vehicle(registration, capacity);

            Assert.IsTrue(firstVehicle.Equals(secondVehicle));
        }

        [TestMethod]
        public void VehicleInstancesAreNotEqual()
        {
            string registrationOne = "SBA1234";
            string registrationTwo = "AAA1024";
            int capacity = 10;

            Vehicle firstVehicle = new Vehicle(registrationOne, capacity);
            Vehicle secondVehicle = new Vehicle(registrationTwo, capacity);

            Assert.IsFalse(firstVehicle.Equals(secondVehicle));
        }

        [TestMethod]
        public void DeleteVehicle()
        {
            try
            {
                IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();

                string registration = "SBA1234";
                int capacity = 10;
                Vehicle vehicle = new Vehicle(registration, capacity);

                vehicleOperations.AddVehicle(vehicle);
                vehicleOperations.DeleteVehicle(vehicle);

                Assert.IsNull(this.FindVehicleOnSystem(vehicle.Registration));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private object FindVehicleOnSystem(string registration)
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();
            List<Vehicle> vehicles = vehicleOperations.GetVehicles();
            return vehicles.Find(x => x.GetRegistration() == registration);
        }

        [TestMethod]
        public void ModifyVehicle()
        {
            string registration = "SBA1234";
            int originalCapacity = 10;
            Vehicle vehicle = new Vehicle(registration, originalCapacity);

            string expectedRegistration = "AAA1234";
            int expectedCapacity = 20;
            vehicle.SetCapacity(expectedCapacity);

            Assert.AreEqual(expectedCapacity, vehicle.Capacity);
        }

        [TestMethod]
        public void ModifyVehicleCapacityInSystem()
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();

            Vehicle newVehicle = new Vehicle("SBA1234", 10, 10);
            vehicleOperations.AddVehicle(newVehicle);

            ModifyVehicleInput input = new ModifyVehicleInput();
            input.Registration = "SBA1234";
            input.NewCapacity = 20;
            input.FuelConsumptionKmsPerLtr = 10;
            vehicleOperations.ModifyVehicle(input);

            Vehicle modifiedVehicle = vehicleOperations.GetVehicleByRegistration("SBA1234");

            Assert.AreEqual(modifiedVehicle.GetCapacity(), input.NewCapacity);
        }

        [TestMethod]
        public void ListVehicles()
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();

            Vehicle vehicleOne = new Vehicle("SBA1234", 10);
            Vehicle vehicleTwo = new Vehicle("SBA5678", 15);
            Vehicle vehicleThree = new Vehicle("SBA9012", 20);

            vehicleOperations.AddVehicle(vehicleOne);
            vehicleOperations.AddVehicle(vehicleTwo);
            vehicleOperations.AddVehicle(vehicleThree);

            var vehicles = vehicleOperations.GetVehicles();

            Assert.IsTrue(vehicles.Count == 3);
        }

        [TestMethod]
        public void TestStudentsOrderedByDistanceToSchool()
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            Student studentOne = new Student();
            studentOne.Document = "1234567-1";
            studentOne.Name = "John";
            studentOne.Location = new Location(2.00000, 2.000000);
            studentOne.HavePickUpService = true;
            studentOne.StudentNumber = 1;

            Student studentTwo = new Student();
            studentTwo.Document = "1234567-2";
            studentTwo.Name = "George";
            studentTwo.Location = new Location(1.00000, 1.000000);
            studentTwo.HavePickUpService = true;
            studentTwo.StudentNumber = 2;

            Student studentThree = new Student();
            studentThree.Document = "1234567-3";
            studentThree.Name = "Paul";
            studentThree.Location = new Location(3.00000, 3.000000);
            studentThree.HavePickUpService = true;
            studentThree.StudentNumber = 3;

            Student studentFour = new Student();
            studentFour.Document = "1234567-4";
            studentFour.Name = "Ringo";
            studentFour.Location = new Location(20.00000, 20.000000);
            studentFour.HavePickUpService = true;
            studentFour.StudentNumber = 4;

            studentOperations.AddStudent(studentOne);
            studentOperations.AddStudent(studentTwo);
            studentOperations.AddStudent(studentThree);
            studentOperations.AddStudent(studentFour);


            Student studentToCompare1 = studentOperations.GetStudentByDocumentNumber(studentOne.Document);
            Student studentToCompare2 = studentOperations.GetStudentByDocumentNumber(studentTwo.Document);
            Student studentToCompare3 = studentOperations.GetStudentByDocumentNumber(studentThree.Document);
            Student studentToCompare4 = studentOperations.GetStudentByDocumentNumber(studentFour.Document);

            var studentsOrderedByDistanceToSchool = vehicleOperations.StudentsOrderedByDistanceToSchool();

            Assert.AreEqual(studentsOrderedByDistanceToSchool[0].Item1, studentToCompare2);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[1].Item1, studentToCompare1);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[2].Item1, studentToCompare3);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[3].Item1, studentToCompare4);
        }

        [TestMethod]
        public void GetVehiclesOrderedByCapacityPerFuelConsumption()
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();

            Vehicle vehicle1 = new Vehicle("SBA0001", 10, 10);
            Vehicle vehicle2 = new Vehicle("SBA1015", 10, 100);
            vehicleOperations.AddVehicle(vehicle1);
            vehicleOperations.AddVehicle(vehicle2);

            var vehiclesOrdered = vehicleOperations.GetVehiclesOrderedByCapacityPerFuelConsumption();

            Assert.AreEqual(vehiclesOrdered[0], vehicle2);
            Assert.AreEqual(vehiclesOrdered[1], vehicle1);

        }

        [TestMethod]
        public void CalculateDistanceToCoverByVehicle()
        {
            IVehicleLogic vehicleOperations = DummyProvider.GetInstance.GetVehicleOperations();
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();

            Vehicle vehicle = new Vehicle("SBA0001", 10, 10);

            vehicleOperations.AddVehicle(vehicle);

            Student studentOne = new Student();
            studentOne.Document = "1234567-1";
            studentOne.Name = "John";
            studentOne.Location = new Location(2.00000, 2.000000);
            studentOne.HavePickUpService = true;
            studentOne.StudentNumber = 1;

            Student studentTwo = new Student();
            studentTwo.Document = "1234567-2";
            studentTwo.Name = "George";
            studentTwo.Location = new Location(1.00000, 1.000000);
            studentTwo.HavePickUpService = true;
            studentTwo.StudentNumber = 2;

            Student studentThree = new Student();
            studentThree.Document = "1234567-3";
            studentThree.Name = "Paul";
            studentThree.Location = new Location(3.00000, 3.000000);
            studentThree.HavePickUpService = true;
            studentThree.StudentNumber = 3;

            Student studentFour = new Student();
            studentFour.Document = "1234567-4";
            studentFour.Name = "Ringo";
            studentFour.Location = new Location(20.00000, 20.000000);
            studentFour.HavePickUpService = true;
            studentFour.StudentNumber = 4;

            studentOperations.AddStudent(studentOne);
            studentOperations.AddStudent(studentTwo);
            studentOperations.AddStudent(studentThree);
            studentOperations.AddStudent(studentFour);

            List<Tuple<Vehicle, List<Student>>> vehiclesWithStudents = vehicleOperations.GetVehiclesOrderedByEfficiencyConsideringStudentsNumber();

            var expectedDistance = 0.0;
            expectedDistance += Utils.Distance(new Location(), studentTwo.Location);
            expectedDistance += Utils.Distance(studentTwo.Location, studentOne.Location);
            expectedDistance += Utils.Distance(studentOne.Location, studentThree.Location);
            expectedDistance += Utils.Distance(studentThree.Location, studentFour.Location);
            expectedDistance += Utils.Distance(studentFour.Location, new Location());


            var distance = vehicleOperations.CalculateDistanceToCoverByVehicle(vehiclesWithStudents[0]);

            Assert.IsTrue(distance == expectedDistance);
        }
        
        [TestMethod]
        public void SetOid()
        {
            var vehicle = new Vehicle();
            var expectedOid = 10;
            vehicle.VehicleOID = expectedOid;
            Assert.AreEqual(vehicle.VehicleOID, expectedOid);
        }

        [TestMethod]
        public void ToString()
        {
            var vehicle = new Vehicle();
            var expectedToString = "AAA0000";
            Assert.AreEqual(expectedToString, vehicle.ToString());
        }

        [TestMethod]
        public void GetRegistration()
        {
            var vehicle = new Vehicle();
            var expectedRegistration = "AAA0000";
            Assert.AreEqual(expectedRegistration, vehicle.GetRegistration());
        }

        [TestMethod]
        public void GetFullToString()
        {
            var vehicle = new Vehicle();
            var expectedToString = "AAA0000 - Capacity: 1 - Kms/Ltr: 1";
            Assert.AreEqual(expectedToString, vehicle.GetFullToString());
        }
    }
}