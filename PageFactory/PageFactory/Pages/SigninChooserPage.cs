using OpenQA.Selenium;

namespace PageFactory.Pages
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
