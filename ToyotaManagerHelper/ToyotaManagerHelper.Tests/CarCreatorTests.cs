using NUnit.Framework;
using System.Collections.Generic;
using ToyotaManagerHelper.Cars;
using System;

namespace ToyotaManagerHelper.Tests
{
    class CarCreatorControllerTests
    {
        CarCreator carCreatorController = new CarCreator(new LandCruiser(), "LandCruiser");


        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void IsEngineSizeValid_InputCorrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(carCreatorController.IsEngineSizeValid(correctData));
        }

        [TestCase("4")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsEngineSizeValid_InputIncorrectData_ReturnFalse(string correctData)
        {
            Assert.IsFalse(carCreatorController.IsEngineSizeValid(correctData));
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        public void IsColorValid_InputCorrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(carCreatorController.IsColorValid(correctData));
        }

        [TestCase("5")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsColorValid_InputIncorrectData_ReturnFalse(string correctData)
        {
            Assert.IsFalse(carCreatorController.IsColorValid(correctData));
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void IsTransmissionValid_InputCorrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(carCreatorController.IsTransmissionValid(correctData));
        }

        [TestCase("5")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsTransmissionValid_InputIncorrectData_ReturnFalse(string correctData)
        {
            Assert.IsFalse(carCreatorController.IsTransmissionValid(correctData));
        }

        //[TestCase(1.8, "1")]
        //public void SetSelectedEngineSize_SetCorrectData_SetCarEngineSize(CarCreator carCreatorController, string selectedEngineSize)
        //{
        //    Assert.AreEqual(carCreatorController.EngineSize, carCreatorController.SetSelectedEngineSize(selectedEngineSize));
        //    Assert.IsTrue(carCreatorController.SetSelectedEngineSize(selectedEngineSize))
        //}
    }
}
