using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace tTutBy.Pages
{
    public class FinancePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//table[@id='BYN_item']//input[@class='i-p']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterFirstField;

        [FindsBy(How = How.XPath, Using = "//td[@id='select_currency_BYN']//button[@class='btn dropdown-toggle selectpicker_fix btn-default']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterFirstDropDownMenuButton;

        [FindsBy(How = How.XPath, Using = "//td[@id='select_currency_BYN']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterFirstDropDownMenuTd;

        [FindsBy(How = How.XPath, Using = "//table[@id='USD_item']//input[@class='i-p']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterSecondField;

        [FindsBy(How = How.XPath, Using = "//td[@id='select_currency_USD']//button[@class='btn dropdown-toggle selectpicker_fix btn-default']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterSecondDropDownMenuButton;

        [FindsBy(How = How.XPath, Using = "//td[@id='select_currency_USD']")]
        [CacheLookup]
        private readonly IWebElement CurrencyConverterSecondDropDownMenuTd;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-2']//div[@class='b-equalwidgets']")]
        [CacheLookup]
        private readonly IWebElement EqualWidgets;


        private By currencyLocator;
        public FinancePage(IWebDriver driver) : base(driver) { }

        public void SetCurrencyConverterFirstField(string cash)
        {
            AllureLifecycle.Instance.RunStep("Set cash in first field of the currency converter", () =>
            {
                CurrencyConverterFirstField.Clear();
                CurrencyConverterFirstField.SendKeys(cash);
            }, cash);
        }

        public string GetCurrencyConverterFirstField()
        {
            return CurrencyConverterFirstField.GetAttribute("value");
        }

        public void SetCurrencyConverterSecondField(string cash)
        {
            CurrencyConverterSecondField.SendKeys(cash);
        }

        public string GetCurrencyConverterSecondField()
        {
            AllureLifecycle.Instance.RunStep("Get amount of cash on the second field of the currency converter", () =>
            {
                
            }, CurrencyConverterSecondField.GetAttribute("value"));

            return CurrencyConverterSecondField.GetAttribute("value");
        }

        public void SetCurrencyConverterFirstCurrency(string currency)
        {
            AllureLifecycle.Instance.RunStep("Set currency in first field of the currency converter", () =>
            {
                this.currencyLocator = By.XPath($"//span[@class='text'][contains(text(),'{currency}')]");

                CurrencyConverterFirstDropDownMenuButton.Click();

                IWebElement currencyButton = CurrencyConverterFirstDropDownMenuTd.FindElement(currencyLocator);
                currencyButton.Click();
            }, currency);
        }

        public void SetCurrencyConverterSecondCurrency(string currency)
        {
            this.currencyLocator = By.XPath($"//span[@class='text'][contains(text(),'{currency}')]");

            CurrencyConverterSecondDropDownMenuButton.Click();

            IWebElement currencyButton = CurrencyConverterSecondDropDownMenuTd.FindElement(currencyLocator);
            currencyButton.Click();
        }

        public bool IsEqualWidgetsDispayed()
        {
            if (EqualWidgets.Displayed)
                return true;
            else
                return false;
        }
    }
}
