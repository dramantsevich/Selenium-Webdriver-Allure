using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System;

namespace TutBy.Pages
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

        private By currencyLocator;

        public FinancePage(IWebDriver driver) : base(driver) { }

        public void SetCurrencyConverterFirstField(string cash)
        {
            CurrencyConverterFirstField.Clear();
            CurrencyConverterFirstField.SendKeys(cash);
        }

        public string GetCurrencyConverterFirstField()
        {
            string cash = CurrencyConverterFirstField.GetAttribute("value");

            return cash;
        }

        public void SetCurrencyConverterSecondField(string cash)
        {
            CurrencyConverterSecondField.SendKeys(cash);
        }

        public string GetCurrencyConverterSecondField()
        {
            string cash = CurrencyConverterSecondField.GetAttribute("value");

            return cash;
        }

        public void SetCurrencyConverterFirstCurrency(string currency)
        {
            this.currencyLocator = By.XPath($"//span[@class='text'][contains(text(),'{currency}')]");

            CurrencyConverterFirstDropDownMenuButton.Click();

            IWebElement currencyButton = CurrencyConverterFirstDropDownMenuTd.FindElement(currencyLocator);
            currencyButton.Click();
        }

        public void SetCurrencyConverterSecondCurrency(string currency)
        {
            this.currencyLocator = By.XPath($"//span[@class='text'][contains(text(),'{currency}')]");

            CurrencyConverterSecondDropDownMenuButton.Click();

            IWebElement currencyButton = CurrencyConverterSecondDropDownMenuTd.FindElement(currencyLocator);
            currencyButton.Click();
        }
    }
}
