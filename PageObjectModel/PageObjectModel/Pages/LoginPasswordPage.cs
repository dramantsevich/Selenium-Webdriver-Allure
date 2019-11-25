using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages
{
    public class LoginPasswordPage
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        readonly By passwordField = By.Name("password");
        readonly By nextButton = By.Id("passwordNext");

        public LoginPasswordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetPassword(string password)
        {
            IWebElement passwordField;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            passwordField = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.passwordField));
            passwordField.SendKeys(password);
        }

        public void LoginClick()
        {
            IWebElement nextButton;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            nextButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.nextButton));
            nextButton.Click();
        }
    }
}
