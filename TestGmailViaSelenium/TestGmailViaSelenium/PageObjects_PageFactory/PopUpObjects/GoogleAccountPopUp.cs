using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestGmailViaSelenium.PageObjects_PageFactory.PopUpObjects
{
    class GoogleAccountPopUp
    {
        private readonly IWebDriver driver;

        /// <summary>Button to sign out from current account</summary>
        [FindsBy(How = How.XPath, Using = "//a[@id='gb_71']")]
        public IWebElement SignOut { get; set; }

        /// <summary>Sign out from current account</summary>
        public void SignOutFromAccount()
        {
            SignOut.Click();
        }

        public GoogleAccountPopUp(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
