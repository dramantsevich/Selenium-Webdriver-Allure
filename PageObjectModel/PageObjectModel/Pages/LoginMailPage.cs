using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages
{
    public class LoginMailPage : Page
    {
        readonly By emailFieldLocator = By.Name("identifier");
        readonly By nextButtonLocator = By.Id("identifierNext");

        public LoginMailPage(IWebDriver driver) : base(driver) { }

        public void SetMail(string mail)
        {
            IWebElement emailField = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.emailFieldLocator));
            emailField.SendKeys(mail);
        }

        public void GoToPasswordPage()
        {
            IWebElement nextButton = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.nextButtonLocator));
            nextButton.Click();
        }
    }
}
