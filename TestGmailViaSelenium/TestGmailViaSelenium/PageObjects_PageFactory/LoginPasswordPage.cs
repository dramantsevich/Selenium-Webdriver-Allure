using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestGmailViaSelenium.PageObjects_PageFactory
{
    class LoginPasswordPage
    {
        private readonly IWebDriver driver;

        /// <summary>Field for entering password</summary>
        [FindsBy(How = How.Name, Using ="password")]
        public IWebElement PasswordField { get; set; }

        /// <summary>Button for login into gmail</summary>
        [FindsBy(How = How.Id, Using ="passwordNext")]
        public IWebElement NextButton { get; set; }

        /// <summary>Method for set password</summary>
        public void SetPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        /// <summary>Method for login into gmail</summary>
        public void LoginClick()
        {
            NextButton.Click();
        }

        public LoginPasswordPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
