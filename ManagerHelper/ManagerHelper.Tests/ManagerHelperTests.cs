using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerHelper;
using System;

namespace ManagerHelper.Tests
{
    [TestClass]
    public class ManagerHelperTests
    {
        Car car = new Car();

        [TestMethod]
        public void SelectedTransmissionTest() 
        { 
            car.EngineSize = 1.8;
            car.Color = "Blue";
            car.SelectedTransmission = 1;

            Assert.AreEqual(1, car.SelectedTransmission);
        }

        [TestMethod]
        public void CarCostTest()
        {
            LandCruiser LC = new LandCruiser(1.8, "Blue", 1);

            Assert.AreEqual(8086, LC.Cost);
        }

        [TestMethod]
        public void LandCruiserModelTest()
        {
            LandCruiser lc = new LandCruiser();

            Assert.AreEqual("LandCruiser", lc.Model);
        }

        [TestMethod]
        public void SetEngineSize_InputNumberWithDot_ReturnCar()
        {
            Car actualResult = new Car();

            actualResult.EngineSize = 2.0;
            object expectedResult = Managerhelper.SetEngineSize(car, "2.0");

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void SetEngineSize_InputNumberWithComma_FailTest()
        {
            LandCruiser actualResult = new LandCruiser();

            actualResult.EngineSize = 2.0;
            object expectedResult = Managerhelper.SetEngineSize(car, "2,0");

            Assert.AreEqual(actualResult, expectedResult);
        }

        //���� �� �������� �����

        [TestMethod]
        public void SetEngineSize_InputSpace_ThrowsFormatException()
        {//unit test �� ����� exception c#
            Assert.ThrowsException<System.FormatException>(() => Managerhelper.SetEngineSize(car, " "));
        }

        [TestMethod]
        public void SetEngineSize_InputLetters_ThrowsFormatException()
        {
            Assert.ThrowsException<System.FormatException>(() => Managerhelper.SetEngineSize(car, "qwe"));
        }

        [TestMethod]
        public void SetEngineSize_InputEnter_ThrowsFormatException()
        {
            Assert.ThrowsException<System.FormatException>(() => Managerhelper.SetEngineSize(car, " "));
        }

        [TestMethod]
        public void SetSelectedColor_InputPositiveData_PassTest()
        {
            object actualResult = Managerhelper.SetSelectedColor(car, "1");

            Assert.Equals(car.Color = "Green", actualResult);
        }

        [TestMethod]
        public void SetConfigurations_InputCar_ReturnCar() 
        {
            
            object expectedTypeResult = Managerhelper.SetConfigurations(car);

            Assert.IsInstanceOfType(car, expectedTypeResult.GetType());
        }

        [TestMethod]
        public void SetEngineSize_InputCamryQWE_ReturnCamry()
        {

        }

        [TestMethod]
        public void CreateSelectedModel_Input1_ReturnLandCruiser()
        {// �������� ����� ��������� SetConfigurations
            LandCruiser lc = new LandCruiser();

            object obj = Managerhelper.CreateSelectedModel("1");

            Assert.IsInstanceOfType(lc, obj.GetType());
        }

        [TestMethod]
        public void CreateSelectedModel_Input4_ReturnNull()
        {
            object result = Managerhelper.CreateSelectedModel("4");

            Assert.IsNotNull(result, "4");
        }


    }
}
