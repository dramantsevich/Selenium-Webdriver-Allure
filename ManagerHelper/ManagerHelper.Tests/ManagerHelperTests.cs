using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagerHelper.Tests
{
    [TestClass]
    public class ManagerHelperTests
    {
        [TestMethod]
        public void SetEngineSizeTestNumbersWithDot()
        {
            Assert.IsNull(ManagerHelper.CreateSelectedModel("1"));
        }

        [TestMethod]
        public void SetEngineSizeTestNumberWithComma()
        {
            Car car = new Car();

            Assert.IsNull(ManagerHelper.SetEngineSize(car));
        }

        //ManagerHelper.Car car = new ManagerHelper.Car();
        //Assert.IsNull(ManagerHelper.Managerhelper.SetConfigurations(car));
    }
}
