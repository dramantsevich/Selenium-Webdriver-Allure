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
        public void SetEngineSize_InputNumberWithComma_ReturnCar()
        {
            LandCruiser actualResult = new LandCruiser();

            actualResult.EngineSize = 2.0;
            object expectedResult = Managerhelper.SetEngineSize(car, "2,0");

            Assert.AreEqual(actualResult, expectedResult);
        }

        //тест на введеную букву

        [TestMethod]
        public void SetEngineSize_InputSpace_NoException()
        {//unit test на вызов exception c#

            try
            {
                Managerhelper.SetEngineSize(car, " ");
            }
            catch(Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
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
        {// работает когда комментим SetConfigurations
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
