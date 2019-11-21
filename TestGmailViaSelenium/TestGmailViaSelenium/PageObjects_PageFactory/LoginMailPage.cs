using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestGmailViaSelenium.PageObjects_PageFactory
{
    class LoginMailPage
    {
        private readonly IWebDriver driver;

        /// <summary>Field for entering email or phone number </summary>
        [FindsBy(How = How.Name, Using = "identifier")]
        public IWebElement EmailField { get; set; }

        /// <summary>Button for next page to entry password  </summary>
        [FindsBy(How = How.Id, Using =("identifierNext"))]
        public IWebElement NextButton { get; set; }

        /// <summary>Method for set mail or phone number</summary>
        public void SetMail(string mail)
        {
            EmailField.SendKeys(mail);
        }

        /// <summary>Method for go to entry password</summary>
        public void GoToPasswordPage()
        {
            NextButton.Click();
        }

        public LoginMailPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
        }
    }
}
