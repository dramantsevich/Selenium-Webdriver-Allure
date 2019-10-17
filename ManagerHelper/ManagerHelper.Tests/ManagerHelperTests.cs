using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ManagerHelper.Tests
{
    [TestClass]
    public class ManagerHelperTests
    {
        [TestMethod]
        public IEnumerable<Car> CarToList()
        {
            LandCruiser LC1 = new LandCruiser(1.8, "Blue", 1);
            LandCruiser LC2 = new LandCruiser(2.6, "Red", 2);
            LandCruiser LC3 = new LandCruiser(3.0, "Yellow", 3);

            Camry Camry1 = new Camry(2.0, "White", 2);
            Camry Camry2 = new Camry(1.6, "Orange", 1);
            Camry Camry3 = new Camry(3.2, "Blue", 3);

            Corolla Corolla1 = new Corolla(3.0, "Black", 3);
            Corolla Corolla2 = new Corolla(1.8, "Orange", 1);
            Corolla Corolla3 = new Corolla(2.6, "Red", 2);

            List<Car> cars = new List<Car>();

            cars.Add(LC1);
            cars.Add(Camry1);
            cars.Add(Corolla1);
            cars.Add(LC2);
            cars.Add(Camry2);
            cars.Add(Corolla2);
            cars.Add(LC3);
            cars.Add(Camry3);
            cars.Add(Corolla3);

            return cars;
        }

        [TestMethod]
        public void GetAvailableCarsTest()
        {
            //arrange
            LandCruiser LC1 = new LandCruiser(1.8, "Blue", 1);
            LandCruiser LC2 = new LandCruiser(2.6, "Red", 2);
            LandCruiser LC3 = new LandCruiser(3.0, "Yellow", 3);

            Camry Camry1 = new Camry(2.0, "White", 2);
            Camry Camry2 = new Camry(1.6, "Orange", 1);
            Camry Camry3 = new Camry(3.2, "Blue", 3);

            Corolla Corolla1 = new Corolla(3.0, "Black", 3);
            Corolla Corolla2 = new Corolla(1.8, "Orange", 1);
            Corolla Corolla3 = new Corolla(2.6, "Red", 2);

            List<Car> cars = new List<Car>();
            //act
            cars.Add(LC1);
            cars.Add(Camry1);
            cars.Add(Corolla1);
            cars.Add(LC2);
            cars.Add(Camry2);
            cars.Add(Corolla2);
            cars.Add(LC3);
            cars.Add(Camry3);
            cars.Add(Corolla3);
            //assert
            StringAssert.Equals(CarToList(), ManagerHelper.GetAvailableCars(cars));
        }

        public void DisplaySortedCarInformationTest()
        {

            
        }


    }
}
