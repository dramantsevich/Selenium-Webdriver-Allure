using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class AccountPopUp : Page
    {
        readonly By signOutLocator = By.XPath("//a[@id='gb_71']");
        readonly By currentAccountMailLocator = By.XPath("//div[@class='gb_kb']");

        public AccountPopUp(IWebDriver driver) : base(driver) { }

        public void SignOutFromAccount()
        {
            IWebElement signOut = webDriverWait.Until(x => x.FindElement(this.signOutLocator));
            signOut.Click();
        }

        public IWebElement GetCurrentAccountMail()
        {
            IWebElement currentAccountMail = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.currentAccountMailLocator));
            return currentAccountMail;
        }
    }
}
