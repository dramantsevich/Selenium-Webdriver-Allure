using AShotNet.ScreenTaker;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        [FindsBy(How = How.XPath, Using = "//div[@id='mainmenu']//ul[@class='b-topbar-i']//li[2]/a[contains(text(),'TUT.BY')]")]
        [CacheLookup]
        private readonly IWebElement TopBarLinkTutBy;

        private By currencyLocator;
        public FinancePage(IWebDriver driver) : base(driver) { }

        public void SetCurrencyConverterFirstField(string cash)
        {
            CurrencyConverterFirstField.Clear();
            CurrencyConverterFirstField.SendKeys(cash);
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
            new AShotNet.AShot()
                .ShootingStrategy(new ViewportPastingStrategy(10))
                .TakeScreenshot(driver);

            return CurrencyConverterSecondField.GetAttribute("value");
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

        public bool IsDispayed()
        {
            if (TopBarLinkTutBy.Displayed)
                return true;
            else
                return false;
        }
    }
}
