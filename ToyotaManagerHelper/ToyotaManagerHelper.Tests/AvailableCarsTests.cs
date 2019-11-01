using NUnit.Framework;
using System.Collections.Generic;
using ToyotaManagerHelper.Builder;

namespace ToyotaManagerHelper.Tests
{
    public class AvailableCarsTests
    {
        List<Car> listOfCars = new List<Car>();

        [Test]
        public void GetAvailableCars_CarsToList_IsNotNullListOfCars()
        {
            AvailableCars.GetAvailableCars(listOfCars);

            Assert.IsNotNull(listOfCars);
        }
    }
}