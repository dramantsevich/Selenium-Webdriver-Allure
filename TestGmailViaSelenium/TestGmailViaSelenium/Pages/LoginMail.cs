using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium.Pages
{
    public class LoginMail
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        By emailField = By.Name("identifier");
        By nextButton = By.Id("identifierNext");

        public LoginMail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetMail(string mail)
        {
            IWebElement emailField;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.emailField));
            emailField.SendKeys(mail);
        }

        public void GoToPasswordPage()
        {
            IWebElement nextButton;

            nextButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.nextButton));
            nextButton.Click();
        }
    }
}
