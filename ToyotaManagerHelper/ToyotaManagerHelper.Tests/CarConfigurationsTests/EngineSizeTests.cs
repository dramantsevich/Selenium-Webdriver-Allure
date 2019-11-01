using NUnit.Framework;
using ToyotaManagerHelper.CarConfigurations;

namespace ToyotaManagerHelper.Tests.CarConfigurationsTests
{
    class EngineSizeTests
    {
        EngineSize objectEngineSize = new EngineSize();

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void IsEngineSizeValid_InputCorrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(objectEngineSize.IsEngineSizeValid(correctData));
        }

        [TestCase("4")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsEngineSizeValid_InputIncorrectData_ReturnFalse(string inCorrectData)
        {
            Assert.IsFalse(objectEngineSize.IsEngineSizeValid(inCorrectData));
        }

        [TestCase("1", 1.8)]
        [TestCase("2", 2.0)]
        [TestCase("3", 3.0)]
        public void SetSelectedEngineSize_EnterCorrectData_SetEngineSize(string selectedEngineSize, double expectedSize)
        {
            EngineSize actualObjectEngineSize = new EngineSize(selectedEngineSize);

            objectEngineSize.engineSize = expectedSize;

            Assert.AreEqual(objectEngineSize.engineSize, actualObjectEngineSize.engineSize);
        }
    }
}
