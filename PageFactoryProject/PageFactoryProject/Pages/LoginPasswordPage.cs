using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageFactoryProject.Pages
{
    public class LoginPasswordPage : Page
    {
        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private readonly IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        [CacheLookup]
        private readonly IWebElement NextButton;

        public LoginPasswordPage(IWebDriver driver) : base(driver) { }

        public void SetPassword(string password)
        {
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));

            PasswordField.SendKeys(password);
        }

        public InboxGmailPage LoginClick()
        {
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(NextButton));

            NextButton.Click();

            return new InboxGmailPage(driver);
        }
    }
}
