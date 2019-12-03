using OpenQA.Selenium;

namespace TutByTemp.Pages
{
    public class ProfilesPage : Page
    {
        public ProfilesPage(IWebDriver driver) : base(driver) { }

        public string GetCurrentUrl()
        {
            string currentUrl = this.driver.Url;

            return currentUrl;
        }
    }
}
