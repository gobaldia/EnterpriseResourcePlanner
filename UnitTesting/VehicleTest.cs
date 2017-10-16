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
    }
}
