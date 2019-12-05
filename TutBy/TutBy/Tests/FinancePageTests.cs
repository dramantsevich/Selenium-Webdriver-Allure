using TutBy.Pages;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using AShotNet;

namespace TutBy.Tests
{
    [TestFixture]
    [AllureDisplayIgnored]
    [AllureNUnit]
    public class FinancePageTests : BeforeAndAfterTests
    {
        [Test]
        [AllureTag("TC-1")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("FinancePageTests")]
        public void IsChangedDropDownMenuCurrency_AreEqual()
        {
            string cashAmountFirstField = "4.26";

            FinancePage financePage = homePage.OpenFinancePage();

            financePage.SetCurrencyConverterFirstField(cashAmountFirstField);
            financePage.SetCurrencyConverterFirstCurrency("USD");

            string cashAmountSecondField = financePage.GetCurrencyConverterSecondField();

            Assert.AreEqual(cashAmountFirstField, cashAmountSecondField);
        }
    }
}
