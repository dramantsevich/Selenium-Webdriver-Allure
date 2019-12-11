using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace tTutBy.Pages
{
    public class ProfilePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='field-fio']")]
        [CacheLookup]
        private readonly IWebElement FIOField;

        [FindsBy(How = How.XPath, Using = "//input[@id='field-birthday']")]
        [CacheLookup]
        private readonly IWebElement BirthdayField;

        [FindsBy(How = How.XPath, Using = "//input[@id='field-city']")]
        [CacheLookup]
        private readonly IWebElement CityField;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            SwitchToSupportPage(driver);
        }

        public string GetCurrentUrl()
        {
            string currentUrl = this.driver.Url;
            return currentUrl;
        }

        public void SwitchToSupportPage(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        public bool IsFormSectionInputFieldsEnabled()
        {
            if (FIOField.Enabled && BirthdayField.Enabled && CityField.Enabled)
                return true;
            else
                return false;
        }
    }
}
