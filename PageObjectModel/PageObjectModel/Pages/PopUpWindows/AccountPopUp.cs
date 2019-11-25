using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class AccountPopUp
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        readonly By signOut = By.XPath("//a[@id='gb_71']");
        readonly By currentAccountMail = By.XPath("//div[@class='gb_kb']");

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

        public IWebElement GetCurrentAccountMail()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement currentAccountMail = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.currentAccountMail));

            return currentAccountMail;
        }
    }
}
