using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages
{
    public class LoginPasswordPage : Page
    {
        readonly By passwordFieldLocator = By.Name("password");
        readonly By nextButtonLocator = By.Id("passwordNext");

        public LoginPasswordPage(IWebDriver driver) : base(driver) { }

        public void SetPassword(string password)
        {
            IWebElement passwordField = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.passwordFieldLocator));
            passwordField.SendKeys(password);
        }

        public void LoginClick()
        {
            IWebElement nextButton = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(this.nextButtonLocator));
            nextButton.Click();
        }
    }
}
