using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using CoreEntities.Entities;
using CoreEntities.Exceptions;

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
                Assert.IsTrue(ex.Message.Equals("Vehicle's registration should have the format XXX1234 (3 letters followed by 4 numbers)."));
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
    }
}
