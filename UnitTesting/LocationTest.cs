using CoreEntities.Entities;
using CoreEntities.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void CreateLocation()
        {
            double latitud = 22;
            double longitud = -2.2;
            Location location = new Location(latitud, longitud);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ThrowInvalidFormatWhenTrySetInvalidLatitud()
        {
            try
            {
                double latitud = 222;
                double longitud = -2.2;
                Location location = new Location(latitud, longitud);

                Assert.Fail();
            }
            catch (CoreException ex)
            {
                Assert.IsTrue(ex.Message.Equals("Invalid latitud format."));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
