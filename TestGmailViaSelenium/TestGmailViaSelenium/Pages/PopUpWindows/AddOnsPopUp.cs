using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium.Pages.PopUpWindows
{
    public class AddOnsPopUp
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        By title = By.XPath("//span[@class='yQsxXc']");

        public string GetAddOnsTitle()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement title = fluentWait.Until(x => x.FindElement(this.title));

            return title.Text;
        }

        public AddOnsPopUp(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
