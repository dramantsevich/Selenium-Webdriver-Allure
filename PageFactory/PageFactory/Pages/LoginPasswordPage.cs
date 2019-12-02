using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactory.Pages
{
    public class LoginPasswordPage : Page
    {
        [FindsBy(How = How.Name, Using = "password")]
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
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(NextButton)).Click();

            return new InboxGmailPage(driver);
        }
    }
}
