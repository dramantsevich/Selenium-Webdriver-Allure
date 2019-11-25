using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages
{
    class SigninChooserPage
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;

        public SigninChooserPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetCurrentUrl()
        {
            string currentUrl = driver.Url;

            return currentUrl;
        }
    }
}
