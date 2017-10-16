using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using FrameworkCommon;
using CoreLogic;
using FrameworkCommon.MethodParameters;

namespace UnitTesting
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void CreateVehicleWithParameters()
        {
            var expectedRegistration = "SBA0122";
            var expectedCapacity = 10;

            Vehicle vehicle = new Vehicle(expectedRegistration, expectedCapacity);

            Assert.AreEqual(expectedRegistration, vehicle.Registration);
            Assert.AreEqual(expectedCapacity, vehicle.Capacity);
        }

        [TestMethod]
        public void CreateVehicleWithoutParameters()
        {
            Vehicle vehicle = new Vehicle();

            Assert.AreEqual("AAA0000", vehicle.Registration);
            Assert.AreEqual(1, vehicle.Capacity);
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
            catch(CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Vehicle's capacity should be greater than 0."));
            }
            catch(Exception ex)
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
            catch(CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Vehicle's registration should have the format ABC1234."));
            }
            catch(Exception ex)
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
                SystemData.GetInstance.Reset();

                string registration = "SBA1234";
                int capacity = 10;
                Vehicle vehicle = new Vehicle(registration, capacity);

                ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicle);
                ClassFactory.GetOrCreate<VehicleLogic>().DeleteVehicle(vehicle);

                Assert.IsNull(this.FindVehicleOnSystem(vehicle.Registration));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private object FindVehicleOnSystem(string registration)
        {
            return SystemData.GetInstance.GetVehicles().Find(v => v.Registration.Equals(registration));
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
            SystemData.GetInstance.Reset();

            Vehicle newVehicle = new Vehicle("SBA1234", 10);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(newVehicle);

            ModifyVehicleInput input = new ModifyVehicleInput();
            input.Registration = "SBA1234";
            input.NewCapacity = 20;
            ClassFactory.GetOrCreate<VehicleLogic>().ModifyVehicle(input);

            Vehicle modifiedVehicle = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicleByRegistration("SBA1234");

            Assert.AreEqual(modifiedVehicle.GetCapacity(), input.NewCapacity);
        }

        [TestMethod]
        public void ListVehiclesWhenTheresNoVehiclesInSystem()
        {
            try
            {
                SystemData.GetInstance.Reset();

                var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Currently there is not any vehicle in the system."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }

        [TestMethod]
        public void ListVehicles()
        {
            SystemData.GetInstance.Reset();

            Vehicle vehicleOne = new Vehicle("SBA1234", 10);
            Vehicle vehicleTwo = new Vehicle("SBA5678", 15);
            Vehicle vehicleThree = new Vehicle("SBA9012", 20);

            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicleOne);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicleTwo);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicleThree);

            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();

            Assert.IsTrue(vehicles.Count > 0);
        }

        [TestMethod]
        private void TestStudentsOrderedByDistanceToSchool()
        {
            SystemData.GetInstance.Reset();

            AddStudentInput studentOne = new AddStudentInput();
            studentOne.DocumentNumber = "1234567-1";
            studentOne.Name = "John";
            studentOne.Location = new Location(2.00000, 2.000000);
            studentOne.havePickUpService = true;

            AddStudentInput studentTwo = new AddStudentInput();
            studentTwo.DocumentNumber = "1234567-2";
            studentTwo.Name = "George";
            studentTwo.Location = new Location(1.00000, 1.000000);
            studentTwo.havePickUpService = true;

            AddStudentInput studentThree = new AddStudentInput();
            studentThree.DocumentNumber = "1234567-3";
            studentThree.Name = "Paul";
            studentThree.Location = new Location(3.00000, 3.000000);

            AddStudentInput studentFour = new AddStudentInput();
            studentFour.DocumentNumber = "1234567-4";
            studentFour.Name = "Ringo";
            studentFour.Location = new Location(20.00000, 20.000000);
            studentFour.havePickUpService = true;

            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentOne);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentTwo);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentThree);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentFour);

            var studentsOrderedByDistanceToSchool = ClassFactory.GetOrCreate<VehicleLogic>().StudentsOrderedByDistanceToSchool();

            Assert.AreEqual(studentsOrderedByDistanceToSchool[0].Item1, studentTwo);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[0].Item1, studentOne);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[0].Item1, studentThree);
        }

        /*public void GetTheStudentThatIsClosestToTheShool()
        {
            SystemData.GetInstance.Reset();

            AddStudentInput studentOne = new AddStudentInput();
            studentOne.DocumentNumber = "1234567-1";
            studentOne.Name = "John";
            studentOne.Location = new Location(1.00000, 1.000000);

            AddStudentInput studentTwo = new AddStudentInput();
            studentTwo.DocumentNumber = "1234567-2";
            studentTwo.Name = "George";
            studentTwo.Location = new Location(2.00000, 2.000000);

            AddStudentInput studentThree = new AddStudentInput();
            studentThree.DocumentNumber = "1234567-3";
            studentThree.Name = "Paul";
            studentThree.Location = new Location(3.00000, 3.000000);

            AddStudentInput studentFour = new AddStudentInput();
            studentFour.DocumentNumber = "1234567-4";
            studentFour.Name = "Ringo";
            studentFour.Location = new Location(20.00000, 20.000000);

            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentOne);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentTwo);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentThree);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentFour);

            var studentsToAssignToVehicles = SystemData.GetInstance.GetStudentsToAssignToVehicles()
            while (!IsEmpty(studentsToAssignToVehicles))
            {
                var nextStudentToAssign = studentsToAssignToVehicles.Head();
                Assert.AreEqual(studentOne, nextStudentToAssign);
                studentsToAssignToVehicles.Dequeue();
            }
        }*/
    }
}
