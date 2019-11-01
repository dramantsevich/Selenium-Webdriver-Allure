using NUnit.Framework;
using ToyotaManagerHelper.CarConfigurations;

namespace ToyotaManagerHelper.Tests.CarConfigurationsTests
{
    class TransmissionTests
    {
        Transmission objectTransmission = new Transmission();

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void IsTransmissionValid_InputCOrrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(objectTransmission.IsTransmissionValid(correctData));
        }

        [TestCase("5")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsTransmissionValid_InputIncorrectData_ReturnFalse(string incorrectData)
        {
            Assert.IsFalse(objectTransmission.IsTransmissionValid(incorrectData));
        }

        [TestCase("1", "Manual")]
        [TestCase("2", "Automatic")]
        [TestCase("3", "CVT")]
        public void SetSelectedTransmission_EnterCorrectData_SetTransmission(string selectedTransmission, string expectedTransmission)
        {
            Transmission actualObjectEngineSize = new Transmission(selectedTransmission);

            objectTransmission.transmission = expectedTransmission;

            Assert.AreEqual(objectTransmission.transmission, actualObjectEngineSize.transmission);
        }
    }
}
