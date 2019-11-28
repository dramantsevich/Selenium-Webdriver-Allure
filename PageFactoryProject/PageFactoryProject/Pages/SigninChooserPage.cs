using OpenQA.Selenium;

namespace PageFactoryProject.Pages
{
    public class SigninChooserPage : Page
    {
        public SigninChooserPage(IWebDriver driver) : base(driver) { }

        public string GetCurrentUrl()
        {
            string currentUrl = this.driver.Url;
            return currentUrl;
        }
    }
}
