using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper.Tests
{
    [TestClass]
    public class ManagerHelperTests
    {
        enum transmission
        {
            Manual = 1,
            Automatic,
            CVT
        }

        Car car = new Car();

        List<Car> cars = new List<Car>();

        [TestMethod]
        public void SelectedTransmissionTest_Input1_IsManual()
        {
            car.SelectedTransmission = 1;

            Assert.AreEqual((int)transmission.Manual, car.SelectedTransmission);
        }

        [TestMethod]
        public void SelectedTransmissionTest_Input4_IsNotEqual()
        {
            car.SelectedTransmission = 4;

            Assert.AreNotEqual((int)transmission.Automatic, car.SelectedTransmission);
        }

        [TestMethod]
        public void CarCostTest_DoesTheCarPriceEqual_IsEqual()
        {
            //Arrange
            LandCruiser LC = new LandCruiser(1.8, "Blue", 1);

            //Act
            int expectedCost = LC.Cost;

            //Assert
            Assert.AreEqual(expectedCost, LC.Cost);
        }

        [TestMethod]
        public void CarCostTest_SetNotEqualCarPrice_IsNotEqual()
        {
            LandCruiser LC = new LandCruiser(1.8, "Blue", 1);

            int FakeCost = LC.Cost - 1000;

            Assert.AreNotEqual(FakeCost, LC.Cost);
        }

        [TestMethod]
        public void LandCruiserModelTest_SelectedLandCruiserModel_IsEqualLandCruiser()
        {
            LandCruiser lc = new LandCruiser();

            Assert.AreEqual(typeof(LandCruiser).Name, lc.Model);
        }

        [TestMethod]
        public void LandCruiserModelTest_SelectedOtherModelOfCar_IsNotEqual()
        {
            LandCruiser lc = new LandCruiser();

            Assert.AreNotEqual(typeof(Camry).Name, lc.Model);
        }

        [TestMethod]
        public void SetEngineSize_InputNumberWithDot_IsEqual()
        {
            //Arrange
            Car actualResult = new Car();

            //Act
            actualResult.EngineSize = 2.0;
            Managerhelper.SetEngineSize(car, "2.0");

            //Assert
            Assert.AreEqual(actualResult.EngineSize, car.EngineSize);
        }

        [TestMethod]
        public void SetEngineSize_InputNumberWithComma_IsNotEqual()
        {
            //Arrange
            LandCruiser actualResult = new LandCruiser();

            //Act
            actualResult.EngineSize = 2.0;
            Managerhelper.SetEngineSize(car, "2,0");

            //Assert
            Assert.AreNotEqual(actualResult.EngineSize, car.EngineSize);
        }

        //тест на введеную букву
        [TestMethod]
        public void SetEngineSize_InputSpace_ThrowsFormatException()
        {
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
            Assert.ThrowsException<System.FormatException>(() => Managerhelper.SetEngineSize(car, ""));
        }

        [TestMethod]
        public void SetSelectedColor_Input1_IsEqualGreen()
        {
            Car expectedColor = new Car();

            Managerhelper.SetSelectedColor(car, "1");
            expectedColor.Color = "Green";

            Assert.AreEqual(expectedColor.Color, car.Color);
        }
        public void SetSelectedColor_Input2_IsEqualBlack()
        {
            Car expectedColor = new Car();

            Managerhelper.SetSelectedColor(car, "2");
            expectedColor.Color = "Black";

            Assert.AreEqual(expectedColor.Color, car.Color);
        }
        public void SetSelectedColor_Input3_IsEqualRed()
        {
            Car expectedColor = new Car();

            Managerhelper.SetSelectedColor(car, "3");
            expectedColor.Color = "Red";

            Assert.AreEqual(expectedColor.Color, car.Color);
        }
        public void SetSelectedColor_Input4_IsEqualBlue()
        {
            Car expectedColor = new Car();

            Managerhelper.SetSelectedColor(car, "4");
            expectedColor.Color = "Blue";

            Assert.AreEqual(expectedColor.Color, car.Color);
        }

        [TestMethod]
        public void SetSelectedColor_Input0_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedColor(car, "0");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedColor_InputSpace_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedColor(car, " ");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedColor_InputEnter_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedColor(car, "");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedColor_InputDot_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedColor(car, ".");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void SetSelectedTransmission_Input1_IsEqualManual()
        {
            Car expectedTransmission = new Car();

            Managerhelper.SetSelectedTransmission(car, "1");
            expectedTransmission.SelectedTransmission = 1;

            Assert.AreEqual(expectedTransmission.SelectedTransmission, car.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_Input2_IsEqualAutomatic()
        {
            Car expectedTransmission = new Car();

            Managerhelper.SetSelectedTransmission(car, "2");
            expectedTransmission.SelectedTransmission = 2;

            Assert.AreEqual(expectedTransmission.SelectedTransmission, car.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_Input3_IsEqualCVT()
        {
            Car expectedTransmission = new Car();

            Managerhelper.SetSelectedTransmission(car, "3");
            expectedTransmission.SelectedTransmission = 3;

            Assert.AreEqual(expectedTransmission.SelectedTransmission, car.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_Input0_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedTransmission(car, "0");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedTransmission_InputSpace_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedTransmission(car, " ");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedTransmission_InputEnter_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedTransmission(car, "");
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void SetSelectedTransmission_InputDot_IsReturnNull()
        {

            object actual = Managerhelper.SetSelectedTransmission(car, ".");
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void GetAvailableCarsTest_CarsToList_IsNotNullListOfCars()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.IsNotNull(cars);
        }

        //[TestMethod]
        //public void SortCarCost_SortedCarCostByCost_IsSorted()
        //{
        //    List<Car> expectedSortedCars = new List<Car>();

        //    Managerhelper.GetAvailableCars(cars);
        //    Managerhelper.SortCarCost(cars);
        //    Managerhelper.GetAvailableCars(expectedSortedCars);
        //    expectedSortedCars.Sort((a, b) => a.Cost.CompareTo(b.Cost));

        //    Assert.AreEqual(cars, expectedSortedCars);
        //}
    }
}
