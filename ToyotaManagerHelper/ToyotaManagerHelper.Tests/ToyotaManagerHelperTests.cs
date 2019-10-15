using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ToyotaManagerHelper.Tests
{
    [TestClass]
    public class ToyotaManagerTests
    {
        [TestMethod]
        public void DisplayCarConfigurationTest()
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

            List<int> carConfigurationCosts = new List<int>();
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

            var sortedCars = from c in cars
                             orderby c.ComplectationCost
                             select c;

            foreach (Car c in sortedCars)
            {
                carConfigurationCosts.Add(c.ComplectationCost);
            }

            //assert    
            CollectionAssert.AreEqual(carConfigurationCosts, ToyotaManagerHelper.DisplayCarConfiguration(cars));
        }

        [TestMethod]
        public void DisplayCarCostTest()
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

            List<int> testedCarCosts = new List<int>();
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

            var sortedCarCost = from c in cars
                                orderby c.CarCost
                                select c;

            foreach (Car c in sortedCarCost)
            {
                testedCarCosts.Add(c.CarCost);
            }
            //assert
            CollectionAssert.AreEqual(testedCarCosts, ToyotaManagerHelper.DisplayCarCost(cars));
        }

        [TestMethod]
        public void GetComplectationOfPriceRangeTest()
        {
            //arrange
            int a = 6000;
            int b = 7000;

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
            List<Car> testedCarInPriceRange = new List<Car>();
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

            foreach (Car c in cars)
            {
                if (c.CarCost >= a && c.CarCost <= b)
                {
                    testedCarInPriceRange.Add(c);
                    Console.WriteLine(c.ToString());
                }
            }
            //assert
            CollectionAssert.AreEqual(testedCarInPriceRange, ToyotaManagerHelper.GetComplectationOfPriceRange(cars, a, b));
        }
    }
}
