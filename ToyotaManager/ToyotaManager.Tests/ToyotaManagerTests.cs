using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ToyotaManager.Tests
{
    [TestClass]
    public class ToyotaManagerTests
    {
        [TestMethod]
        public void SortedComplectationOfCarsTest()
        {
            //arrange
            //LandCruiser landCruiser = new LandCruiser(1.8, "Blue", 2);
            //Camry camry = new Camry(2.4, "Green", 3);
            //Corolla corolla = new Corolla(3.0, "Orange", 1);
            LandCruiser LC1 = new LandCruiser(1.8, "Blue", 1);
            LandCruiser LC2 = new LandCruiser(2.6, "Red", 2);
            LandCruiser LC3 = new LandCruiser(3.0, "Yellow", 3);

            Camry Camry1 = new Camry(2.0, "White", 2);
            Camry Camry2 = new Camry(1.6, "Orange", 1);
            Camry Camry3 = new Camry(3.2, "Blue", 3);

            Corolla Corolla1 = new Corolla(3.0, "Black", 3);
            Corolla Corolla2 = new Corolla(1.8, "Orange", 1);
            Corolla Corolla3 = new Corolla(2.6, "Red", 2);

            List<int> testedCosts = new List<int>();
            List<Car> cars = new List<Car>();

            //act
            //cars.Add(landCruiser);
            //cars.Add(camry);
            //cars.Add(corolla);
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
            var sortedCars = from c in cars
                             orderby c.ComplectationCost
                             select c;

            foreach(Car c in sortedCars)
            {
                testedCosts.Add(c.ComplectationCost);
            }

            Assert.AreEqual(testedCosts, Program.SortedComplectationOfCars(cars));
        }

        [TestMethod]
        public void SortedCarCostTest()
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
            Assert.AreEqual(testedCarCosts, Program.SortedCarCost(cars));
        }
    }
}
