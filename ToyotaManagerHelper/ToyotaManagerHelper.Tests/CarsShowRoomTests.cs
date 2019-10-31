using NUnit.Framework;
using System.Collections.Generic;
using ToyotaManagerHelper.Cars;
using System;

namespace ToyotaManagerHelper.Tests
{
    public class CarsShowRoomTests
    {
        CarsShowRoom carsShowRoomController;

        [SetUp]
        public void BeforeTest()
        {
            List<Car> listOfCars = new List<Car>();
            AvailableCars.GetAvailableCars(listOfCars);
            carsShowRoomController = new CarsShowRoom(listOfCars);
        }


        [Test]
        public void IsPriceRangeValid_EnterStartPriceLessThenEndPrice_ReturnTrue()
        {
            Assert.IsTrue(carsShowRoomController.IsPriceRangeValid(4000, 40001));
        }

        [Test]
        public void IsPriceRangeValid_EnterStartPriceMoreThenEndPrice_ReturnFalse()
        {
            Assert.IsFalse(carsShowRoomController.IsPriceRangeValid(40001, 4000));
        }

        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1,-1)]
        public void IsPriceRangeValid_EnterNegativeNumbers_ReturnFalse(int startingPrice, int endingPrice)
        {
            Assert.IsFalse(carsShowRoomController.IsPriceRangeValid(startingPrice, endingPrice));
        }

        [TestCase(".", "1")]
        [TestCase("1", ".")]
        [TestCase(",", "1")]
        [TestCase("1", ",")]
        [TestCase("", "1")]
        [TestCase("1", "")]
        [TestCase(" ", "1")]
        [TestCase("1", " ")]
        [TestCase("ls", "1")]
        [TestCase("1", "ls")]
        public void SetPriceRange_InputIncorrectData_ThrowFormatException(string startingPrice, string endingPrice)
        {
            Assert.Throws<FormatException>(() => carsShowRoomController.SetPriceRange(startingPrice, endingPrice));
        }

        [Test]
        public void GetCarsInPriceRange_CarCostIncludeInPriceRange_HasCarsInPriceRange()
        {
            string startingPrice = "0";
            string endingPrice = "10000";

            var actual = carsShowRoomController.GetCarsInPriceRange(carsShowRoomController, startingPrice, endingPrice);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void GetCarsInPriceRange_CarCostNotIncludeInPriceRange_HasNullCarsInPriceRange()
        {
            string startingPrice = "0";
            string endingPrice = "10";

            var actual = carsShowRoomController.GetCarsInPriceRange(carsShowRoomController, startingPrice, endingPrice);

            Assert.IsNull(actual);
        }

        [TestCase(".", "1")]
        [TestCase("1", ".")]
        [TestCase(",", "1")]
        [TestCase("1", ",")]
        [TestCase("", "1")]
        [TestCase("1", "")]
        [TestCase(" ", "1")]
        [TestCase("1", " ")]
        [TestCase("ls", "1")]
        [TestCase("1", "ls")]
        public void GetCarsInPriceRange_InputIncorrectData_TrowFormatException(string startingPrice, string endingPrice)
        {
            Assert.Throws<FormatException>(() => carsShowRoomController.GetCarsInPriceRange(carsShowRoomController, startingPrice, endingPrice));
        }

        [Test]
        public void DisplayListCars_ListOfCarsNull_HasEmpty()
        {
            Assert.Throws<NullReferenceException>(() => carsShowRoomController.GetCarsInPriceRange(carsShowRoomController, "0", "1").DisplayListCars());
        }
    }
}
