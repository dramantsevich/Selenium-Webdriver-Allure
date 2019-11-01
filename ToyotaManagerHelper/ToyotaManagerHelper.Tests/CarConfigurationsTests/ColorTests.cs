using NUnit.Framework;
using ToyotaManagerHelper.CarConfigurations;

namespace ToyotaManagerHelper.Tests.CarConfigurationsTests
{
    class ColorTests
    {
        Color objectColor = new Color();

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        public void IsColorValid_InputCorrectData_ReturnTrue(string correctData)
        {
            Assert.IsTrue(objectColor.IsColorValid(correctData));
        }

        [TestCase("5")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ls")]
        public void IsColorValid_InputIncorrectData_ReturnFalse(string inCorrectData)
        {
            Assert.IsFalse(objectColor.IsColorValid(inCorrectData));
        }

        [TestCase("1", "Green")]
        [TestCase("2", "Black")]
        [TestCase("3", "Red")]
        [TestCase("4", "Blue")]
        public void SetSelectedColor_EnterCorrectData_SetColor(string selectedColor, string expectedColor)
        {
            Color actualObjectColor = new Color(selectedColor);

            objectColor.color = expectedColor;

            Assert.AreEqual(objectColor.color, actualObjectColor.color);
        }
    }
}
