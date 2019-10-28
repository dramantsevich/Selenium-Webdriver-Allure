using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ManagerHelper.Tests
{
    [TestClass]
    public class ManagerHelperTests
    {

        Car car = new Car();
        List<Car> cars = new List<Car>();

        //Test for method GetAvailableCarsTest
        [TestMethod]
        public void GetAvailableCarsTest_CarsToList_IsNotNullListOfCars()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.IsNotNull(cars);
        }

        #region//Tests for method IsModelValid
        [TestMethod]
        public void IsModelValid_EnterCorrectModel1_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsModelValid("1"));
        }

        [TestMethod]
        public void IsModelValid_EnterCorrectModel2_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsModelValid("2"));
        }

        [TestMethod]
        public void IsModelValid_EnterCorrectModel3_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsModelValid("3"));
        }

        [TestMethod]
        public void IsModelValid_EnterIncorrectDataDot_ReturnFlase()
        {
            Assert.IsFalse(Managerhelper.IsModelValid("."));
        }

        [TestMethod]
        public void IsModelValid_EnterIncorrectDataComma_ReturnFlase()
        {
            Assert.IsFalse(Managerhelper.IsModelValid(","));
        }

        [TestMethod]
        public void IsModelValid_EnterIncorrectDataEnter_ReturnFlase()
        {
            Assert.IsFalse(Managerhelper.IsModelValid(""));
        }

        [TestMethod]
        public void IsModelValid_EnterIncorrectDataSpace_ReturnFlase()
        {
            Assert.IsFalse(Managerhelper.IsModelValid(" "));
        }

        [TestMethod]
        public void IsModelValid_EnterIncorrectDataLetters_ReturnFlase()
        {
            Assert.IsFalse(Managerhelper.IsModelValid("ls"));
        }
        #endregion

        #region//Tests for method IsEngineSizeValid
        [TestMethod]
        public void IsEngineSizeValid_EnterCorrectEngineSize1_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsEngineSizeValid("1"));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterCorrectEngineSize2_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsEngineSizeValid("2"));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterCorrectEngineSize3_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsEngineSizeValid("3"));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterIncorrectDataDot_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid("."));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterIncorrectDataComma_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid(","));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterIncorrectDataEnter_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid(""));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterIncorrectDataSpace_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid(" "));
        }

        [TestMethod]
        public void IsEngineSizeValid_EnterIncorrectDataLetters_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid("ls"));
        }
        #endregion

        #region//Tests for method IsColorValid
        [TestMethod]
        public void IsColorValid_EnterCorrectColor1_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsColorValid("1"));
        }

        [TestMethod]
        public void IsColorValid_EnterCorrectColore2_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsColorValid("2"));
        }

        [TestMethod]
        public void IsColorValid_EnterCorrectColor3_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsColorValid("3"));
        }

        [TestMethod]
        public void IsColorValid_EnterCorrectColor4_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsColorValid("4"));
        }

        [TestMethod]
        public void IsColorValid_EnterIncorrectDataDot_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsColorValid("."));
        }

        [TestMethod]
        public void IsColorValid_EnterIncorrectDataComma_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsColorValid(","));
        }

        [TestMethod]
        public void IsColorValid_EnterIncorrectDataEnter_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsColorValid(""));
        }

        [TestMethod]
        public void IsColorValid_EnterIncorrectDataSpace_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsColorValid(" "));
        }

        [TestMethod]
        public void IsColorValid_EnterIncorrectDataLetters_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsEngineSizeValid("ls"));
        }
        #endregion

        #region//Tests for method IsTransmissionValid
        [TestMethod]
        public void IsTransmissionValid_EnterCorrectTransmission1_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsTransmissionValid("1"));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterCorrectTransmission2_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsTransmissionValid("2"));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterCorrectTransmission3_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsTransmissionValid("3"));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterIncorrectDataDot_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsTransmissionValid("."));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterIncorrectDataComma_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsTransmissionValid(","));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterIncorrectDataEnter_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsTransmissionValid(""));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterIncorrectDataSpace_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsTransmissionValid(" "));
        }

        [TestMethod]
        public void IsTransmissionValid_EnterIncorrectDataLetters_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsTransmissionValid("ls"));
        }
        #endregion

        #region//Tests for method SetSelectedEngineSize
        [TestMethod]
        public void SetSelectedEngineSize_EnterCorrectEngineSize1_ReturnCarWithSetEngineSize()
        {
            Car actual = new Car();

            car.EngineSize = 1.8;
            Managerhelper.SetSelectedEngineSize(actual, "1");

            Assert.AreEqual(car.EngineSize, actual.EngineSize);
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterCorrectEngineSize2_ReturnCarWithSetEngineSize()
        {
            Car actual = new Car();

            car.EngineSize = 2.0;
            Managerhelper.SetSelectedEngineSize(actual, "2");

            Assert.AreEqual(car.EngineSize, actual.EngineSize);
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterCorrectEngineSize3_ReturnCarWithSetEngineSize()
        {
            Car actual = new Car();

            car.EngineSize = 3.0;
            Managerhelper.SetSelectedEngineSize(actual, "3");

            Assert.AreEqual(car.EngineSize, actual.EngineSize);
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterIncorrectDataDot_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedEngineSize(new Car(), "."));
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterIncorrectDataComma_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedEngineSize(new Car(), ","));
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterIncorrectDataEnter_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedEngineSize(new Car(), ""));
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterIncorrectDataSpace_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedEngineSize(new Car(), " "));
        }

        [TestMethod]
        public void SetSelectedEngineSize_EnterIncorrectDataLetters_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedEngineSize(new Car(), "ls"));
        }
        #endregion

        #region//Tests for method SetSelectedColor
        [TestMethod]
        public void SetSelectedColor_EnterCorrectColor1_ReturnCarWithSetGreenColor()
        {
            Car actual = new Car();

            car.Color = "Green";
            Managerhelper.SetSelectedColor(actual, "1");

            Assert.AreEqual(car.Color, actual.Color);
        }

        [TestMethod]
        public void SetSelectedColor_EnterCorrectColor2_ReturnCarWithSetBlackColor()
        {
            Car actual = new Car();

            car.Color = "Black";
            Managerhelper.SetSelectedColor(actual, "2");

            Assert.AreEqual(car.Color, actual.Color);
        }

        [TestMethod]
        public void SetSelectedColor_EnterCorrectColor3_ReturnCarWithSetRedColor()
        {
            Car actual = new Car();

            car.Color = "Red";
            Managerhelper.SetSelectedColor(actual, "3");

            Assert.AreEqual(car.Color, actual.Color);
        }

        [TestMethod]
        public void SetSelectedColor_EnterCorrectColor4_ReturnCarWithSetBlueColor()
        {
            Car actual = new Car();

            car.Color = "Blue";
            Managerhelper.SetSelectedColor(actual, "4");

            Assert.AreEqual(car.Color, actual.Color);
        }

        [TestMethod]
        public void SetSelectedColor_EnterIncorrectDataDot_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedColor(new Car(), "."));
        }

        [TestMethod]
        public void SetSelectedColor_EnterIncorrectDataComma_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedColor(new Car(), ","));
        }

        [TestMethod]
        public void SetSelectedColor_EnterIncorrectDataEnter_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedColor(new Car(), ""));
        }

        [TestMethod]
        public void SetSelectedColor_EnterIncorrectDataSpace_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedColor(new Car(), " "));
        }

        [TestMethod]
        public void SetSelectedColor_EnterIncorrectDataLetters_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedColor(new Car(), "ls"));
        }
        #endregion

        #region//Tests for method SetSelectedTransmission
        [TestMethod]
        public void SetSelectedTransmission_EnterCorrectTransmission1_ReturnCarWithSetManualTransmission()
        {
            Car actual = new Car();

            car.SelectedTransmission = 1;
            Managerhelper.SetSelectedTransmission(actual, "1");

            Assert.AreEqual(car.SelectedTransmission, actual.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterCorrectTransmission2_ReturnCarWithSetAutomaticTransmission()
        {
            Car actual = new Car();

            car.SelectedTransmission = 2;
            Managerhelper.SetSelectedTransmission(actual, "2");

            Assert.AreEqual(car.SelectedTransmission, actual.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterCorrectTransmission3_ReturnCarWithSetCVTTransmission()

        {
            Car actual = new Car();

            car.SelectedTransmission = 3;
            Managerhelper.SetSelectedTransmission(actual, "3");

            Assert.AreEqual(car.SelectedTransmission, actual.SelectedTransmission);
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterIncorrectDataDot_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedTransmission(new Car(), "."));
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterIncorrectDataComma_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedTransmission(new Car(), ","));
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterIncorrectDataEnter_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedTransmission(new Car(), ""));
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterIncorrectDataSpace_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedTransmission(new Car(), " "));
        }

        [TestMethod]
        public void SetSelectedTransmission_EnterIncorrectDataLetters_IsEqualNull()
        {
            Assert.AreEqual(null, Managerhelper.SetSelectedTransmission(new Car(), "ls"));
        }
        #endregion

        #region//Tests for method IsPriceRangeValid
        [TestMethod]
        public void IsPriceRangeValid_EnterStartPriceLessThenEndPrice_ReturnTrue()
        {
            Assert.IsTrue(Managerhelper.IsPriceRangeValid(4000, 4001));
        }

        [TestMethod]
        public void IsPriceRangeValid_EnterStartPriceMoreThenEndPrice_ReturnFalse()
        {
            Assert.IsFalse(Managerhelper.IsPriceRangeValid(4001, 4000));
        }

        #endregion

        #region//Tests for method SetPriceRange
        [TestMethod]
        public void SetPriceRange_InputStartPriceLessThenEndPrice_ReturnPrices()
        {
            string startingPrice = "4000";
            string endingPrice = "5000";

            var actual = Managerhelper.SetPriceRange("4000", "5000");

            Assert.AreEqual((startingPrice, endingPrice), actual);
        }

        [TestMethod]
        public void SetPriceRange_InputStartPriceMoreThenEndPrice_ReturnNulls()
        {
            string startingPrice = "4000";
            string endingPrice = "3999";

            var actual = Managerhelper.SetPriceRange(startingPrice, endingPrice);

            Assert.AreEqual((null, null), actual);
        }

        [TestMethod]
        public void SetPriceRange_InputIncorrectDataDot_ThrowFormatException()
        {
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange(".", "1"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("1", "."));
        }

        [TestMethod]
        public void SetPriceRange_InputIncorrectDataComma_TrowFormatException()
        {
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange(",", "1"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("1", ","));
        }

        [TestMethod]
        public void SetPriceRange_InputIncorrectDataEnter_TrowFormatException()
        {
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("", "1"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("1", ""));
        }

        [TestMethod]
        public void SetPriceRange_InputIncorrectDataSpace_TrowFormatException()
        {
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange(" ", "1"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("1", " "));
        }

        [TestMethod]
        public void SetPriceRange_InputIncorrectDataLetters_TrowFormatException()
        {
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("ls", "1"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.SetPriceRange("1", "ls"));
        }
        #endregion

        #region//Tests for method GetCarsInPriceRange
        [TestMethod]
        public void GetCarsInPriceRange_CarCostIncludeInPriceRange_ReturnCarsInPriceRange()
        {
            string startingPrice = "-999999";
            string endingPrice = "999999";

            Managerhelper.GetAvailableCars(cars);
            var actual = Managerhelper.GetCarsInPriceRange(cars, startingPrice, endingPrice);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetCarsInPriceRange_CarCostNotIncludeInPriceRange_ReturnNull()
        {
            string startingPrice = "0";
            string endingPrice = "1";

            Managerhelper.GetAvailableCars(cars);
            var actual = Managerhelper.GetCarsInPriceRange(cars, startingPrice, endingPrice);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetCarsInPriceRange_StartingPriceMoreThenEndingPrice_ReturnNull()
        {
            string startingPrice = "999999";
            string endingPrice = "0";

            Managerhelper.GetAvailableCars(cars);
            var actual = Managerhelper.GetCarsInPriceRange(cars, startingPrice, endingPrice);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetCarsInPriceRange_InputIncorrectDataDot_ThrowFormatException()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, ".", "999999"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "999999", "."));
        }

        [TestMethod]
        public void GetCarsInPriceRange_InputIncorrectDataComma_ThrowFormatException()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, ",", "999999"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "999999", ","));
        }

        [TestMethod]
        public void GetCarsInPriceRange_InputIncorrectDataEnter_ThrowFormatException()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "", "999999"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "999999", ""));
        }

        [TestMethod]
        public void GetCarsInPriceRange_InputIncorrectDataSpace_ThrowFormatException()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, " ", "999999"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "999999", " "));
        }

        [TestMethod]
        public void GetCarsInPriceRange_InputIncorrectDataDLetters_ThrowFormatException()
        {
            Managerhelper.GetAvailableCars(cars);

            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "ls", "999999"));
            Assert.ThrowsException<FormatException>(() => Managerhelper.GetCarsInPriceRange(cars, "999999", "ls"));
        }

        #endregion
    }
}
