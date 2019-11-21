using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium.Pages.PopUpWindows
{
    public class AccountPopUp
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        By signOut = By.XPath("//a[@id='gb_71']");

        public AccountPopUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SignOutFromAccount()
        {
            IWebElement signOut;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            signOut = fluentWait.Until(x => x.FindElement(this.signOut));
            signOut.Click();
        }
    }
}
