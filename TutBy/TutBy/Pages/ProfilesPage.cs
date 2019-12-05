using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TutBy.Pages
{
    public class ProfilePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//header[@class='row b-form__header']")]
        [CacheLookup]
        private readonly IWebElement Header;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            SwitchToSupportPage(driver);
        }

        public bool IsDisplayed()
        {
            if (Header.Displayed)
                return true;
            else
                return false;
        }

        public void SwitchToSupportPage(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
    }
}
