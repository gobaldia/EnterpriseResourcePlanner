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
using UnitTesting.Utilities;

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
        public void TestStudentsOrderedByDistanceToSchool()
        {
            SystemData.GetInstance.Reset();

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
            studentThree.StudentNumber = 3;

            Student studentFour = new Student();
            studentFour.Document = "1234567-4";
            studentFour.Name = "Ringo";
            studentFour.Location = new Location(20.00000, 20.000000);
            studentFour.HavePickUpService = true;
            studentFour.StudentNumber = 4;

            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentOne);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentTwo);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentThree);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(studentFour);


            Student studentToCompare1 = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(studentOne.Document);
            Student studentToCompare2 = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(studentTwo.Document);
            Student studentToCompare3 = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(studentThree.Document);
            Student studentToCompare4 = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByDocumentNumber(studentFour.Document);

            var studentsOrderedByDistanceToSchool = ClassFactory.GetOrCreate<VehicleLogic>().StudentsOrderedByDistanceToSchool();

            Assert.AreEqual(studentsOrderedByDistanceToSchool[0].Item1, studentToCompare2);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[1].Item1, studentToCompare1);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[2].Item1, studentToCompare3);
            Assert.AreEqual(studentsOrderedByDistanceToSchool[3].Item1, studentToCompare4);
        }

        [TestMethod]
        public void GetVehiclesOrderedByCapacityConsideringStudentsNumber()
        {
            SystemData.GetInstance.Reset();

            #region Generate test data
            Vehicle vehicle1 = new Vehicle("SBA0001", 1);
            Vehicle vehicle2 = new Vehicle("SBA1015", 2);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicle1);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicle2);

            var input1 = new Student
            {
                Document = "1234567-5",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Location = new Location(10.00, 15.1)
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input1);

            var input2 = new Student
            {
                Document = "1235567-8",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Location = new Location(50.00, 22.1)
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input2);

            var input3 = new Student
            {
                Document = "1266667-8",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Location = new Location(-80.00, 5.1)
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input3);

            var input4 = new Student
            {
                Document = "1234567-4",
                Name = Utility.GetRandomName(),
                LastName = Utility.GetRandomLastName(),
                Location = new Location(-10.00, -15.1)
            };
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(input4);
            #endregion

            List<Tuple<Vehicle, List<Student>>> systemVehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehiclesOrderedByCapacityConsideringStudentsNumber();

            Vehicle firstVehicle = systemVehicles[0].Item1;
            Vehicle secondVehicle = systemVehicles[1].Item1;
            Vehicle thirdVehicle = systemVehicles[2].Item1;

            Assert.AreEqual(firstVehicle, vehicle2);
            Assert.AreEqual(secondVehicle, vehicle1);
            Assert.AreEqual(thirdVehicle, vehicle2);
        }

        /*public void GetTheStudentThatIsClosestToTheShool()
        {
            SystemData.GetInstance.Reset();

            Student studentOne = new Student();
            studentOne.Document = "1234567-1";
            studentOne.Name = "John";
            studentOne.Location = new Location(1.00000, 1.000000);

            Student studentTwo = new Student();
            studentTwo.Document = "1234567-2";
            studentTwo.Name = "George";
            studentTwo.Location = new Location(2.00000, 2.000000);

            Student studentThree = new Student();
            studentThree.Document = "1234567-3";
            studentThree.Name = "Paul";
            studentThree.Location = new Location(3.00000, 3.000000);

            Student studentFour = new Student();
            studentFour.Document = "1234567-4";
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
