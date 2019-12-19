using tTutBy.Pages;
using NUnit.Framework;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using Allure.Commons;

namespace tTutBy.Tests
{
    [TestFixture]
    public class FinancePageTests : BaseTests
    {
        [Test]
        [AllureTag("TC-1")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("FinancePageTests")]
        public void IsChangedDropDownMenuCurrency_AreEqual()
        {
            string cashAmountFirstField = "4.26";

            FinancePage financePage = homePage.OpenFinancePage();

            financePage.SetCurrencyConverterFirstField(cashAmountFirstField);
            financePage.SetCurrencyConverterFirstCurrency("USD");

            AllureLifecycle.Instance.Verify.That($"cash in first field: {cashAmountFirstField} should correspond to cash in second field: {financePage.GetCurrencyConverterSecondField()}", cashAmountFirstField, Is.EqualTo(financePage.GetCurrencyConverterSecondField()));
        }
    }
}
